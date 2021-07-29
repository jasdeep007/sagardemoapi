using sagardemoapi.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.models
{
    public class usersRepository : IUsers // real
    {
        public readonly DbAccess _db;
        public usersRepository(DbAccess db)
        {
            this._db = db;
        }

        public async Task<int> AddUser(User userdata)
        {
            this._db.Add(userdata);
            await this._db.SaveChangesAsync();
            return userdata.userid;
        }

        public List<User> getUsers()
        {
            //fetch all users with userid>2

            var result = this._db.Users.Where(x => x.userid > 2).ToList<User>();

            return result;
        }
    }
}
