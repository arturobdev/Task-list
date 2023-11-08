using TaskList.Repository;

namespace TaskList.Services
{
    public interface IUnitOfWork
    {
        public TodoRepository TodoRepository { get; set; }

        public Task<int> Complete();
    }
}
