using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaybeboardsController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public MaybeboardsController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki kortit maybeboardista
        [HttpGet]
        [Route("")]
        public List<Maybeboard> GetAllCards()
        {
            List<Maybeboard> main = db.Maybeboards.ToList();

            return main.ToList();
        }

        // Hakee kortin nimen perusteella
        [HttpGet]
        [Route("{name}")]
        public List<Maybeboard> GetCardByName(string name)
        {
            var cards = from m in db.Maybeboards
                        join a in db.AllCards on m.Id equals a.Id
                        join d in db.Decks on m.DeckId equals d.DeckId
                        where a.Name == name
                        select m;

            return cards.ToList();
        }

        // Lisää uuden kortin
        [HttpPost]
        [Route("")]
        public ActionResult PostCreateNewCard([FromBody] Maybeboard card)
        {
            try
            {
                db.Maybeboards.Add(card);
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
        public ActionResult PutEdit(int id, [FromBody] Maybeboard card)
        {
            try
            {
                Maybeboard mc = db.Maybeboards.Find(id);
                if (mc != null)
                {
                    mc.DeckId = card.DeckId;
                    mc.Id = card.Id;
                    mc.Count = card.Count;

                    db.SaveChanges();
                    return Ok(mc.Id); // Palauttaa id:n, jos kaikki meni onnistuneesti
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
            Maybeboard card = db.Maybeboards.Find(id);
            if (card != null)
            {
                db.Maybeboards.Remove(card);
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
