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
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AbonnementsAPi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        private readonly AbonnementsAPIContext _context;
        private readonly IEmployerService _employerService;

        public EmployersController(AbonnementsAPIContext context,IEmployerService employerService)
        {
            _context = context;
            _employerService = employerService;
        }

        // GET: api/Employers
        [HttpGet]
        public IEnumerable<Employer> GetEmployer()
        {
            return _context.Employer;
        }

        // GET: api/Employers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employer = await _context.Employer.FindAsync(id);

            if (employer == null)
            {
                return NotFound();
            }

            return Ok(employer);
        }

        // GET: api/Employers/login/haymes
        [HttpGet("login/{login}")]
        public async Task<IActionResult> GetEmployerbyLogin([FromRoute] string login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employer =
                (from e in _context.Employer
                where e.empLogin == login
                select e).FirstOrDefault();

            if (employer == null)
            {
                return NotFound();
            }

            return Ok(employer);
        }

        // PUT: api/Employers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployer([FromRoute] int id, [FromBody] Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employer.empId)
            {
                return BadRequest();
            }

            _context.Entry(employer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
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

        // POST: api/Employers/authenticate
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]Employer empParam)
        {
            string test = (from c in _context.Employer
                           where c.empLogin == empParam.empLogin
                           select c.empPassword).FirstOrDefault();

            if (test != null)
            {


                if(SaltPassword.ComparePassword(test, empParam.empPassword))
                {
                    var emp = _employerService.Authenticate(empParam.empLogin, test);

                    if (emp == null)
                        return BadRequest(new { message = "Username or password is incorrect" });

                    await _context.SaveChangesAsync();

                    emp.empPassword = null;

                    return Ok(emp);
                }
                else
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }

            }
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        // POST: api/Employers
        [HttpPost]
        public async Task<IActionResult> PostEmployer([FromBody] Employer employer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employer.Add(employer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployer", new { id = employer.empId }, employer);
        }

        // DELETE: api/Employers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employer = await _context.Employer.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }

            _context.Employer.Remove(employer);
            await _context.SaveChangesAsync();

            return Ok(employer);
        }

        private bool EmployerExists(int id)
        {
            return _context.Employer.Any(e => e.empId == id);
        }
    }
}