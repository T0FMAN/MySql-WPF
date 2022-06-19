using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MySQL_test.Models;
using System.Windows;
using System.Configuration;

namespace MySQL_test.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public AppDbContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConn = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;

            optionsBuilder.UseMySql(stringConn, new MySqlServerVersion(new Version(8, 0, 29)));
        }
    }
}
