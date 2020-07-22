using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginSignupApp.DbContextFactory
{
    public class UserDbContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public UserDbContext() : base("UserModel")
        {
            //Create database always, even If exists
            Database.SetInitializer<UserDbContext>(new DropCreateDatabaseAlways<UserDbContext>());
        }
    }
}