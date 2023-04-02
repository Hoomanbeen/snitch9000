using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace snitch_9000.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public virtual ICollection<Course> courses { get; set; }
    }
}