using MindfulnessApi.Data;
using MindfulnessApi.Models;
using Newtonsoft.Json;

namespace MindfulnessApi.Services
{
    public class TestSeeding
    {
        private readonly ApiDbContext _context;

        public TestSeeding(ApiDbContext context)
        {
            _context = context;
        }

        public void StartTestSeeding()
        {
            var json = File.ReadAllText(@"TestsJson/test.json");
            var TestObject = JsonConvert.DeserializeObject<Test>(json);
            if (TestObject != null)
            {

                _context.Database.EnsureCreated();
                _context.Tests.RemoveRange(_context.Tests);
                _context.Options.RemoveRange(_context.Options);
                _context.Questions.RemoveRange(_context.Questions);
                _context.Results.RemoveRange(_context.Results);
                _context.SaveChanges();

                _context.Add(TestObject);
                _context.SaveChanges();

            }
        }
    }
}
