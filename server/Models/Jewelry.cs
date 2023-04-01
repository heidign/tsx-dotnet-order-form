using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tsx_react_project.Models
{

    public enum JewelryKind
    {
        Ring, 
        Pendant, 
        Cuff
    }

    public enum JewelryMaterial 
    {
        SterlingSilver,
        Brass, 
        Copper
    }


    public class Jewelry 
    {
        public int id { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public JewelryKind piece { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public  JewelryMaterial material { get; set; }

        public Stone stone { get; set; }
        
    }

    
}