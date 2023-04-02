using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snitch_9000.Models;

namespace snitch_9000.DTOs
{
    public class StandaloneHitDTO
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string keywords { get; set; }
    }
}