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
            return _context.Cabs;
        }

        // GET stone by id 
        [HttpGet("{id}")]
        public ActionResult<Stone> GetById(int id)
        {
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
            _context.Add(stone);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = stone.id }, stone);
        }

    }
}