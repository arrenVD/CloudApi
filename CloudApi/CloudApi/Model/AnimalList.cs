using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApi.Model
{
    public class AnimalList
    {
        public int AmountOfAnimals;

        public Animal[] Animal;
        public int AmountOfPages = 2;
    }
    public class FamilyList
    {
        public Family[] Family;
    }
}
