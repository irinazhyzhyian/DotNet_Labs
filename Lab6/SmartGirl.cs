using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Couple(Pair = "Student", Probability = 20, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 50, ChildType = "Book")]
    public class SmartGirl : Human
    {

        public SmartGirl() : base("SmartGirl")
        {
        }

        public SmartGirl(string name) : base(name)
        {
        }

    }
}
