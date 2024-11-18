using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using tsx_react_project.Models;

namespace tsx_react_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JewelryController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public JewelryController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Jewelry> GetJewelry()
        {
            return _context.JewelryPieces.Include(prop => prop.stones);
        }

        // GET jewelry by id 
        [HttpGet("{id}")]
        public async Task<Jewelry> GetById(int id)
        {
           List <Jewelry> jewelry = await _context.JewelryPieces
                .Include(prop => prop.stones)
                .ToListAsync();
            
            return jewelry.Find(piece => piece.id == id);
        }

        // post jewelry object
        [HttpPost]
        public IActionResult PostJewelry(Jewelry jewelry)
        {
            _context.Add(jewelry);
            _context.SaveChanges(); 
            return CreatedAtAction(nameof(GetById), new { id = jewelry.id }, jewelry);
        }
    }
}