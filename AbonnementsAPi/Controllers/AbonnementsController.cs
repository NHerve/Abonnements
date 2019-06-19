using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbonnementsAPi.Models;

namespace AbonnementsAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonnementsController : ControllerBase
    {
        private readonly AbonnementsAPIContext _context;

        public AbonnementsController(AbonnementsAPIContext context)
        {
            _context = context;
        }

        // GET: api/Abonnements
        [HttpGet]
        public IEnumerable<Abonnements> GetAbonnements()
        {
            return _context.Abonnements;
        }

        // GET: api/Abonnements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbonnements([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var abonnements = await _context.Abonnements.FindAsync(id);

            if (abonnements == null)
            {
                return NotFound();
            }

            return Ok(abonnements);
        }

        // GET: api/Abonnements/client/5
        [HttpGet("client/{id}")]
        public async Task<IActionResult> GetAboByCli([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var abonnements = await _context.Abonnements.FindAsync(id);
            var abonnements =  await _context.Abonnements.Where(x => x.aboFKCli == id).ToListAsync();

            if (abonnements == null)
            {
                return NotFound();
            }

            return Ok(abonnements);
        }

        //GET: api/Abonnements/clientNonAbo/5
        [HttpGet("clientNonAbo/{id}")]
        public async Task<IActionResult> GetNonAboByCli([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var abonnements =
                from m in _context.Magazines
                where (from a in _context.Abonnements
                       where a.aboFKCli == id
                       where a.aboDateFin < DateTime.Now
                       select a.aboFKMag)
                       .Contains(m.magId)
                select m;

            var abo = from m2 in _context.Magazines
                      join ab in _context.Abonnements on m2.magId equals ab.aboFKMag into t
                      from su in t.DefaultIfEmpty()
                      where su.aboFKCli == null
                      select m2;

            var result = abo.Union(abonnements);



            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Abonnements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbonnements([FromRoute] int id, [FromBody] Abonnements abonnements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abonnements.aboId)
            {
                return BadRequest();
            }

            _context.Entry(abonnements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonnementsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Abonnements
        [HttpPost]
        public async Task<IActionResult> PostAbonnements([FromBody] Abonnements abonnements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Abonnements.Add(abonnements);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbonnements", new { id = abonnements.aboId }, abonnements);
        }

        // DELETE: api/Abonnements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbonnements([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var abonnements = await _context.Abonnements.FindAsync(id);
            if (abonnements == null)
            {
                return NotFound();
            }

            _context.Abonnements.Remove(abonnements);
            await _context.SaveChangesAsync();

            return Ok(abonnements);
        }

        private bool AbonnementsExists(int id)
        {
            return _context.Abonnements.Any(e => e.aboId == id);
        }
    }
}