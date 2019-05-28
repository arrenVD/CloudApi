﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApi.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Family Family { get; set; }
        public string Description { get; set; }
        public int LifeSpan { get; set; }
    
        public string ConservationStatus {get;set;}
    }



}
