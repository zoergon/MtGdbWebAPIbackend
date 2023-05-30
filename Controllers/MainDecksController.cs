using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtGdbWebAPIbackend.Models;
using System.Collections;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainDecksController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public MainDecksController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki kortit main deckistä
        //[HttpGet]
        //[Route("")]
        //public List<MainDeck> GetAllCards()
        //{
        //    List<MainDeck> main = db.MainDecks.ToList();

        //    return main;
        //}

        // Hakee kaikki ja tekee joinin id:n ja deck_id:n perusteella
        [HttpGet]
        [Route("")]
        //public List<MainDeck> GetAllCards()
        public object GetAllCards() // Muutettu objectiksi. Voiko tästä seurata mahdollisia ongelmia myöhemmin?
        {
            //List<MainDeck> md = new List<MainDeck>();

            var cards = (from m in db.MainDecks
                         join a in db.AllCards on m.Id equals a.Id
                         join d in db.Decks on m.DeckId equals d.DeckId
                         select new {
                             m.IndexId,
                             m.DeckId,
                             m.Id,
                             a.Name,
                             a.SetName,
                             Deck = d.Name,
                             m.Count,
                             m.LoginId
                         }).ToList();           

            return cards;
        }

        // Hakee deckId:n perusteella
        [HttpGet]
        [Route("deckid/{deckId}")]
        public async Task<ActionResult<IEnumerable<MainDeck>>> GetCardByDeckId(int deckId)
        {
            var cards = await (from m in db.MainDecks
                               join a in db.AllCards on m.Id equals a.Id
                               join d in db.Decks on m.DeckId equals d.DeckId
                               where m.DeckId == deckId
                               select new
                               {
                                   m.IndexId,
                                   m.DeckId,
                                   m.Id,
                                   a.Name,
                                   a.SetName,
                                   Deck = d.Name,
                                   m.Count,
                                   m.LoginId
                               }).ToListAsync();

            //var cards = await db.MainDecks.Where(x => x.DeckId == deckId)
            //    //.Include(dek  => dek.Deck.Name)
            //    .ToListAsync();

            //var cards = await db.MainDecks
            //    .Where(i => i.DeckId == deckId)
            //    .Select(i => new
            //    {
            //        i.DeckId
            //    }).ToArrayAsync();
            //.Include(d => d.Deck.Name)
            //.ToArrayAsync();

            return Ok(cards);
        }

        // Hakee kortin nimen perusteella
        [HttpGet]
        [Route("{name}")]
        public List<MainDeck> GetCardByName(string name)
        {
            var cards = from m in db.MainDecks
                             join a in db.AllCards on m.Id equals a.Id
                             join d in db.Decks on m.DeckId equals d.DeckId
                             where a.Name == name
                             select m;

            return cards.ToList();
        }

        // Lisää uuden kortin
        [HttpPost]
        [Route("")]
        public ActionResult PostCreateNewCard([FromBody] MainDeck card)
        {
            try
            {
                db.MainDecks.Add(card);
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
        public ActionResult PutEdit(int id, [FromBody] MainDeck card)
        {
            try
            {
                MainDeck mc = db.MainDecks.Find(id);
                if (mc != null)
                {
                    mc.DeckId = card.DeckId;
                    mc.Id = card.Id;
                    mc.Count = card.Count;
                    mc.LoginId = card.LoginId;

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
            MainDeck card = db.MainDecks.Find(id);
            if (card != null)
            {
                db.MainDecks.Remove(card);
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
