using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_test.Models
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        [ForeignKey("Company")]
        public int IdCompany { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
