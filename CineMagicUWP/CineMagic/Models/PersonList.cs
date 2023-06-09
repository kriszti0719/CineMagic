﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMagic.Models
{
    public class PersonList
    {
        public int page { get; set; }
        public List<Person> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
