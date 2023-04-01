using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tsx_react_project.Models
{
    public class Jewelry 
    {
        public int id { get; set; }

        [Required]
        public string Style { get; set; }

    }
}