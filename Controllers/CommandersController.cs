using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult GetAllDecks()
        {
            //List<Commander> commanders = db.Commanders.ToList();

            var query = (from c in db.Commanders
                             join a in db.AllCards on c.Id equals a.Id
                             join d in db.Decks on c.DeckId equals d.DeckId
                             select new
                             {
                                 c.IndexId,
                                 d.DeckId,
                                 DeckName = d.Name,
                                 a.Id,
                                 a.Name,
                                 c.Count,
                                 c.LoginId
                             });

            var commanders = query.ToList();

            return Ok(commanders);
        }

        // Hakee deckId:n perusteella
        [HttpGet]
        [Route("deckid/{deckId}")]
        public async Task<ActionResult<IEnumerable<Commander>>> GetCardByDeckId(int deckId)
        {
            var cards = await (from c in db.Commanders
                               join a in db.AllCards on c.Id equals a.Id
                               join d in db.Decks on c.DeckId equals d.DeckId
                               where c.DeckId == deckId
                               select new
                               {
                                   c.IndexId,
                                   c.DeckId,
                                   c.Id,
                                   a.Name,
                                   a.SetName,
                                   Deck = d.Name,
                                   c.Count,
                                   c.LoginId
                               }).ToListAsync();

            return Ok(cards);
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
                    com.LoginId = commander.LoginId;

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
