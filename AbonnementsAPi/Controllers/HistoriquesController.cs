using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbonnementsAPi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AbonnementsAPi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriquesController : ControllerBase
    {
        private readonly AbonnementsAPIContext _context;

        public HistoriquesController(AbonnementsAPIContext context)
        {
            _context = context;
        }

        // GET: api/Historiques
        [HttpGet]
        public IEnumerable<Historique> GetHistorique()
        {
            return _context.Historique;
        }

        // GET: api/Historiques/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistorique([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historique = await _context.Historique.FindAsync(id);

            if (historique == null)
            {
                return NotFound();
            }

            return Ok(historique);
        }

        // GET: api/Historiques/client/5
        [HttpGet("client/{id}")]
        public async Task<IActionResult> GetHistoriqueByCli([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historique = from h in _context.Historique
                                   where h.hisFKCli == id
                                   select h;

            if (historique == null)
            {
                return NotFound();
            }

            return Ok(historique);
        }

        // GET: api/Historiques/employer/5
        [HttpGet("employer/{id}")]
        public async Task<IActionResult> GetHistoriqueByEmp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historique = from h in _context.Historique
                             where h.hisFKEmp == id
                             select h;

            if (historique == null)
            {
                return NotFound();
            }

            return Ok(historique);
        }

        // PUT: api/Historiques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorique([FromRoute] int id, [FromBody] Historique historique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historique.hisId)
            {
                return BadRequest();
            }

            _context.Entry(historique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriqueExists(id))
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

        // POST: api/Historiques
        [HttpPost]
        public async Task<IActionResult> PostHistorique([FromBody] Historique historique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Historique.Add(historique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorique", new { id = historique.hisId }, historique);
        }

        // DELETE: api/Historiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorique([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historique = await _context.Historique.FindAsync(id);
            if (historique == null)
            {
                return NotFound();
            }

            _context.Historique.Remove(historique);
            await _context.SaveChangesAsync();

            return Ok(historique);
        }

        private bool HistoriqueExists(int id)
        {
            return _context.Historique.Any(e => e.hisId == id);
        }
    }
}