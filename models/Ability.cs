using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dota2API.models
{
    public class Ability
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string LocalizedName { get; set; }
        
        public string Description { get; set; }
        
        public string AbilityType { get; set; }
        
        public string Affects { get; set; }
        
        public string Damage { get; set; }
        
        public string ImageUrl { get; set; }
        
        public string ManaCost { get; set; }
        
        public string Cooldown { get; set; }
        
        public int HeroId { get; set; }
        
        [ForeignKey("HeroId")]
        public virtual Hero Hero { get; set; }
    }
}