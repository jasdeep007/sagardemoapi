using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.models
{
    public interface IEmployee
    {
        public List<Employee> getEmployees();

        public Guid returnid();
    }
}
