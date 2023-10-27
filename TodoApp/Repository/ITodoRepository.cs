using TodoApp.Models;

namespace TodoApp.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAll();
        Task<Todo> GetById(int id);
        Task<Todo> Add(Todo todo);
        Task <Todo> Update(int id,Todo todo);
        Task<Todo> Delete(int id);
    }
}
