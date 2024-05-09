using Microsoft.EntityFrameworkCore;
using MindfulnessApi.Models;

namespace MindfulnessApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Option> Options { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Define entity relationships, indexes, etc.
        }
    }
}
