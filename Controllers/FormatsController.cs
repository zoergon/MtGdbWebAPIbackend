using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPIbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private readonly MtGdbContext db = new MtGdbContext();

        // Depency Injection -tyyli
        //private readonly MtGdbContext db;

        public FormatsController(MtGdbContext dbparam)
        {
            db = dbparam;
        }

        // Hakee kaikki deckit
        [HttpGet]
        [Route("")]
        public List<Format> GetAll()
        {
            List<Format> formats = db.Formats
                //.Include(cmdr => cmdr.Commanders)
                //.Include(comp => comp.Companions)
                //.Include(md => md.MainDecks)
                //.Include(mb => mb.Maybeboards)
                //.Include(sb => sb.Sideboards)
                //.Include(t => t.Tokens)
                .ToList();

            return formats;
        }
    }
}
