using Microsoft.EntityFrameworkCore;
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

        public static void StartTestSeeding()
        {
            var json = File.ReadAllText(@"TestsJson/test.json");
            var TestObject = JsonConvert.DeserializeObject<Test>(json);
            if (TestObject != null)
            {

                var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
                var conn = "User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=SampleDriverDb;";

                optionsBuilder.UseNpgsql(conn);

                using (var context = new ApiDbContext(optionsBuilder.Options))
                {
                    context.Database.EnsureCreated();
                    context.Tests.RemoveRange(context.Tests);
                    context.Answers.RemoveRange(context.Answers);
                    context.Questions.RemoveRange(context.Questions);
                    context.Results.RemoveRange(context.Results);
                    context.SaveChanges();

                    context.Add(TestObject);
                    context.SaveChanges();
                }
            }
        }
    }
}
