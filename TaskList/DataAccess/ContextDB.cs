using Microsoft.EntityFrameworkCore;
using TaskList.DataAccess.DatabaseSeeding;
using TaskList.Entities;

namespace TaskList.DataAccess
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        { }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new TodoSeeder()
        };

            foreach (var seeder in seeders)
            {
                seeder.SeedDataBase(modelBuilder);
            };

            base.OnModelCreating(modelBuilder);
        }
    }
}
