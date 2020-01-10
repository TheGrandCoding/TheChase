using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChase.Classes
{
    public class Question : JsonEntity
    {
        public Question() : base(null) { }
        public Question(JObject obj) : base(obj)
        {
            Prompt = obj["p"].ToObject<string>();
            Answers = obj["a"].ToObject<string[]>();
            CorrectAnswer = obj["i"].ToObject<int>();
            GivenAt = GetTime(obj["at"].ToObject<double>());
            DueBefore = GetTime(obj["due"].ToObject<double>());
        }
        public override JObject ToObject()
        {
            JObject obj = new JObject();
            obj["p"] = Prompt;
            obj["a"] = JsonConvert.SerializeObject(Answers);
            obj["i"] = CorrectAnswer.ToString();
            obj["at"] = GivenAt.TimeOfDay.TotalSeconds;
            obj["due"] = DueBefore.TimeOfDay.TotalSeconds;
            return obj;
        }
        public string Prompt { get; set; }
        public  string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }
        public DateTime GivenAt { get; set; }
        public DateTime DueBefore { get; set; }

    }
}
