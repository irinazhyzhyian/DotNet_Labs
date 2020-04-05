using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Couple(Pair = "Girl", Probability = 70, ChildType = "SmartGirl")]
    [Couple(Pair = "PrettyGirl", Probability = 100, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 80, ChildType = "Book")]
    public class Botan : Human
    {

        public Botan() : base("Botan")
        {
        }

        public Botan(string name) : base(name)
        {
        }
    }
}
