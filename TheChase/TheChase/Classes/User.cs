using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TheChase.Classes
{
    public class User : JsonEntity
    {
        public User(JObject obj) : base(obj)
        {
            Id = obj["id"].ToObject<uint>();
            Name = obj["name"].ToObject<string>();
        }
        public User() : base(null) { }

        public uint Id { get; set; }
        public string Name { get; set; }

        public override JObject ToObject()
        {
            var obj = new JObject();
            obj["id"] = Id.ToString();
            obj["name"] = Name;
            return obj;
        }
    }
}
