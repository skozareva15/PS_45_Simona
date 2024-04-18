using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user = new DatabaseUser()
            {
                Id = 1,
                names = "John Doe",
                password = "1234",
                roles = UserRolesEnum.ADMIN,
                expires = DateTime.Now.AddYears(10),
            };

            var user2 = new DatabaseUser()
            {
                Id = 2,
                names = "Ivan Ivanov",
                password = "123",
                roles = UserRolesEnum.STUDENT,
                expires = DateTime.Now.AddYears(10),
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);
            modelBuilder.Entity<DatabaseUser>().HasData(user2);
        }

        public DbSet<DatabaseUser> Users { get; set; }
    }

}
