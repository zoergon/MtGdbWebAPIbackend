using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtGdbWebAPIbackend.Models;

namespace MtGdbWebAPI_backend.Controllers
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
    }
}
