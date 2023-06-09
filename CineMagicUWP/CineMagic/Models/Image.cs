using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMagic.Models
{

    public class Image
    {
        public List<Backdrop> backdrops { get; set; }
        public int id { get; set; }
        public List<Logo> logos { get; set; }
        public List<Poster> posters { get; set; }
        public List<Profile> profiles { get; set; }
    }

    public class Profile
    {
        public float aspect_ratio { get; set; }
        public int height { get; set; }
        public object iso_639_1 { get; set; }
        public string file_path { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }
    }

    public class Backdrop
    {
        public float aspect_ratio { get; set; }
        public int height { get; set; }
        public string iso_639_1 { get; set; }
        public string file_path { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }
    }

    public class Logo
    {
        public float aspect_ratio { get; set; }
        public int height { get; set; }
        public string iso_639_1 { get; set; }
        public string file_path { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }
    }

    public class Poster
    {
        public float aspect_ratio { get; set; }
        public int height { get; set; }
        public string iso_639_1 { get; set; }
        public string file_path { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }
    }
}
