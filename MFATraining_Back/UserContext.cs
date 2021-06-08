using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace MFA_Training
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source =" + Path.Combine(Directory.GetCurrentDirectory(), "UserDatabase.db"));
    }

    public class User
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string create_date { get; set; }
        public string password { get; set; }
    }
}