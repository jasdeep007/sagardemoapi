using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sagardemoapi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class sagarapiController : ControllerBase
    {
        private readonly IEmployee _emp;
        private readonly IEmployee _emp1;

        public sagarapiController(IEmployee emp,IEmployee emp1)
        {
            this._emp = emp; // injected here
            this._emp1 = emp1;
        }

        [HttpGet]
        public string myfirstapi()
        {
            return "I am the output of very first api";
        }

        [HttpGet]
        public string getarraydata()
        {
            return "outtm.com";
        }

        [HttpGet]
        public List<Employee> getAllEmployees()
        {
            List<Employee> employee = new List<Employee>();
            for (int i = 0; i < 1; i++)
            {
                employee.AddRange(_emp.getEmployees());
                employee.AddRange(_emp1.getEmployees());
            }
            return employee;
        }

        [HttpGet]
        public Guid getid()
        {
            return _emp.returnid();
        }

    }
}
