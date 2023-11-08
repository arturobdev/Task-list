using Microsoft.EntityFrameworkCore;
using TaskList.DataAccess;
using TaskList.DTOs;
using TaskList.Entities;
using TaskList.Services;

namespace TaskList.Repository
{
    public class TodoRepository : Repository<Todo>
    {
        public TodoRepository(ContextDB contextDB) : base(contextDB) { }

        public async Task<List<Todo>> GetAllTasks()
        {
            try
            {
                return await _contextDB.Todos.ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<Todo?> GetById(int id)
        {
            try
            {
                return await _contextDB.Todos.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
        public async Task<bool> InserTask(TaskDTO taskDTO)
        {
            try
            {
                var todo = new Todo();
                todo = taskDTO;

                return await base.Insert(todo);
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public async Task<bool> UpdateTask(int id, TaskDTO taskDTO)
        {
            try
            {
                var todo = new Todo();
                todo = taskDTO;
                todo.Id = id;
                todo.IsCompleted = taskDTO.IsCompleted;

                return await base.Update(todo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                var todo = await GetById(id);
                todo.IsCompleted = true;

                return await base.Update(todo);
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
    }
}
