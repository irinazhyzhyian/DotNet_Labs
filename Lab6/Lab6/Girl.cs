using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Couple(Pair = "Student", Probability = 70, ChildType = "Girl")]
    [Couple(Pair = "Botan", Probability = 30, ChildType = "SmartGirl")]
    public class Girl : Human
    {

        public Girl() : base("Girl")
        {
        }

        public Girl(string name) : base(name)
        {
        }
    }
}
