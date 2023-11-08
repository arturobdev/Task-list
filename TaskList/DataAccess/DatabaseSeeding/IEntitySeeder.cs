using Microsoft.EntityFrameworkCore;

namespace TaskList.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder) 
        { }
    }
}
