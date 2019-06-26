using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using AbonnementsAPi.Models;
using AbonnementsAPi.Helpers;

namespace AbonnementsAPi.Services
{
    public interface IEmployerService
    {
        Employer Authenticate(string empLogin, string empPassword);
        IEnumerable<Employer> GetAll();
    }

    public class EmployerService : IEmployerService
    {

        private readonly AppSettings _appSettings;
        private readonly AbonnementsAPIContext _context;

        public EmployerService(IOptions<AppSettings> appSettings, AbonnementsAPIContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public Employer Authenticate(string empLogin, string empPassword)
        {
            var emp = _context.Employer.SingleOrDefault(x => x.empLogin == empLogin && x.empPassword == empPassword);

            // return null if user not found
            if (emp == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, emp.empId.ToString()),
                    new Claim(ClaimTypes.Role, "employer")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            emp.empAuthKey = tokenHandler.WriteToken(token);

            // remove password before returning
            //cli.cliPassword = null;

            return emp;
        }

        public IEnumerable<Employer> GetAll()
        {
            // return users without passwords

            var empList = from c in _context.Employer
                          select new Employer { empId = c.empId, empAuthKey = c.empAuthKey, empLogin = c.empLogin };

            return empList;

        }
    }
}
