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
            string emp = User.FindFirst(ClaimTypes.Role)?.Value;

            if(int.Parse(cliId) == id || emp == "employer")
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
            string emp = User.FindFirst(ClaimTypes.Role)?.Value;

            if (int.Parse(cliId) == id || emp == "employer")
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != clients.cliId)
                {
                    return BadRequest();
                }

                if(clients.cliPassword == null)
                {
                    clients.cliPassword = (from c in _context.clients
                                                         where c.cliId == id
                                                         select c.cliPassword).FirstOrDefault();
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
            string test = (from c in _context.clients
                           where c.cliMail == cliParam.cliMail
                           select c.cliPassword).FirstOrDefault();

            if (test != null)
            {


                if(SaltPassword.ComparePassword(test, cliParam.cliPassword))
                {
                    var cli = _clientService.Authenticate(cliParam.cliMail, test);

                    if (cli == null)
                        return BadRequest(new { message = "Login ou mots de passe incorrect" });

                    await _context.SaveChangesAsync();

                    cli.cliPassword = null;

                    return Ok(cli);
                }
                else
                {
                    return BadRequest(new { message = "Login ou mots de passe incorrect" });
                }

            }
            return BadRequest(new { message = "Login ou mots de passe incorrect" });
        }

        // POST: api/Clients
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostClients([FromBody] Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string cliPassword = clients.cliPassword;
            clients.cliPassword = SaltPassword.GetPasswordHash(clients.cliPassword);

            _context.clients.Add(clients);

            await _context.SaveChangesAsync();

            clients.cliPassword = cliPassword;

           await Authenticate(clients);

            clients.cliPassword = null;

            return CreatedAtAction("GetClients", new { id = clients.cliId }, clients);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClients([FromRoute] int id)
        {
            string cliId = User.FindFirst(ClaimTypes.Email)?.Value;
            string emp = User.FindFirst(ClaimTypes.Role)?.Value;

            if (int.Parse(cliId) == id || emp == "employer")
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