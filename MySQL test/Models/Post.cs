using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_test.Models
{
    public class Post
    {
        [Key]
        public int IdPost { get; set; }
        public string Title { get; set; }
    }
}
