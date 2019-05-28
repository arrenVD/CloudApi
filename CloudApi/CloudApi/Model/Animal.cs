using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApi.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Kingdom { get; set; }
        public string Order { get; set; }
    }
}
