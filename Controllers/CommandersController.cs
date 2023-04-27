using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Controllers;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandersController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public CommandersController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki commanderit
        [HttpGet]
        [Route("")]
        public List<Commander> GetAllDecks()
        {
            List<Commander> commanders = db.Commanders.ToList();

            //var commanders = from c in db.Commanders
            //                 join a in db.AllCards on c.Id equals a.Id
            //                 join d in db.Decks on c.DeckId equals d.DeckId                             
            //                 select c;

            return commanders.ToList();
        }

        // Hakee commanderin nimen perusteella
        [HttpGet]
        [Route("{name}")]
        public List<Commander> GetCommanderByName(string name)
        {
            var commanders = from c in db.Commanders
                        join a in db.AllCards on c.Id equals a.Id
                        join d in db.Decks on c.DeckId equals d.DeckId
                        where a.Name == name
                        select c;

            return commanders.ToList();
        }

        // Lisää uuden commanderin
        [HttpPost]
        [Route("")]
        public ActionResult PostCreateNewCommander([FromBody] Commander commander)
        {
            try
            {
                db.Commanders.Add(commander);
                db.SaveChanges();

                return Ok(commander.Id); // Palauttaa luodun commanderin id:n
            }
            catch (Exception e)
            {

                return BadRequest("Something went wrong: " + e);
            }
            finally
            {
                db.Dispose();
            }
        }

        // Päivittää olemassa olevan commanderin
        [HttpPut]
        [Route("{id}")]
        public ActionResult PutEdit(int id, [FromBody] Commander commander)
        {
            try
            {
                Commander com = db.Commanders.Find(id);
                if (com != null)
                {
                    com.DeckId = commander.DeckId;
                    com.Id = commander.Id;
                    com.Count = commander.Count;

                    db.SaveChanges();
                    return Ok(com.Id); // Palauttaa id:n, jos kaikki meni onnistuneesti
                }
                else
                {
                    return NotFound("Commander not found!");
                }
            }
            catch (Exception e)
            {

                return BadRequest("Something went wrong: " + e);
            }
            finally
            {
                db.Dispose();
            }
        }

        // Poistaa commanderin
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCommander(int id)
        {
            Commander commander = db.Commanders.Find(id);
            if (commander != null)
            {
                db.Commanders.Remove(commander);
                db.SaveChanges();
                return Ok("A commander deleted with id: " + id + ".");
            }
            else
            {
                return NotFound("Commander not found with id: " + id + ".");
            }
        }
    }
}
