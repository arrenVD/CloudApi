using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloudApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CloudApi.Controllers
{
    [Route("api/v1/animals")]
    [ApiController]
    public class AnimalsController : Controller
    {
        private readonly LibraryContext context;
        public AnimalsController(LibraryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        //public List<Animal> GetAllAnimals(string conservationStatus, string order,string family ,string sort, int length = 5 , string dir = "asc" ,int? page = 0)
        public AnimalList GetAllAnimals(string conservationStatus, string order, string family, string sort, int length, string dir = "asc", int? page = 0)
        {
            if (length == 0)
            {
                length = 500;
            }
            IQueryable<Animal> query = context.Animals.Include(d => d.Family);
            AnimalList Animal = new AnimalList();
            Animal.Animal = query.ToArray();
            Animal.AmountOfAnimals = Animal.Animal.Length;
            double res = (double)Animal.AmountOfAnimals / (double)length;
            Animal.AmountOfPages = (int)Math.Ceiling(Convert.ToDouble(res));
            if (!string.IsNullOrWhiteSpace(conservationStatus) && conservationStatus != "All")
                query = query.Where(d => d.ConservationStatus == conservationStatus);
            if (!string.IsNullOrWhiteSpace(order) && order != "All")
                query = query.Where(d => d.Order == order);
            if (!string.IsNullOrWhiteSpace(order) && family != "All")
                query = query.Where(d => d.Family.Name == family);


            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "conservationstatus":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.ConservationStatus);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.ConservationStatus);
                        break;
                    case "order":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.Order);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.Order);
                        break;
                    case "family":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.FamilyId);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.FamilyId);
                        break;
                    case "name":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.Name);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.Name);
                        break;
                }
            }
            if (page.HasValue)
                query = query.Skip(page.Value * length);
            query = query.Take(length);

            Animal.Animal = query.ToArray();
            return Animal;
            //return query.ToList();


        }
        [HttpPost]
        public IActionResult CreateAnimal([FromBody] Animal newAnimal)
        {
            Animal tempAnimal = new Animal();
            /*Family tempFamily = new Family();
            Animal tempAnimal = new Animal();
            tempAnimal.ConservationStatus = newAnimal.ConservationStatus;
            tempAnimal.Description = newAnimal.Description;
            tempAnimal.ImageURL = newAnimal.ImageURL;
            tempAnimal.LifeSpan = newAnimal.LifeSpan;
            tempAnimal.Name = newAnimal.Name;
            tempAnimal.Order = newAnimal.Order;
            tempFamily.Description = newAnimal.Family.Description;
            tempFamily.Name = newAnimal.Family.Name;
            tempAnimal.Family = tempFamily;
            context.Animals.Add(tempAnimal);
            context.SaveChanges();
            return Created("", tempAnimal);*/
            string tempname = newAnimal.Family.Name;


                newAnimal.Family = context.Families.SingleOrDefault(d => d.Name == newAnimal.Family.Name);
                if(newAnimal.Family == null)
            {

                var family = new Family()
                {
                    Name = tempname,
                    Description = "",

                };
                context.Families.Add(family);
                context.SaveChanges();
                newAnimal.Family = context.Families.SingleOrDefault(d => d.Name == tempname);
                System.Diagnostics.Debug.WriteLine("Created: "+ newAnimal.Family.Name);
            }

            context.Animals.Add(newAnimal);
            context.SaveChanges();
            return Created("", newAnimal);
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetAnimal(int id)
        {
            //var animal = context.Animals.(id);
            //if (animal == null) { return NotFound(); } else { return Ok(animal); }
            var animal = context.Animals.Include(d => d.Family).SingleOrDefault(d => d.Id == id);
            if (animal == null) { return NotFound(); } else { return Ok(animal); }
        }
        [Route("{id}/family")]
        [HttpGet]
        public ActionResult<Animal> GetAnimalFamily(int id)
        {
            //var animal = context.Animals.(id);
            //if (animal == null) { return NotFound(); } else { return Ok(animal); }
            var animal = context.Animals.Include(d => d.Family).SingleOrDefault(d => d.Id == id);
            if (animal == null) { return NotFound(); } else { return Ok(animal.Family); }
        }
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = context.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            else
            {
                context.Animals.Remove(animal);
                context.SaveChanges();
                return NoContent();
            }                      
        }
        [HttpPut]
        public IActionResult UpdateAnimal([FromBody] Animal updateAnimal)
        {
            var OrgAnimal = context.Animals.Find(updateAnimal.Id);
            if(OrgAnimal == null)
            {
                return NotFound();
            }
            else
            {
                OrgAnimal.Name = updateAnimal.Name;
                OrgAnimal.ConservationStatus = updateAnimal.ConservationStatus;
                OrgAnimal.Description = updateAnimal.Description;
                OrgAnimal.ImageURL = updateAnimal.ImageURL;
                OrgAnimal.LifeSpan = updateAnimal.LifeSpan;
                context.SaveChanges();
                return Ok(OrgAnimal);
            }
        }
    }
}