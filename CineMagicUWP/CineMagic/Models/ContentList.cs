using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMagic.Models
{
    public class ContentList
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<TopElementHeader> TopElement { get; set; }
    }
    public class TopElementHeader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundImage { get; set; }
        public string TileImage { get; set; }
        public string Type { get; set; }
    }
}
