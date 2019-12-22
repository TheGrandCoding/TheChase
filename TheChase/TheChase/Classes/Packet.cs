using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChase.Classes
{
    // TODO: maybe make this a short?
    public enum PacketId : int
    {
        #region Common Packets


        #endregion

        #region Client-Sent Packets
        /// <summary>
        /// Client attempts to give the answer to their question
        /// Content: Index of answer
        /// </summary>
        SelectAnswer,
        /// <summary>
        /// Client asks for either 'P'layer, 'H'ost, or 'C'haser
        /// Content: <see cref="Char"/>
        /// </summary>
        RequestRole,

        #endregion
        #region Server-Sent Packets

        /// <summary>
        /// Server tells Client a new head-2-head question has begun
        /// Content: <see cref="Question"/>
        /// </summary>
        NewH2HQuestion,
        /// <summary>
        /// Server informs Clients that a user has disconnected
        /// </summary>
        UserLeft,
        /// <summary>
        /// Server informs Client of their <see cref="User"/>
        /// </summary>
        GiveIdentity,
        /// <summary>
        /// Server informs Client of the <see cref="Game"/> state
        /// </summary>
        SendGameState,
        /// <summary>
        /// Server orders Client to disconnect
        /// Content: <see cref="string"/> reason
        /// </summary>
        Disconnect,
        GameStarted,


        /// <summary>
        /// Server notifies new client joined
        /// </summary>
        UserJoined,
        #endregion
    }
    public class Packet
    {
        public Packet(PacketId id, JsonEntity content) : this(id, content.ToObject())
        {
        }
        public Packet(PacketId id, JObject obj)
        {
            Id = id;
            Content = obj;
        }

        public Packet(string json)
        {
            var obj = JObject.Parse(json);
            Id = (PacketId)Enum.Parse(typeof(PacketId), obj["id"].ToObject<string>());
            Content = JObject.Parse(obj["payload"].ToString());
        }
        [JsonProperty("i")]
        public PacketId Id { get; set; }
        [JsonProperty("c")]
        public JObject Content { get; set; }

        public JObject ToJson()
        {
            var obj = new JObject();
            obj["id"] = Id.ToString();
            obj["payload"] = Content.ToString();
            return obj;
        }

        public override string ToString()
        {
            return ToJson().ToString();
        }
    }
}
