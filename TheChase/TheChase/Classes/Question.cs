using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChase.Classes
{
    public abstract class Question : JsonEntity
    {
        public Question(JObject obj) : base(obj)
        {
            Prompt = obj["p"].ToObject<string>();
            Answers = obj["a"].ToObject<string[]>();
            CorrectAnswer = obj["i"].ToObject<int>();
        }
        public override JObject ToObject()
        {
            JObject obj = new JObject();
            obj["p"] = Prompt;
            obj["a"] = JsonConvert.SerializeObject(Answers);
            obj["i"] = CorrectAnswer.ToString();
            return obj;
        }
        public string Prompt { get; set; }
        public  string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }

    }
}
