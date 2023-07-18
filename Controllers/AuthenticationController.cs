using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Services.Interfaces;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Credentials tunnukset)
        {
            var loggedUser = _authenticateService.Authenticate(tunnukset.Username, tunnukset.Password);

            if (loggedUser == null)
                return BadRequest(new { message = "Wrong username or password." });

            return Ok(loggedUser); //Palautus front endiin (sis. vain loggedUser-luokan mukaiset kentät)
        }
    }
}
