using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dota2API.models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string LocalizedName { get; set; }
        
        public string Description { get; set; }
        
        public int Cost { get; set; }
        
        public bool IsRecipe { get; set; }
        
        public string ShopTags { get; set; }
        
        public string Attributes { get; set; }
        
        public string ImageUrl { get; set; }
    }
}