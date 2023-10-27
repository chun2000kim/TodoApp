using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Repository
{
    public class TodoRepository : ITodoRepository
    {
        public ApplicationDBContext _dbontext { get; }
        public TodoRepository(ApplicationDBContext dbontext) 
        {
            _dbontext = dbontext; 
        }
        public async Task<Todo> Add(Todo todo)
        {
            var addEntity = _dbontext.Todos.Add(todo);
            await _dbontext.SaveChangesAsync();

            return addEntity.Entity;
        }

        public async Task<Todo> Delete(int id)
        {
            var todoId = await GetById(id);
            if (todoId == null)
            {
                return null;
            }
            _dbontext.Todos.Remove(todoId);
            await _dbontext.SaveChangesAsync();

            return todoId;
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
           return await _dbontext.Todos.ToListAsync();
        }

        public async Task<Todo> GetById(int id)
        {
            return await _dbontext.Todos.FindAsync(id);
        }

        public async Task<Todo> Update(int id,Todo todo)
        {
            _dbontext.Entry(todo).State = EntityState.Modified;

            try
            {
                await _dbontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var findEmployee = await GetById(id);
                if (findEmployee == null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return todo;
        }
    }
}
