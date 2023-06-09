using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMagic.Models
{
    public class Person
    {
        public bool adult { get; set; }
        public string[] also_known_as { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }
        public object deathday { get; set; }
        public int gender { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string place_of_birth { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }

        // ------------ custom formatted data -----------------
        public string _gender
        {
            get
            {
                if (gender == 0)
                    return "man";
                else
                    return "woman";
            }
        }
        public string _deathday
        {
            get
            {
                if (deathday == null)
                    return "-";
                else
                    return "${deathday}";
            }
        }
        public MovieCredits movieCredits { get; set; }
        public TVCredits tvCredits { get; set; }
        public string backgroundImage { get; set; }
    }

    public class PeopleCredits
    {
        public int id { get; set; }
        public List<Cast> cast { get; set; }
        public List<Crew> crew { get; set; }
    }

    public class Cast
    {
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }
        public int cast_id { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int order { get; set; }
    }
    
    public class Crew
    {
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }
        public string credit_id { get; set; }
        public string department { get; set; }
        public string job { get; set; }
    }
}
