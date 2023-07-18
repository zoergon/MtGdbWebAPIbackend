using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        //private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        private readonly MtGdbContext db;

        public DecksController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki deckit
        [HttpGet]
        [Route("")]
        public List<Deck> GetAllDecks()
        {
            List<Deck> decks = db.Decks
                .Include(cmdr => cmdr.Commanders)
                .Include(comp => comp.Companions)
                .Include(md => md.MainDecks)
                .Include(mb => mb.Maybeboards)
                .Include(sb => sb.Sideboards)
                .Include(t => t.Tokens)
                .Include(f => f.Format)
                .ToList();

            return decks;
        }
        //[HttpGet]
        //[Route("")]
        //public object GetAllDecks()
        //{
        //    var decks = db.Decks.Include(md => md.MainDecks).ToList();

        //    return decks;
        //}

        // Hakee deckin nimen perusteella
        [HttpGet]
        [Route("name/{name}")]
        public List<Deck> GetDeckByName(string name)
        {
            var decks = from c in db.Decks
                           where c.Name == name
                           select c;

            return decks.ToList();
        }

        // Hakee deckien formaatin perusteella
        [HttpGet]
        [Route("format/{format}")]
        public List<Deck> GetDeckByFormat(string format)
        {
            var decks = from c in db.Decks
                        join f in db.Formats on c.FormatId equals f.FormatId
                        where f.FormatName == format
                        select c;

            return decks.ToList();
        }

        // Luo uuden deckin
        [HttpPost]
        [Route("")]
        public ActionResult PostCreateNewDeck([FromBody] Deck deck)
        {
            try
            {
                db.Decks.Add(deck);
                db.SaveChanges();

                return Ok(deck.DeckId); // Palauttaa vasta luodun uuden deckin deck_id:n
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

        // Päivittää olemassa olevan deckin
        [HttpPut]
        [Route("{id}")]
        public ActionResult PutEdit(int id, [FromBody] Deck deck)
        {
            try
            {
                Deck dek = db.Decks.Find(id);
                if (dek != null)
                {
                    dek.Name = deck.Name;
                    dek.FormatId = deck.FormatId;
                    dek.LoginId = deck.LoginId;

                    db.SaveChanges();
                    return Ok(dek.DeckId); // Palauttaa deck_id:n, jos kaikki meni onnistuneesti
                }
                else
                {
                    return NotFound("Deck not found!");
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

        // Poistaa deckin
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteDeck(int id)
        {
            Deck deck = db.Decks.Find(id);
            if (deck != null)
            {
                db.Decks.Remove(deck);
                db.SaveChanges();
                return Ok("A deck deleted with deck_id: " + id + ".");
            }
            else
            {
                return NotFound("Deck not found with deck_id: " + id + ".");
            }
        }
    }
}
