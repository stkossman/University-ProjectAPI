using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dota2API.models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string LocalizedName { get; set; }
        
        public string PrimaryAttribute { get; set; }
        
        public string AttackType { get; set; }
        
        public string Roles { get; set; }
        
        public int BaseHealth { get; set; }
        
        public int BaseMana { get; set; }
        
        public float BaseArmor { get; set; }
        
        public int MoveSpeed { get; set; }
        
        public float BaseAttackMin { get; set; }
        
        public float BaseAttackMax { get; set; }
        
        public int BaseStrength { get; set; }
        
        public float StrengthGain { get; set; }
        
        public int BaseAgility { get; set; }
        
        public float AgilityGain { get; set; }
        
        public int BaseIntelligence { get; set; }
        
        public float IntelligenceGain { get; set; }
        
        public string ImageUrl { get; set; }
        
        public List<Ability>? Abilities { get; set; } = new List<Ability>();
    }
}