using MtGdbWebAPIbackend.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MtGdbWebAPIbackend.Services.Interfaces;

namespace MtGdbWebAPIbackend.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        // Depency Injection -tyyli
        private readonly MtGdbContext db;

        private readonly AppSettings _appSettings;

        // Depency Injection tietokantakonteksti välittyy toisena parametrina tässä
        public AuthenticateService(IOptions<AppSettings> appSettings, MtGdbContext mtgdbc)
        {
            _appSettings = appSettings.Value;
            db = mtgdbc;
        }

        //private MtGdbContext db = new MtGdbContext();

        //Metodin paluutyyppi on LoggedUser -luokan mukainen olio
        public LoggedUser? Authenticate(string username, string password)
        {
            var foundUser = db.Logins.SingleOrDefault(x => x.Username == username && x.Password == password);

            //Jos käyttäjää ei löydy, palautetaan null
            if (foundUser == null)
            {
                return null;
            }

            //Jos käyttäjä löytyy:
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, foundUser.LoginId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(1), //Montako päivää token on voimassa

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoggedUser loggedUser = new LoggedUser();

            loggedUser.Username = foundUser.Username;
            loggedUser.LoginId = foundUser.LoginId;
            loggedUser.AccesslevelId = foundUser.AccesslevelId;
            loggedUser.Token = tokenHandler.WriteToken(token);

            return loggedUser; // Palautetaan kutsuvalle controllerimetodille user ilman salasanaa
        }
    }
}
