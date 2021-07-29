using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.models
{
    public interface IUsers
    {
        public List<User> getUsers();
        public Task<int> AddUser(User userdata);
    }
}
