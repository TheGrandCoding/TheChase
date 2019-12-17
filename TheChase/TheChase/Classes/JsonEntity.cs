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
    }
}
