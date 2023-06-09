using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMagic.Models
{
    public class TVShowList
    {
        public int page { get; set; }
        public List<TVShow> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
