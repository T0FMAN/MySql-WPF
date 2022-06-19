using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_test.Models
{
    public class Location
    {
        [Key]
        public int IdCompany { get; set; }
        [Required(ErrorMessage = "Ошибочка")]
        public string Country { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
    }
}
