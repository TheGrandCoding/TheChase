﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheChase.Classes;

namespace TheChase
{
    public static class MasterList
    {
        public static EventHandler<string> Log;

        static HttpClient Client { get; set; }
        const string TYPE = "TheChase";
        const string USERAGENT = "TheChase";

        static Guid m_id = Guid.Empty;
        static int m_nonce = 0;

        public static void LoadInfo()
        {
            try
            {
                var lines = File.ReadAllLines("masterlist.info");
                Guid.TryParse(lines[0], out m_id);
                int.TryParse(lines[1], out m_nonce);
            }
            catch (FileNotFoundException)
            {
                m_id = Guid.Empty;
                m_nonce = 0;
            }
            catch (Exception ex)
            {
                Log?.Invoke(null, $"Errored when LoadInfo: {ex}");
            }
        }

        public static void SaveInfo()
        {
            try
            {
                File.WriteAllText("masterlist.info", $"{m_id}\r\n{m_nonce}");
            }
            catch (Exception ex)
            {
                Log?.Invoke(null, $"Failed SaveInfo: {ex}");
            }
        }

        public static Guid Id
        {
            get
            {
                if (m_id == Guid.Empty)
                {
                    LoadInfo();
                }
                return m_id;
            }
        }

        public static int Nonce
        {
            get
            {
                if (m_nonce == 0)
                    LoadInfo();
                return m_nonce;
            }
        }

        static void createCheck()
        {
            if (Client == null)
            {
                Client = new HttpClient();
                Client.BaseAddress = new Uri("https://ml-api.uk.ms/");
                Client.DefaultRequestHeaders.Add("User-Agent", USERAGENT);
                LoadInfo();
            }
        }

        public static async Task<MasterlistServer[]> GetServers()
        {
            createCheck();
            var request = new HttpRequestMessage(HttpMethod.Get, "/masterlist/list?type=" + TYPE);
            var response = await Client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var parse = JsonConvert.DeserializeObject<MasterlistServer[]>(str);
                return parse;
            }
            else
            {
                var err = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new InvalidOperationException("Could not get masterlist: " + err);
            }
        }
        public static async Task<string> GetExternalIP()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://icanhazip.com");
                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                return content.Trim();
            }
        }
        public static System.Net.IPAddress GetInternalIP()
        {
            var host = System.Net.Dns.GetHostName();
            var ips = System.Net.Dns.GetHostAddresses(host);
            foreach (var ip in ips)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return ip;
            }
            return System.Net.IPAddress.Parse("127.0.0.1");
        }
        public static async Task<MasterlistServer> StartServer(string name)
        {
            createCheck();
            var intIp = GetInternalIP();
            var extIp = await GetExternalIP();
            if(Id != Guid.Empty && Nonce != 0)
            { // seems we may already have a server, so we'll continue it..
                var did = await ContinueServer();
                if (did)
                { // all is well, we successfully continued. 
                    var oldSrv = new MasterlistServer(name, extIp, intIp.ToString(), TYPE, false);
                    return oldSrv;
                }

            }
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"/masterlist/create?name={Uri.EscapeDataString(name)}&extn={extIp}&intl={intIp}&type={TYPE}&pass=false");
            var response = await Client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var split = content.Split('#');
                if (Guid.TryParse(split[0], out m_id) && int.TryParse(split[1], out m_nonce))
                {
                    var srv = new MasterlistServer(name, extIp, intIp.ToString(), TYPE, false);
                    srv.Nonce = m_nonce;
                    srv.Id = m_id;
                    SaveInfo();
                    return srv;
                }
                else
                {
                    Log?.Invoke(null, $"Failed to properly parse response: {content}");
                }
            }
            else
            {
                Log?.Invoke(null, $"Failed to GET: {response.StatusCode}: {content}");
            }
            return null;
        }

        public static async Task<bool> SetPlayerCount(int players)
        {
            createCheck();
            if (m_id == Guid.Empty || m_nonce == 0)
            {
                throw new InvalidOperationException($"Cannot set players on a server that has not been registerd to masterlist");
            }
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"/masterlist/players?id={m_id}&nonce={m_nonce}&value={players}");
            var response = await Client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Log?.Invoke(null, $"Update players {response.StatusCode} {response.Content}");
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> ContinueServer()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, 
                $"/masterlist/continue?id={Id}&nonce={Nonce}");
            var response = await Client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Log?.Invoke(null, $"Continue: {response.StatusCode} {content}");
            return response.IsSuccessStatusCode;
        }

    }
}
