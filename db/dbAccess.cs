using Microsoft.EntityFrameworkCore;
using sagardemoapi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi.db
{
    public class DbAccess : DbContext
    {
        public DbAccess(DbContextOptions<DbAccess> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
