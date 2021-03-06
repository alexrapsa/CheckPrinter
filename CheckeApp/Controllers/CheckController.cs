
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckeApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CheckeApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : Controller
    {
        private static readonly string[] Summaries = new[]
         {
            "Freezing", "Braaa  cing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CheckController> _logger;
        private readonly DataContext _context;
        public CheckController(DataContext dataContext, ILogger<CheckController> logger)
        {
            _logger = logger;
            _context = dataContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var checks = await _context.Checks.ToListAsync();
            

            return Ok(checks);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCheck(int id)
        {
            var check = await _context.Checks.FirstOrDefaultAsync(x=> x.Id == id);
            
            return Ok(check);
        }
    }
}