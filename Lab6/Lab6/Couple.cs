using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class Couple : Attribute
    {
        public string Pair { get; set; }
        public int Probability { get; set; }
        public string ChildType { get; set; }
    }
}
