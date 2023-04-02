using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snitch_9000.Models;
using System.ComponentModel.DataAnnotations;

namespace snitch_9000.DTOs
{
    public class PostInDTO
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        public string keywords { get; set; }
    }
}