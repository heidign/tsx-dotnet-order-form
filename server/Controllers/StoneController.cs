using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tsx_react_project.Models;
using Microsoft.EntityFrameworkCore;

namespace tsx_react_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoneController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public StoneController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Stone> GetStone()
        {
            // return _context.Cabs;
            return _context.Cabs.Include(stone => stone.jewelry);
        }

        // GET stone by id 
        [HttpGet("{id}")]
        public ActionResult<Stone> GetById(int id)
        {
            // Stone stone = _context.Cabs.Find(id);
            Stone stone = _context.Cabs.SingleOrDefault(s => s.id == id);

            if (stone is null)
            {
                return NotFound();
            }
            return stone;
        }

        // post stone object
        [HttpPost]
        public IActionResult PostStone(Stone stone)
        {
            // telling the db context to find the jewelry id of the posted stone
            // attaching the jewelry id to the stone
            stone.jewelry = _context.JewelryPieces.Find(stone.jewelryId);
            // adding the stone to the db context
            _context.Add(stone);
            // saving changes to the db
            _context.SaveChanges();
            // creating new id for the stone
            return CreatedAtAction(nameof(GetById), new { id = stone.id }, stone);
        }
    }
}