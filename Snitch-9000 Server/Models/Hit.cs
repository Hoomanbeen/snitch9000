using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace snitch_9000.Models
{
    public class Hit
    {
        [Key]
        public int hit_id { get; set; }
        [Required]
        public string link { get; set; }
        [Required]
        public Question question { get; set; }
    }
}