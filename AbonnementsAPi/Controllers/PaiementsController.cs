using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbonnementsAPi.Models;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using RestSharp;

namespace AbonnementsAPi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PaiementsController : ControllerBase
    {
        private readonly AbonnementsAPIContext _context;

        public PaiementsController(AbonnementsAPIContext context)
        {
            _context = context;
        }

        // GET: api/Paiements
        [HttpGet]
        public IEnumerable<Paiement> GetPaiement()
        {
            return _context.Paiement;
        }

        // GET: api/Paiements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaiement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paiement = await _context.Paiement.FindAsync(id);

            if (paiement == null)
            {
                return NotFound();
            }

            return Ok(paiement);
        }

        // PUT: api/Paiements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaiement([FromRoute] int id, [FromBody] Paiement paiement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paiement.uuid)
            {
                return BadRequest();
            }

            _context.Entry(paiement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiementExists(id))
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

        // POST: api/Paiements/request/idClient/idMagazine
        [HttpPost("request/{idClient}/{idMagazine}")]
        public async Task<IActionResult> PostPaiementRequest([FromBody] Paiement paiement, int idClient, int idMagazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RestClient client = new RestClient(new Uri(@"http://192.168.2.1:6543/cardpay/"));
            RestRequest request = new RestRequest($"{paiement.uuid}/{paiement.cid}/{paiement.cardNumber}/{paiement.cardMonth}/{paiement.cardYear}/{paiement.amount}") { Method = Method.GET };
            bool ok = client.Execute(request).StatusCode == HttpStatusCode.OK;

            if (ok)
            {
                Abonnements abo = new Abonnements(idClient, idMagazine);

                _context.Abonnements.Add(abo);
                await _context.SaveChangesAsync();


                paiement.paiFKAbo = abo.aboId;

                _context.Paiement.Add(paiement);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }
            return CreatedAtAction("GetPaiement", new { id = paiement.uuid }, paiement);
        }

        // POST: api/Paiements
        [HttpPost]
        public async Task<IActionResult> PostPaiement([FromBody] Paiement paiement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            //update abonnement where paiement.FkAbo = abo.id
            var abo = _context.Abonnements.FirstOrDefault(a => a.aboId == paiement.paiFKAbo);
            if(abo != null)
            {
                abo.aboStatus = 1;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaiement", new { id = paiement.uuid }, paiement);
        }

        // DELETE: api/Paiements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaiement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paiement = await _context.Paiement.FindAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }

            _context.Paiement.Remove(paiement);
            await _context.SaveChangesAsync();

            return Ok(paiement);
        }

        private bool PaiementExists(int id)
        {
            return _context.Paiement.Any(e => e.uuid == id);
        }
    }
}