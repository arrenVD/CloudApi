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
        public List<Animal> GetAllAnimals(string conservationStatus, string order, int? page, int length = 2)
        {
            IQueryable<Animal> query = context.Animals;

            if (!string.IsNullOrWhiteSpace(conservationStatus))
                query = query.Where(d => d.ConservationStatus == conservationStatus);
            if (!string.IsNullOrWhiteSpace(order))
                query = query.Where(d => d.Order == order);
            return query.ToList();
        }
        [HttpPost]
        public IActionResult CreateAnimal([FromBody] Animal newAnimal)
        {
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
            OrgAnimal.Name = updateAnimal.Name;
            OrgAnimal.ConservationStatus = updateAnimal.ConservationStatus;
            OrgAnimal.Description = updateAnimal.Description;
            OrgAnimal.ImageURL = updateAnimal.ImageURL;
            OrgAnimal.LifeSpan = updateAnimal.LifeSpan;
            return null;
        }
    }
}