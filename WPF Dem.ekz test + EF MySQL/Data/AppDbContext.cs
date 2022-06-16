using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WPF_Dem.ekz_test___EF_MySQL.Models;

namespace WPF_Dem.ekz_test___EF_MySQL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company>? Companies { get; set; }

        public AppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=password;database=companiesdb;",
                new MySqlServerVersion(new Version(8, 0, 29))
            );
        }
    }
}
