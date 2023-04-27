using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPI_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public LoginsController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var users = db.Logins;

            // Nollataan tilapäisesti salasanat haetuista tuloksista
            foreach (var user in users)
            {
                user.Password = null;
            }
            return Ok(users);
        }

        // Uuden käyttäjän lisääminen
        [HttpPost]
        public ActionResult PostCreateNew([FromBody] Login u)
        {
            try
            {
                db.Logins.Add(u);
                db.SaveChanges();
                return Ok("Created a new user " + u.Username);
            }
            catch (Exception e)
            {
                return BadRequest("Error with creating new user: " + e);
            }
        }
    }
}
