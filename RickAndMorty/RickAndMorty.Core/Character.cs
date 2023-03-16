﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Core
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Species {get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

        public OriginLocation Origin { get; set;}
        
        public OriginLocation Location { get; set; }
        
        public string Image { get; set; }

        public List<string> Episode{ get; set; }

        public string Url { get; set; }

      public DateTime Created { get; set; }

    }
}
