using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TheChase.Classes
{
    public class Game : JsonEntity
    {
        public Game() : base(null) { }
        public User P1;
        public User P2;
        public User P3;
        public User P4;
        public User Host;
        public User Chaser;
        public List<User> Spectators = new List<User>();
        public bool Started;
        public int Reward;

        void removePlayer(User u)
        {
            if (Spectators.Remove(u))
                return;
            if (P1 == u)
                P1 = null;
            else if (P2 == u)
                P2 = null;
            else if (P3 == u)
                P3 = null;
            else if (P4 == u)
                P4 = null;
            else if (Host == u)
                Host = null;
            else if (Chaser == u)
                Chaser = null;
        }

        public string GetRole(User u)
        {
            if (P1 == u)
                return "P1";
            else if (P2 == u)
                return "P2";
            else if (P3 == u)
                return "P3";
            else if (P4 == u)
                return "P4";
            else if (Host == u)
                return "Host";
            else if (Chaser == u)
                return "Chaser";
            return "Spectator";
        }

        public void Swap(User u, char chr)
        {
            if (chr == 'P')
            {
                if (P1 == null)
                {
                    removePlayer(u);
                    P1 = u;
                }
                else if (P2 == null)
                {
                    removePlayer(u);
                    P2 = u;
                }
                else if (P3 == null)
                {
                    removePlayer(u);
                    P3 = u;
                }
                else if (P4 == null)
                {
                    removePlayer(u);
                    P4 = u;
                }
            }
            else if (chr == 'H')
            {
                if(Host == null)
                {
                    removePlayer(u);
                    Host = u;
                }
            }
            else if (chr == 'C')
            {
                if(Chaser == null)
                {
                    removePlayer(u);
                    Chaser = u;
                }
            } else
            {
                removePlayer(u);
                Spectators.Add(u);
            }
        }

        public Game(JObject obj) : base(obj)
        {
            var id1 = obj["1"].ToObject<uint>();
            P1 = Common.GetUser(id1);
            P2 = Common.GetUser(obj["2"].ToObject<uint>());
            P3 = Common.GetUser(obj["3"].ToObject<uint>());
            P4 = Common.GetUser(obj["4"].ToObject<uint>());
            Host = Common.GetUser(obj["h"].ToObject<uint>());
            Chaser = Common.GetUser(obj["c"].ToObject<uint>());
            var arr = obj["s"].ToObject<uint[]>();
            Spectators = arr.Select(x => Common.GetUser(x)).ToList();
            Reward = obj["r"].ToObject<int>();
        }

        public override JObject ToObject()
        {
            var jobj = new JObject();
            jobj["1"] = P1?.Id ?? 0;
            jobj["2"] = P2?.Id ?? 0;
            jobj["3"] = P3?.Id ?? 0;
            jobj["4"] = P4?.Id ?? 0;
            jobj["h"] = Host?.Id ?? 0;
            jobj["c"] = Chaser?.Id ?? 0;
            jobj["r"] = Reward;
            jobj["s"] = JToken.FromObject(Spectators.Select(x => x.Id).ToList());
            return jobj;
        }
    }
}
