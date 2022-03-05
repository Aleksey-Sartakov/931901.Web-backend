using System.ComponentModel.DataAnnotations;

namespace Solution.Models
{
    public enum Operations
    {
        [Display(Name="+")]
        Plus,
        [Display(Name = "-")]
        Minus,
        [Display(Name = "*")]
        Multiply,
        [Display(Name = "/")]
        Divide,

    }

    public class CulcData
    {
        public int a { get; set; }
        public int b { get; set; }
        public Operations operation { get; set; }

        public int Culc()
        {
            return operation switch
            {
                Operations.Plus => a + b,
                Operations.Minus => a - b,
                Operations.Multiply => a * b,
                Operations.Divide => a / b,
            };
        }
    }
}
