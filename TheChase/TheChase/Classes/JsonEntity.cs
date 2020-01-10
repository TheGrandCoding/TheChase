using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChase.Classes
{
    public abstract class JsonEntity
    {
        public JsonEntity(JObject obj) { }
        public abstract JObject ToObject();
        protected DateTime GetMidnight()
        {
            var now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day);
        }
        protected DateTime GetTime(double seconds)
        {
            return GetMidnight().AddSeconds(seconds);
        }
    }
}
