using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
