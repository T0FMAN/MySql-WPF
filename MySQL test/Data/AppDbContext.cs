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
        public DbSet<Company>? Companies { get; set; }

        public AppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConn = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;

            optionsBuilder.UseMySql(stringConn, new MySqlServerVersion(new Version(8, 0, 29)));
        }

        static string GetStringConn()
        {
            var path = Environment.CurrentDirectory;

            var stringConnection = string.Empty;

            try
            {
                var xDoc = new XmlDocument();
                xDoc.Load(path + "\\config.xml");
                var xRoot = xDoc.DocumentElement;

                if (xRoot != null)
                {
                    foreach (XmlElement xnode in xRoot)
                    {
                        var attr = xnode.Attributes.GetNamedItem("name")!;
                        if (attr.Value == "MySql") 
                        {
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                if (childnode.Name == "connection")
                                {
                                    stringConnection = childnode.InnerText;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            return stringConnection;
        }
    }
}
