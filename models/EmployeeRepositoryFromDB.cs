using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.models
{
    public class EmployeeRepositoryFromDB : IEmployee
    {
        private Guid idd;
        public EmployeeRepositoryFromDB()
        {
            // generate id here
            this.idd = Guid.NewGuid();
        }
        public List<Employee> getEmployees()
        {
            return new List<Employee>() {
                new Employee(){ id=idd,name="jasdeep", age=21}
            };
        }

        public Guid returnid()
        {
            return idd;
        }
    }
}
