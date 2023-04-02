using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snitch_9000.Models;

namespace snitch_9000.DTOs
{
    public class HitDTO
    {
        public int id { get; set; }
        public int question_id { get; set; }
        public string user_id { get; set; }
        public DateTime date { get; set; }
    }
}