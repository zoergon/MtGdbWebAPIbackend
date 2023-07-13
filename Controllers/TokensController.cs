using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public TokensController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki token-kortit
        [HttpGet]
        [Route("")]
        public List<Token> GetAllCards()
        {
            List<Token> token = db.Tokens.ToList();

            return token.ToList();
        }

        // Hakee deckId:n perusteella
        [HttpGet]
        [Route("deckid/{deckId}")]
        public async Task<ActionResult<IEnumerable<Token>>> GetCardByDeckId(int deckId)
        {
            var cards = await (from t in db.Tokens
                               join a in db.AllCards on t.Id equals a.Id
                               join d in db.Decks on t.DeckId equals d.DeckId
                               where t.DeckId == deckId
                               select new
                               {
                                   t.IndexId,
                                   t.DeckId,
                                   t.Id,
                                   a.Name,
                                   a.SetName,
                                   Deck = d.Name,
                                   t.Count,
                                   a.ImageUris,
                                   t.LoginId
                               }).ToListAsync();

            return Ok(cards);
        }

        // Hakee token-kortin nimen perusteella
        [HttpGet]
        [Route("{name}")]
        public List<Token> GetCardByName(string name)
        {
            var cards = from t in db.Tokens
                        join a in db.AllCards on t.Id equals a.Id
                        join d in db.Decks on t.DeckId equals d.DeckId
                        where a.Name == name
                        select t;

            return cards.ToList();
        }

        // Lisää uuden token-kortin
        [HttpPost]
        [Route("")]
        public ActionResult PostCreateNewCard([FromBody] Token card)
        {
            try
            {
                db.Tokens.Add(card);
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

        // Päivittää olemassa olevan token-kortin
        [HttpPut]
        [Route("{id}")]
        public ActionResult PutEdit(int id, [FromBody] Token card)
        {
            try
            {
                Token token = db.Tokens.Find(id);
                if (token != null)
                {
                    token.DeckId = card.DeckId;
                    token.Id = card.Id;
                    token.Count = card.Count;

                    db.SaveChanges();
                    return Ok(token.Id); // Palauttaa id:n, jos kaikki meni onnistuneesti
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

        // Poistaa token-kortin
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCard(int id)
        {
            Token card = db.Tokens.Find(id);
            if (card != null)
            {
                db.Tokens.Remove(card);
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
