using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Dem.ekz_test___EF_MySQL.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
    }
}
