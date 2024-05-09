using Microsoft.AspNetCore.Mvc;
using MindfulnessApi.Data;
using MindfulnessApi.Models;
using Newtonsoft.Json;

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

        [HttpPost("[action]")]
        public async Task<IActionResult> SeedTests()
        {
            try
            {

                var json = System.IO.File.ReadAllText(@"TestsJson/test.json");
                var TestObject = JsonConvert.DeserializeObject<Test>(json);
                if (TestObject != null)
                {

                    _context.Tests.RemoveRange(_context.Tests);
                    _context.Options.RemoveRange(_context.Options);
                    _context.Questions.RemoveRange(_context.Questions);
                    _context.Results.RemoveRange(_context.Results);
                    _context.SaveChanges();

                    _context.Add(TestObject);
                    _context.SaveChanges();

                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTests()
        {
            try
            {
                var allTests = _context.Tests.Select(x => new TestResult
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                }).ToList();

                return Ok(allTests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{testId:int}")]
        public async Task<IActionResult> GetTest(int testId)
        {
            try
            {
                var test = _context.Tests.Where(x => x.Id == testId).Select(x => new Test
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Questions = x.Questions,
                    Results = x.Results
                }).ToList();

                return Ok(test);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{testId:int}")]
        public async Task<IActionResult> GetTestResult(int testId, [FromBody] List<TestAnswer> testAnswer)
        {
            try
            {
                var test = _context.Tests.Where(x => x.Id == testId).Select(x => new Test
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Questions = x.Questions,
                    Results = x.Results
                }).FirstOrDefault();

                var scoreSum = 0;

                //foreach (var question in test.Questions)
                //{

                //}

                return Ok(test);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

