using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloudApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CloudApi.Controllers
{
    [Route("api/v1/animals")]
    [Authorize("read:animals")]
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
            //TODO: eventueel paginas in frontend toevoegen, momenteel geen prioriteit. length = 500 is een snelle "workaround"
            if (length == 0)
            {
                length = 500;
            }
            IQueryable<Animal> query = context.Animals.Include(a=> a.Family);
            AnimalList AnimalList = new AnimalList();
            AnimalList.Animal = query.ToArray();
            AnimalList.AmountOfAnimals = AnimalList.Animal.Length;
            double res = (double)AnimalList.AmountOfAnimals / (double)length;
            AnimalList.AmountOfPages = (int)Math.Ceiling(Convert.ToDouble(res));
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
                            query = query.OrderBy(a => a.ConservationStatus);
                        else if (dir == "desc")
                            query = query.OrderByDescending(a => a.ConservationStatus);
                        break;
                    case "order":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.Order);
                        else if (dir == "desc")
                            query = query.OrderByDescending(a => a.Order);
                        break;
                    case "family":
                        if (dir == "asc")
                            query = query.OrderBy(a => a.FamilyId);
                        else if (dir == "desc")
                            query = query.OrderByDescending(a => a.FamilyId);
                        break;
                    case "name":
                        if (dir == "asc")
                            query = query.OrderBy(a => a.Name);
                        else if (dir == "desc")
                            query = query.OrderByDescending(a => a.Name);
                        break;
                }
            }
            if (page.HasValue)
                query = query.Skip(page.Value * length);
            query = query.Take(length);

            AnimalList.Animal = query.ToArray();
            return AnimalList;
            //return query.ToList();


        }
        [HttpPost]
        public IActionResult CreateAnimal([FromBody] Animal newAnimal)
        {
            Animal tempAnimal = new Animal();
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