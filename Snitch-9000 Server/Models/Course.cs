using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace snitch_9000.Models
{
    public class Course
    {
        [Key]
        public string course_id { get; set; }
        public IEnumerable<Question> question { get; set; }
        public IEnumerable<User> user { get; set; }
    }
}
