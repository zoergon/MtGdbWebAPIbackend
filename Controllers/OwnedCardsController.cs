using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnedCardsController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public OwnedCardsController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki OwnedCards-taulukon kortit
        [HttpGet]
        [Route("")]
        public List<OwnedCard> GetAllCards()
        {
            List<OwnedCard> cards = db.OwnedCards
                .Include(ac => ac.IdNavigation)
                .ToList();

            return cards;

        }

        //[HttpGet]
        //[Route("id/{id}")]
        //public async Task<ActionResult<IEnumerable<OwnedCard>>> GetById(string id)
        //{
        //    var cards = await (from o in db.OwnedCards
        //                       join a in db.AllCards on o.Id equals a.Id
        //                       where o.Id == id
        //                       select new
        //                       {
        //                           o.IndexId,
        //                           o.Id,
        //                           a.Name,
        //                           a.SetName,
        //                           o.Count,
        //                           a.ImageUris,
        //                           o.LoginId
        //                       }).ToListAsync();

        //    return Ok(cards);
        //}

        // Hakee id:n mukaisen yhden kortin
        [HttpGet]
        [Route("id/{id}")]
        public async Task<ActionResult<IEnumerable<OwnedCard>>> GetOneCardById(string id)
        {
            var cards = await db.OwnedCards.
                               Where(o => o.Id == id)
                               .Include(ac => ac.IdNavigation)
                               .ToListAsync();

            return Ok(cards);
        }

        // Hakee kortin nimen perusteella kaikki hakutulokset
        [HttpGet]
        [Route("name/{name}")]
        public async Task<ActionResult<IEnumerable<OwnedCard>>> GetByName(string name)
        {
            var cards = await (from o in db.OwnedCards
                               join a in db.AllCards on o.Id equals a.Id
                               where a.Name == name
                               select new
                               {
                                   o.IndexId,
                                   o.Id,
                                   a.Name,
                                   a.SetName,
                                   o.Count,
                                   a.ImageUris,
                                   o.LoginId
                               }).ToListAsync();
            return Ok(cards);
        }

                // Hakee kortin nimen perusteella kaikki hakutulokset
        [HttpGet]
        [Route("partialname/{key}")]
        public List<OwnedCard> GetPartialName(string key) // Hakee osittaisella nimen perusteella
        {
            var cards = from o in db.OwnedCards
                        join a in db.AllCards on o.Id equals a.Id
                        where (a.Name.ToUpper().Contains(key.ToUpper()))
                        select o;

            return cards.ToList();
        }

        // Lisää uuden kortin
        [HttpPost]
        [Route("")]
        public ActionResult PostCreateNewCard([FromBody] OwnedCard card)
        {
            try
            {
                db.OwnedCards.Add(card);
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
        public ActionResult PutEdit(int id, [FromBody] OwnedCard card)
        {
            try
            {
                OwnedCard oc = db.OwnedCards.Find(id);
                if (oc != null)
                {                    
                    oc.Id = card.Id;
                    oc.Count = card.Count;
                    oc.LoginId = card.LoginId;

                    db.SaveChanges();
                    return Ok(oc.Id); // Palauttaa id:n, jos kaikki meni onnistuneesti
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
            OwnedCard card = db.OwnedCards.Find(id);
            if (card != null)
            {
                db.OwnedCards.Remove(card);
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
