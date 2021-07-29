using sagardemoapi.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.models
{
    public class userrepositoryone : IUsers // fake
    {
        public readonly DbAccess _db;
        public userrepositoryone(DbAccess db)
        {
            this._db = db;
        }

        public Task<int> AddUser(User userdata)
        {
            throw new NotImplementedException();
        }

        public List<User> getUsers()
        {
            return this._db.Users.ToList<User>();
        }
    }
}
