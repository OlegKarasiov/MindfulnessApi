using Microsoft.EntityFrameworkCore;
using MindfulnessApi.Data;
using MindfulnessApi.Models;
using MindfulnessApi.Services.Interfaces;
using Newtonsoft.Json;

namespace MindfulnessApi.Services.Implimentations
{
    public class TestService : ITestService
    {
        private readonly ApiDbContext _context;

        public TestService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task StartTestSeedingAsync()
        {
            var json = File.ReadAllText(@"TestsJson/test.json");
            var TestObject = JsonConvert.DeserializeObject<Test>(json);
            if (TestObject != null)
            {
                _context.Tests.RemoveRange(_context.Tests);
                _context.Options.RemoveRange(_context.Options);
                _context.Questions.RemoveRange(_context.Questions);
                _context.Results.RemoveRange(_context.Results);

                await _context.AddAsync(TestObject);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<TestResult>> GetAllTestsAsync()
        {
            return await _context.Tests.Select(x => new TestResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).ToListAsync();
        }

        public async Task<Test> GetTestAsync(int testId)
        {
            return await _context.Tests.Include(x => x.Questions).ThenInclude(x => x.Options).Where(x => x.Id == testId).Select(x => new Test
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Questions = x.Questions,
                Results = x.Results
            }).FirstOrDefaultAsync();
        }

        public async Task<ResultResponse> GetTestResultAsync(int testId, List<TestAnswer> testAnswer)
        {
            var test = await _context.Tests.Include(x => x.Questions).ThenInclude(x => x.Options).Where(x => x.Id == testId).Select(x => new Test
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Questions = x.Questions,
                Results = x.Results
            }).FirstOrDefaultAsync();

            if (test != null)
            {
                var scoreSum = 0;

                foreach (var question in test.Questions)
                {
                    var options = question.Options;
                    var optionId = testAnswer.Where(x => x.QuestionId == question.Id).FirstOrDefault().OptionId;
                    scoreSum += options.FirstOrDefault(x => x.Id == optionId).Score;
                }

                foreach (var result in test.Results)
                {
                    if (scoreSum >= result.Min && scoreSum <= result.Max)
                    {
                        return new ResultResponse
                        {
                            Title = result.Title,
                            Description = result.Description
                        };
                    }
                }
            }

            return new ResultResponse();
        }
    }
}
