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
    public interface IClientService
    {
        Clients Authenticate(string cliMail, string cliPassword);
        IEnumerable<Clients> GetAll();
    }

    public class ClientService : IClientService
    {

        private readonly AppSettings _appSettings;
        private readonly AbonnementsAPIContext _context;

        public ClientService(IOptions<AppSettings> appSettings, AbonnementsAPIContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public Clients Authenticate(string cliMail, string cliPassword)
        {
            var cli = _context.clients.SingleOrDefault(x => x.cliMail == cliMail && x.cliPassword == cliPassword);

            // return null if user not found
            if (cli == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, cli.cliId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            cli.cliAuthKey = tokenHandler.WriteToken(token);

            // remove password before returning
            //cli.cliPassword = null;

            return cli;
        }

        public IEnumerable<Clients> GetAll()
        {
            // return users without passwords

            var cliList = from c in _context.clients
                          select new Clients { cliId = c.cliId, cliNom = c.cliNom, cliPrenom = c.cliPrenom, cliMail = c.cliMail, cliPhone = c.cliPhone, cliDateNaissance = c.cliDateNaissance, cliLieuNaissance = c.cliLieuNaissance, cliNumCart = c.cliNumCart, cliExpiCarte = c.cliExpiCarte, cliCCV = c.cliCCV, cliAuthKey = c.cliAuthKey };

            return cliList;

        }
    }
}
