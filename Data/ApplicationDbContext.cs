using Microsoft.EntityFrameworkCore;
using Dota2API.models;

namespace Dota2API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>()
                .HasOne(a => a.Hero)
                .WithMany(h => h.Abilities)
                .HasForeignKey(a => a.HeroId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            modelBuilder.Entity<Hero>()
                .HasMany(h => h.Abilities)
                .WithOne(a => a.Hero)
                .HasForeignKey(a => a.HeroId)
                .OnDelete(DeleteBehavior.Cascade);

            // anti-mage hero
            modelBuilder.Entity<Hero>().HasData(
                new Hero
                {
                    Id = 1,
                    Name = "anti-mage",
                    LocalizedName = "Anti-Mage",
                    PrimaryAttribute = "Agi",
                    AttackType = "Melee",
                    Roles = "Carry,Escape,Nuker",
                    BaseHealth = 200,
                    BaseMana = 75,
                    BaseArmor = 0,
                    MoveSpeed = 310,
                    BaseAttackMin = 29,
                    BaseAttackMax = 33,
                    BaseStrength = 23,
                    StrengthGain = 1.3f,
                    BaseAgility = 24,
                    AgilityGain = 2.8f,
                    BaseIntelligence = 12,
                    IntelligenceGain = 1.8f,
                    ImageUrl = "https://api.opendota.com/apps/dota2/images/heroes/antimage_full.png"
                }
            );

            // anti-mage skills
            modelBuilder.Entity<Ability>().HasData(
                new Ability
                {
                    Id = 1,
                    Name = "mana_break",
                    LocalizedName = "Mana Break",
                    Description = "Burns an opponent's mana on each attack and deals damage equal to a percentage of the mana burned.",
                    AbilityType = "Passive",
                    Affects = "Enemy Heroes",
                    Damage = "Physical",
                    ManaCost = "0",
                    Cooldown = "0",
                    HeroId = 1,
                    ImageUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/abilities/antimage_mana_break.png"
                },
                new Ability
                {
                    Id = 2,
                    Name = "blink",
                    LocalizedName = "Blink",
                    Description = "Short distance teleportation that allows Anti-Mage to move in and out of combat.",
                    AbilityType = "Active",
                    Affects = "Self",
                    Damage = "None",
                    ManaCost = "60",
                    Cooldown = "15/12/9/6",
                    HeroId = 1,
                    ImageUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/abilities/antimage_blink.png"
                },
                new Ability
                {
                    Id = 3,
                    Name = "counterspell",
                    LocalizedName = "Counterspell",
                    Description = "Passively grants magic resistance. When activated, creates an anti-magic shell around Anti-Mage that reflects targeted spells.",
                    AbilityType = "Active",
                    Affects = "Self",
                    Damage = "None",
                    ManaCost = "45/50/55/60",
                    Cooldown = "15/11/7/3",
                    HeroId = 1,
                    ImageUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/abilities/antimage_counterspell.png"
                },
                new Ability
                {
                    Id = 4,
                    Name = "mana_void",
                    LocalizedName = "Mana Void",
                    Description = "Creates a violent ripple in space that drains mana and deals damage to enemies near the target based on their missing mana.",
                    AbilityType = "Active",
                    Affects = "Enemy Units",
                    Damage = "Magical",
                    ManaCost = "100/200/300",
                    Cooldown = "70",
                    HeroId = 1,
                    ImageUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/abilities/antimage_mana_void.png"
                }
            );
        }
    }
}