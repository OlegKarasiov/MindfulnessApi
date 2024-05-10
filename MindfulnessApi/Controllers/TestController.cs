using Microsoft.AspNetCore.Mvc;
using MindfulnessApi.Models;
using MindfulnessApi.Services.Interfaces;

namespace MindfulnessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost("seed-tests")]
        public async Task<IActionResult> SeedTests()
        {
            try
            {
                await _testService.StartTestSeedingAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tests")]
        public async Task<IActionResult> GetAllTests()
        {
            try
            {
                var allTests = await _testService.GetAllTestsAsync();

                return Ok(allTests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tests/{testId:int}")]
        public async Task<IActionResult> GetTest(int testId)
        {
            try
            {
                var test = await _testService.GetTestAsync(testId);

                return Ok(test);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("tests/{testId:int}/get-results")]
        public async Task<IActionResult> GetTestResult(int testId, [FromBody] List<TestAnswer> testAnswer)
        {
            try
            {
                var result = await _testService.GetTestResultAsync(testId, testAnswer);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

