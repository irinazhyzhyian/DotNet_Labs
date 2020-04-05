using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Couple(Pair = "Student", Probability = 40, ChildType = "PrettyGirl")]
    [Couple(Pair = "Botan", Probability = 10, ChildType = "PrettyGirl")]
    public class PrettyGirl : Human
    {

        public PrettyGirl() : base("PrettyGirl")
        {
        }

        public PrettyGirl(string name) : base(name)
        {
        }

    }
}
