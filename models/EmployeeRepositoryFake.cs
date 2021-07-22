using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.models
{
    public class EmployeeRepositoryFake : IEmployee
    {
        public List<Employee> getEmployees()
        {
            return new List<Employee>() {
                new Employee(){ id=Guid.NewGuid(), name="jasdeep fake", age=21},
                new Employee(){ id=Guid.NewGuid(),name="outtm fake",age=16}
            };
        }

        public Guid returnid()
        {
            throw new NotImplementedException();
        }
    }
}
