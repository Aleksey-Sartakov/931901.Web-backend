using System.ComponentModel.DataAnnotations;

namespace Solution.Models
{
    public class CulcData
    {
        public int a { get; set; }
        public int b { get; set; }
        public string operation { get; set; }
        public int result { get; set; }
        public int CountOfQuestions { get; set; }
        public int CountOfRightAnswers { get; set; }
        public List<string> QuestionsData { get; set; }
        public static CulcData Instance { get; set; } = new CulcData();

        public CulcData()
        {

        }


        public void Reset()
        {
            QuestionsData = new List<string>();
            CountOfRightAnswers = 0;
            CountOfQuestions = 0;
        }

        public void CreateQuestion()
        {
            CountOfQuestions++;
            Random rnd = new Random();
            int op = rnd.Next(4);
            a = rnd.Next(10);
            if (op == 3)
            {
                operation = "/";
                b = rnd.Next(1, 10);
            }
            else
            {
                b = rnd.Next(10);
                switch (op)
                {
                    case 0:
                        operation = "+";
                        break;
                    case 1:
                        operation = "-";
                        break;
                    case 2:
                        operation = "*";
                        break;
                };

            }
        }

        public int Culc()
        {
            return operation switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b,
            };
        }
    }
}
