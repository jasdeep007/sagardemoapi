using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.models
{
    public class Employee
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }
}
