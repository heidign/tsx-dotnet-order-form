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
        public ActionResult<Jewelry> GetById(int id)
        {
            Jewelry jewelry = _context.JewelryPieces.SingleOrDefault(j => j.id == id);

            if (jewelry is null)
            {
                return NotFound();
            }
            return jewelry;
        }


    }
}