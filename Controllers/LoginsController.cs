using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        //private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        private readonly MtGdbContext db;

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
                return BadRequest("Error with creating a new user: " + e);
            }
        }

        // Käyttäjän muokkaaminen
        [HttpPut]
        [Route("{key}")]
        public ActionResult PutEdit(int key, [FromBody] Login u)
        {
            try
            {
                Login user = db.Logins.Find(key);
                if (user != null)
                {
                    user.FirstName = u.FirstName;
                    user.LastName = u.LastName;
                    user.Email = u.Email;
                    user.AccesslevelId = u.AccesslevelId;
                    user.Username = u.Username;
                    user.Password = u.Password;
                    user.Admin = u.Admin;

                    db.SaveChanges();
                    return Ok(user.LoginId); //jos kaikki meni ok, palauttaa login_id:n
                }
                else
                {
                    return NotFound("Username not found!");
                }
            }
            catch (Exception e)
            {

                return BadRequest("Something went wrong updating: " + e);
            }
            finally
            {
                db.Dispose();
            }
        }

        // Käyttäjän poistaminen
        [HttpDelete]
        [Route("{key}")]
        public ActionResult DeleteUser(int key)
        {
            Login user = db.Logins.Find(key);
            if (user != null)
            {
                db.Logins.Remove(user);
                db.SaveChanges();
                return Ok("Username " + key + " is deleted.");
            }
            else
            {
                return NotFound("Username " + key + " not found.");
            }
        }
    }
}
