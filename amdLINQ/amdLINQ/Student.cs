using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amdLINQ
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Debt { get; set; }

        public override string ToString()
        {
            return $"({Id}, {Name}, {Nationality}, {Debt})";
        }
    }
}
