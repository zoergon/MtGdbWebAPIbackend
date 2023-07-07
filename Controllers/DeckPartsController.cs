using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckPartsController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public DeckPartsController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        [HttpGet]
        [Route("")]
        public List<DeckPart> GetAll()
        {
            List<DeckPart> parts = db.DeckParts
                //.Include(cmdr => cmdr.Commanders)
                //.Include(comp => comp.Companions)
                //.Include(md => md.MainDecks)
                //.Include(mb => mb.Maybeboards)
                //.Include(sb => sb.Sideboards)
                //.Include(t => t.Tokens)
                .ToList();

            return parts;
        }

        // Hakee formatin id:n perusteella nimen
        [HttpGet]
        [Route("id/{id}")]
        public List<DeckPart> GetDeckPart(int id)
        {
            var parts = from d in db.DeckParts
                          where d.PartId == id
                          select d;

            return parts.ToList();
        }
    }
}
