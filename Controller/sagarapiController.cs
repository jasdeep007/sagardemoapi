using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sagardemoapi.filters;
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
        private readonly IUsers _user;

        public sagarapiController(IEmployee emp, IEmployee emp1, IUsers user)
        {
            this._emp = emp; // injected here
            this._emp1 = emp1;
            this._user = user;
        }

        [HttpPost]
        [ActionName("createuser")]
        public Task<int> createuser(User abc)
        {
            return this._user.AddUser(abc);
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
        [ActionName("getusers")]
        public List<User> getusers()
        {
            return this._user.getUsers();
        }
        [HttpGet]
        [ActionName("getAllEmployees")]
        //[tokenverify]
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
        public async Task<List<Employee>> gettaskemployee()
        {
            var r1 = Task.Run(() => _emp.getEmployees());
            await Task.WhenAll(r1);
            return r1.Result;
        }

        [HttpGet]
        public async Task<object> apicall()
        {
            var st = DateTime.Now.ToString();
            var r1 = Task.Run(() => methodA());
            var r2 = Task.Run(() => methodB());
            var r3 = Task.Run(() => methodC());
            var et = DateTime.Now.ToString();
            await Task.WhenAll(r1, r2, r3);
            return new
            {
                st = st,
                r1 = r1.Result,
                r2 = r2.Result,
                r3 = r3.Result,
                et = et
            };
        }

        [NonAction]
        public string methodA()
        {
            System.Threading.Thread.Sleep(3000);
            return "method A";
        }
        [NonAction]
        public string methodB()
        {
            System.Threading.Thread.Sleep(3000);
            return "method B";
        }
        [NonAction]
        public string methodC()
        {
            System.Threading.Thread.Sleep(3000);
            return "method C";
        }

        [HttpGet]
        public Guid getid()
        {
            return _emp.returnid();
        }

    }
}
