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

        // GET: api/Abilities/Hero/id
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
            ability.Hero = null;
            _context.Abilities.Add(ability);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAbility), new { id = ability.Id }, ability);
        }

        // PUT: api/Abilities/id
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

        // DELETE: api/Abilities/id
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
}