using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TheChase.Classes
{
    public class MoneyBuilderQ : Question
    {
        public MoneyBuilderQ() { }
        public User WaitingFor;
        public DateTime Started;
        public MoneyBuilderQ(JObject obj) : base(obj)
        {
            WaitingFor = Common.GetUser(obj["wait"].ToObject<uint>());
            Started = DateTime.Parse(obj["time"].ToObject<string>());
        }

        public override JObject ToObject()
        {
            var jobj = base.ToObject();
            jobj["wait"] = WaitingFor.Id;
            jobj["time"] = Started.ToString("hh:MM:ss.fff");
            return jobj;
        }
    }
}
