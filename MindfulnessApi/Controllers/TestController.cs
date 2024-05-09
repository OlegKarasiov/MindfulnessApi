using Microsoft.AspNetCore.Mvc;
using MindfulnessApi.Data;
using MindfulnessApi.Services;

namespace MindfulnessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TestController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "SeedTests")]
        public async Task<IActionResult> Post()
        {

            try
            {
                TestSeeding.StartTestSeeding();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
