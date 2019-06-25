using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbonnementsAPi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AbonnementsAPi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            string cliId = User.FindFirst(ClaimTypes.Email)?.Value;
            if (int.Parse(cliId) == id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var abonnements =
                    from a in _context.Abonnements
                    where a.aboFKCli == id
                    where a.aboDateFin > DateTime.Now
                    select a;

                if (abonnements == null)
                {
                    return NotFound();
                }

                return Ok(abonnements);
            }
            else
            {
                return Unauthorized();
            }
        }

        //GET: api/Abonnements/clientNonAbo/5
        [HttpGet("clientNonAbo/{id}")]
        public async Task<IActionResult> GetNonAboByCli([FromRoute] int id)
        {
            string cliId = User.FindFirst(ClaimTypes.Email)?.Value;
            if (int.Parse(cliId) == id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var abonnements =
                    from m in _context.Magazines
                    where  !(from ab in _context.Abonnements
                            where ab.aboFKCli == id
                            where ab.aboDateFin > DateTime.Now
                            select ab.aboFKMag)
                           .Contains(m.magId)
                           
                    select m;

    //            SELECT distinct "magTitre" FROM public."Magazines" left join public."Abonnements" on "magId" = "magId" WHERE "magId" not in (
                        //select "aboFKMag" from public."Abonnements" WHERE "aboFKCli" = 15 AND "aboDateFin" > NOW())



                if (abonnements == null)
                {
                    return NotFound();
                }

                return Ok(abonnements.Distinct());
            }
            else
            {
                return Unauthorized();
            }
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