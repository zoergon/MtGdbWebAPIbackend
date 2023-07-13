using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SideboardsController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public SideboardsController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki kortit sideboardista
        [HttpGet]
        [Route("")]
        public List<Sideboard> GetAllCards()
        {
            List<Sideboard> side = db.Sideboards.ToList();

            return side.ToList();
        }

        // Hakee deckId:n perusteella
        [HttpGet]
        [Route("deckid/{deckId}")]
        public async Task<ActionResult<IEnumerable<Sideboard>>> GetCardByDeckId(int deckId)
        {
            var cards = await (from s in db.Sideboards
                               join a in db.AllCards on s.Id equals a.Id
                               join d in db.Decks on s.DeckId equals d.DeckId
                               where s.DeckId == deckId
                               select new
                               {
                                   s.IndexId,
                                   s.DeckId,
                                   s.Id,
                                   a.Name,
                                   a.SetName,
                                   Deck = d.Name,
                                   s.Count,
                                   a.ImageUris,
                                   s.LoginId
                               }).ToListAsync();

            return Ok(cards);
        }

        // Hakee kortin nimen perusteella
        [HttpGet]
        [Route("{name}")]
        public List<Sideboard> GetCardByName(string name)
        {
            var cards = from s in db.Sideboards
                        join a in db.AllCards on s.Id equals a.Id
                        join d in db.Decks on s.DeckId equals d.DeckId
                        where a.Name == name
                        select s;

            return cards.ToList();
        }

        // Lisää uuden kortin
        [HttpPost]
        [Route("")]
        public ActionResult PostCreateNewCard([FromBody] Sideboard card)
        {
            try
            {
                db.Sideboards.Add(card);
                db.SaveChanges();

                return Ok(card.Id); // Palauttaa luodun kortin id:n
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

        // Päivittää olemassa olevan kortin
        [HttpPut]
        [Route("{id}")]
        public ActionResult PutEdit(int id, [FromBody] Sideboard card)
        {
            try
            {
                Sideboard sc = db.Sideboards.Find(id);
                if (sc != null)
                {
                    sc.DeckId = card.DeckId;
                    sc.Id = card.Id;
                    sc.Count = card.Count;

                    db.SaveChanges();
                    return Ok(sc.Id); // Palauttaa id:n, jos kaikki meni onnistuneesti
                }
                else
                {
                    return NotFound("Card not found!");
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

        // Poistaa kortin
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCard(int id)
        {
            Sideboard card = db.Sideboards.Find(id);
            if (card != null)
            {
                db.Sideboards.Remove(card);
                db.SaveChanges();
                return Ok("A card deleted with id: " + id + ".");
            }
            else
            {
                return NotFound("Card not found with id: " + id + ".");
            }
        }
    }
}
