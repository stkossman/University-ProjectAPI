using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dota2API.Data;
using Dota2API.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dota2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HeroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
        {
            return await _context.Heroes.ToListAsync();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            var hero = await _context.Heroes
                .Include(h => h.Abilities)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        // POST: api/Heroes
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHero), new { id = hero.Id }, hero);
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroExists(int id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }

    // Controllers/AbilitiesController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AbilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Abilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ability>>> GetAbilities()
        {
            return await _context.Abilities.ToListAsync();
        }

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ability>> GetAbility(int id)
        {
            var ability = await _context.Abilities.FindAsync(id);

            if (ability == null)
            {
                return NotFound();
            }

            return ability;
        }

        // GET: api/Abilities/Hero/5
        [HttpGet("Hero/{heroId}")]
        public async Task<ActionResult<IEnumerable<Ability>>> GetAbilitiesByHero(int heroId)
        {
            return await _context.Abilities
                .Where(a => a.HeroId == heroId)
                .ToListAsync();
        }

        // POST: api/Abilities
        [HttpPost]
        public async Task<ActionResult<Ability>> PostAbility(Ability ability)
        {
            _context.Abilities.Add(ability);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAbility), new { id = ability.Id }, ability);
        }

        // PUT: api/Abilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbility(int id, Ability ability)
        {
            if (id != ability.Id)
            {
                return BadRequest();
            }

            _context.Entry(ability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilityExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Abilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbility(int id)
        {
            var ability = await _context.Abilities.FindAsync(id);
            if (ability == null)
            {
                return NotFound();
            }

            _context.Abilities.Remove(ability);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbilityExists(int id)
        {
            return _context.Abilities.Any(e => e.Id == id);
        }
    }

    // Controllers/ItemsController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}