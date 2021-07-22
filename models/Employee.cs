using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.models
{
    public class Employee
    {
       
        public string name { get; set; }
        public int age { get; set; }
    }
    public class newEmployee: Employee
    {
        public Guid id { get; set; }
    }
}
