using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace snitch_9000.Models
{
    public class Question
    {
        [Key]
        public int question_id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        public string keywords { get; set; }
        public ICollection<Course> courses { get; set; }
        public User user { get; set; }
        public DateTime start_date { get; set; }
        public string tags { get; set; }
    }
}