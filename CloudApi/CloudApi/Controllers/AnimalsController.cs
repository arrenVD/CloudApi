using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloudApi.Model;
using System.Linq;
namespace CloudApi.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]

    [Route("api/v1/animals")]
    public class AnimalsController : Controller
    {
        static List<Animal> AnimalList = new List<Animal>();

        [HttpGet]
        public List<Animal> GetAnimals()
        {
            return AnimalList;
        }
        [HttpPost]
        public IActionResult CreateAnimal([FromBody] Animal newAnimal)
        {
            //Dierenvriend!
            bool isEmpty = !AnimalList.Any();
            if (isEmpty)
            {
                newAnimal.Id = 1;
            }
            else
            {
                var LastId = AnimalList.Max(a => a.Id);
                newAnimal.Id = LastId + 1;
            }
            AnimalList.Add(newAnimal);
            return Created("", newAnimal);
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Animal> GetAnimal(int id)
        {
            var animal = AnimalList.FirstOrDefault(a => a.Id == id);
                  if (animal == null)
            {
                   return NotFound();
            }
              return animal;
        }   
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteAnimal(int id)
        {
            //Dierenbeul!
            var animal = AnimalList.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            AnimalList.Remove(animal);
            return NoContent();
        }
    }
}

