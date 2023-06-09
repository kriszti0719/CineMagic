using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMagic.Models
{
    public class Movie : Content
    {
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        public string imdb_id { get; set; }
        public string original_title { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public string title { get; set; }
        public bool video { get; set; }

        // ------------ custom formatted data -----------------
        public string _runtime
        {
            get
            {
                int hours = runtime / 60;
                int minutes = runtime % 60;

                if (hours == 0)
                {
                    return $"{minutes}m";
                }
                else if (minutes == 0)
                {
                    return $"{hours}h";
                }
                else
                {
                    return $"{hours}h {minutes}m";
                }
            }
        }
        public PeopleCredits credits { get; set; }
        public string backgroundImage { get; set; }
    }

    public class MovieCredits
    {
        public List<MovieCreditsCast> cast { get; set; }
        public List<MovieCreditsCrew> crew { get; set; }
        public int id { get; set; }
    }

    public class MovieCreditsCast
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int order { get; set; }
    }

    public class MovieCreditsCrew
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public string credit_id { get; set; }
        public string department { get; set; }
        public string job { get; set; }
    }
}
