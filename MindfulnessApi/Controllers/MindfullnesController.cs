using Microsoft.AspNetCore.Mvc;
using MindfulnessApi.Models;
using MindfulnessApi.Services.Interfaces;

namespace MindfulnessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MindfullnesController : ControllerBase
    {
        private readonly IMindfulnessService _mindfulnessService;

        public MindfullnesController(IMindfulnessService mindfulnessService)
        {
            _mindfulnessService = mindfulnessService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetMindfullnes([FromBody] QuestionsRequest questions)
        {
            try
            {
                var mindfulness = _mindfulnessService.GenerateMindfullnesAsync(questions);

                return Ok(mindfulness);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
