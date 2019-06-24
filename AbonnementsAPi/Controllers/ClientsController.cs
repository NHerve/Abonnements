using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbonnementsAPi.Models;
using Microsoft.AspNetCore.Authorization;
using AbonnementsAPi.Services;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace AbonnementsAPi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AbonnementsAPIContext _context;
        private readonly IClientService _clientService;

        public ClientsController(AbonnementsAPIContext context, IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Clients> Getclients()
        {
            return _clientService.GetAll();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClients([FromRoute] int id)
        {
            string cliId = User.FindFirst(ClaimTypes.Email)?.Value;
            if(int.Parse(cliId) == id)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var clients = await _context.clients.FindAsync(id);

                if (clients == null)
                {
                    return NotFound();
                }

                return Ok(clients);
            }
            else
            {
                return Unauthorized();
            }
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClients([FromRoute] int id, [FromBody] Clients clients)
        {
            string cliId = User.FindFirst(ClaimTypes.Email)?.Value;
            if (int.Parse(cliId) == id)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != clients.cliId)
                {
                    return BadRequest();
                }

                _context.Entry(clients).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientsExists(id))
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
            else
            {
                return Unauthorized();
            }
        }

        // POST: api/Clients/authenticate
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]Clients cliParam)
        {
            var cli = _clientService.Authenticate(cliParam.cliMail, cliParam.cliPassword);

            if (cli == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            
            await _context.SaveChangesAsync();

            cli.cliPassword = null;

            return Ok(cli);
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> PostClients([FromBody] Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.clients.Add(clients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClients", new { id = clients.cliId }, clients);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClients([FromRoute] int id)
        {
            string cliId = User.FindFirst(ClaimTypes.Email)?.Value;
            if (int.Parse(cliId) == id)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var clients = await _context.clients.FindAsync(id);
                if (clients == null)
                {
                    return NotFound();
                }

                _context.clients.Remove(clients);
                await _context.SaveChangesAsync();

                return Ok(clients);
            }
            else
            {
                return Unauthorized();
            }
        }

        private bool ClientsExists(int id)
        {
            return _context.clients.Any(e => e.cliId == id);
        }

    }
}