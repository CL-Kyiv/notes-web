using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Notes");
        }
    }
}
