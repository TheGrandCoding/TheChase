using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChase.Classes
{
    public static class QUESTIONS
    {
        const char seperator = '`';
        const string openQuestions = "moneybuilders_qs.txt";
        const string multiChoiceQuestions = "multiplechoice_qs.txt";
        const string doneQuestions = "done.txt";

        public const string newLineReplace = "/n/";

        public static List<Question> ClosedQuestions = new List<Question>();
        public static List<MoneyBuilderQ> OpenQuestions = new List<MoneyBuilderQ>();

        private static List<int> doneQs = new List<int>(); // where closed are postive indexes, open are negative -- both +1 or -1 (no zero)

        static void loadOpenLine(string line)
        {
            var sep = line.Split(seperator);
            var prompt = sep[0].Replace(newLineReplace, "\n");
            var answer = sep[1].Replace(newLineReplace, "\n");
            var q = new MoneyBuilderQ();
            q.Prompt = prompt;
            q.Answers = new string[] { answer };
            q.CorrectAnswer = 0;
            OpenQuestions.Add(q);
        }

        static void loadCloseLine(string line)
        {
            var sep = line.Split(seperator);
            var prompt = sep[0].Replace(newLineReplace, "\n");
            var answer = sep[1].Replace(newLineReplace, "\n"); // always store answer first
            var incor1 = sep[2].Replace(newLineReplace, "\n");
            var incor2 = sep[3].Replace(newLineReplace, "\n");
            var q = new Question();
            q.Prompt = prompt;
            q.Answers = new string[] { answer, incor1, incor2 };
            q.CorrectAnswer = 0;
            ClosedQuestions.Add(q);
        }

        static string GetLineFor(Question question)
        {
            if(question is MoneyBuilderQ money)
            {
                return $"{money.Prompt.Replace("\n", newLineReplace)}{seperator}{money.Answers[0].Replace("\n", newLineReplace)}";
            } else
            {
                return $"{question.Prompt.Replace("\n", newLineReplace)}{seperator}{string.Join(seperator.ToString(), question.Answers.Select(x => x.Replace("\n", newLineReplace)))}";
            }
        }

        public static void Save()
        {
            string closed = "";
            foreach (var clos in ClosedQuestions)
                closed += GetLineFor(clos) + "\r\n";
            File.WriteAllText(multiChoiceQuestions, closed);

            string opened = "";
            foreach (var ope in OpenQuestions)
                opened += GetLineFor(ope) + "\r\n";
            File.WriteAllText(openQuestions, opened);

            string done = "";
            foreach (var dne in doneQs)
                done += $"{dne}\r\n";
            File.WriteAllText(doneQuestions, done);
        }

        public static Question GetClosed()
        {
            Question q = null;
            int tries = 0;
            do
            {
                int rand = Program.RND.Next(0, ClosedQuestions.Count);
                var convert = rand + 1;
                if (!doneQs.Contains(convert))
                {
                    q = ClosedQuestions[rand];
                    doneQs.Add(convert);
                }
                tries++;
            } while (q == null && tries < ClosedQuestions.Count);
            return q;
        }

        public static void Load()
        {
            if(File.Exists(openQuestions))
            {
                foreach(var line in File.ReadAllLines(openQuestions))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    loadOpenLine(line.Trim());
                }
            }
            if(File.Exists(multiChoiceQuestions))
            {
                foreach(var line in File.ReadAllLines(multiChoiceQuestions))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    loadCloseLine(line.Trim());
                }
            }
            if(File.Exists(doneQuestions))
            {
                foreach(var line in File.ReadAllLines(doneQuestions))
                {
                    if(int.TryParse(line.Trim(), out var index))
                    {
                        doneQs.Add(index);
                    }
                }
            }
        }
        
    }
}
