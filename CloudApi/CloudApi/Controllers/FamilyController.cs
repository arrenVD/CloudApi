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
    [Route("api/v1/families")]
    [ApiController]
    public class FamilyController : Controller
    {
        private readonly LibraryContext context;
        public FamilyController(LibraryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Family> GetAllFamilies()
        {
            return context.Families.ToList();
        }
        [HttpPost]
        public IActionResult CreateFamily([FromBody] Family newFamily)
        {
            context.Families.Add(newFamily);
            context.SaveChanges();
            return Created("", newFamily);
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetFamily(int id)
        {
            var family = context.Families.Find(id);
            if (family == null) { return NotFound(); } else { return Ok(family); }

        }
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteFamily(int id)
        {
            var family = context.Families.Find(id);
            if (family == null)
            {
                return NotFound();
            }
            else
            {
                context.Families.Remove(family);
                context.SaveChanges();
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdateFamily([FromBody] Family updateFamily)
        {
            var OrgFamily = context.Families.Find(updateFamily.Id);
            if (OrgFamily == null)
            {
                return NotFound();
            }
            OrgFamily.Name = updateFamily.Name;
            OrgFamily.Description = updateFamily.Description;
            return null;
        }
        [Route("{id}/animal")]
        [HttpGet]
        public ActionResult<Family> GetFamilyAnimals(int id)
        {
            //var animal = context.Animals.(id);
            //if (animal == null) { return NotFound(); } else { return Ok(animal); }
            var family = context.Families.Include(d => d.Animals).SingleOrDefault(d => d.Id == id);
            if (family == null) { return NotFound(); } else { return Ok(family.Animals); }
        }
    }
}