using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Controllers;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPI_backend.Controllers
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

        //// Luo uuden deckin
        //[HttpPost]
        //[Route("")]
        //public ActionResult PostCreateNewDeck([FromBody] Deck deck)
        //{
        //    try
        //    {
        //        db.Decks.Add(deck);
        //        db.SaveChanges();

        //        return Ok(deck.DeckId); // Palauttaa vasta luodun uuden deckin deck_id:n
        //    }
        //    catch (Exception e)
        //    {

        //        return BadRequest("Something went wrong: " + e);
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //}

        //// Päivittää olemassa olevan deckin
        //[HttpPut]
        //[Route("{id}")]
        //public ActionResult PutEdit(int id, [FromBody] Deck deck)
        //{
        //    try
        //    {
        //        Deck dek = db.Decks.Find(id);
        //        if (dek != null)
        //        {
        //            dek.Name = deck.Name;
        //            dek.Format = deck.Format;

        //            db.SaveChanges();
        //            return Ok(dek.DeckId); // Palauttaa deck_id:n, jos kaikki meni onnistuneesti
        //        }
        //        else
        //        {
        //            return NotFound("Deck not found!");
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        return BadRequest("Something went wrong: " + e);
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //}

        //// Poistaa deckin
        //[HttpDelete]
        //[Route("{id}")]
        //public ActionResult DeleteDeck(int id)
        //{
        //    Deck deck = db.Decks.Find(id);
        //    if (deck != null)
        //    {
        //        db.Decks.Remove(deck);
        //        db.SaveChanges();
        //        return Ok("A deck deleted with deck_id: " + id + ".");
        //    }
        //    else
        //    {
        //        return NotFound("Deck not found with deck_id: " + id + ".");
        //    }
        //}
    }
}
