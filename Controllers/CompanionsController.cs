using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanionsController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public CompanionsController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki companionit
        [HttpGet]
        [Route("")]
        public List<Companion> GetAllCompanions()
        {
            List<Companion> companions = db.Companions.ToList();

            return companions.ToList();
        }

        // Hakee deckId:n perusteella
        [HttpGet]
        [Route("deckid/{deckId}")]
        public async Task<ActionResult<IEnumerable<Companion>>> GetCardByDeckId(int deckId)
        {
            var cards = await (from c in db.Companions
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
                                   a.ImageUris,
                                   c.LoginId
                               }).ToListAsync();

            return Ok(cards);
        }

        // Hakee companion nimen perusteella
        [HttpGet]
        [Route("{name}")]
        public List<Companion> GetCompanionByName(string name)
        {
            var companions = from c in db.Companions
                             join a in db.AllCards on c.Id equals a.Id
                             join d in db.Decks on c.DeckId equals d.DeckId
                             where a.Name == name
                             select c;

            return companions.ToList();
        }

        // Lisää uuden companion
        [HttpPost]
        [Route("")]
        public ActionResult PostCreateNewCompanion([FromBody] Companion companion)
        {
            try
            {
                db.Companions.Add(companion);
                db.SaveChanges();

                return Ok(companion.Id); // Palauttaa luodun companion id:n
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

        // Päivittää olemassa olevan companion
        [HttpPut]
        [Route("{id}")]
        public ActionResult PutEdit(int id, [FromBody] Companion companion)
        {
            try
            {
                Companion com = db.Companions.Find(id);
                if (com != null)
                {
                    com.DeckId = companion.DeckId;
                    com.Id = companion.Id;
                    com.Count = companion.Count;

                    db.SaveChanges();
                    return Ok(com.Id); // Palauttaa id:n, jos kaikki meni onnistuneesti
                }
                else
                {
                    return NotFound("Companion not found!");
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

        // Poistaa companion
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCompanion(int id)
        {
            Companion companion = db.Companions.Find(id);
            if (companion != null)
            {
                db.Companions.Remove(companion);
                db.SaveChanges();
                return Ok("A companion deleted with id: " + id + ".");
            }
            else
            {
                return NotFound("Companion not found with id: " + id + ".");
            }
        }
    }
}
