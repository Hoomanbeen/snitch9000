using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace snitch_9000.Models
{
    public class Notification
    {
        [Key]
        public int notification_id { get; set; }
        [Required]
        public User user { get; set; }
        [Required]
        public Question question { get; set; }
        [Required]
        public Hit hit { get; set; }
    }
}