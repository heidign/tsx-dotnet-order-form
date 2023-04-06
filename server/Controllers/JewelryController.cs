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
            return _context.JewelryPieces;
        }

        // GET jewelry by id 
        [HttpGet("{id}")]
        public Jewelry GetById(int id)
        {
            Jewelry jewelry = _context.JewelryPieces.Find(id);

            if (jewelry is null)
            {
                return null;
            }
            return jewelry;
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