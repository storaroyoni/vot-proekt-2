using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YourNamespace.Data;
using YourNamespace.Models;
using System.Linq;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YourEntityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<YourEntityController> _logger;

        public YourEntityController(ApplicationDbContext context, ILogger<YourEntityController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entities = _context.YourEntities.ToList();
            return Ok(entities);
        }

        [HttpPost]
        public IActionResult Post([FromBody] YourEntity entity)
        {
            _context.YourEntities.Add(entity);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }
    }
}
