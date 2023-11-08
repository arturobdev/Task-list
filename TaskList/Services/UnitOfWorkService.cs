using TaskList.DataAccess;
using TaskList.Repository;

namespace TaskList.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;

        public TodoRepository TodoRepository { get; set; }

        public UnitOfWorkService(ContextDB contextDB)
        {
            _contextDB = contextDB;
            TodoRepository = new TodoRepository(contextDB);
        }
        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();
        }
    }
}
