using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snitch_9000.Models;

namespace snitch_9000.DTOs
{
    public class PostDTO
    {
        public string title { get; set; }
        public string content { get; set; }
        public string keywords { get; set; }
        public List<String> courses { get; set; }
        public string tags { get; set; }
        public DateTime start_date { get; set; }
    }
}