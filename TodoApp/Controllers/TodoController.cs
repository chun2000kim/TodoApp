using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using TodoApp.Repository;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
        {
            return (await _todoRepository.GetAll()).ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetById(int id)
        {
            var todoId = await _todoRepository.GetById(id);
            if (todoId == null)
            {
                return NotFound();
            }
            return todoId;
        }
        [HttpPost]
        public async Task<ActionResult<Todo>> Save(Todo todo)
        {
            if (ModelState.IsValid)
            {
                await _todoRepository.Add(todo);
            }
            return CreatedAtAction(nameof(GetById), new { id  = todo.Id}, todo );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> UpdateTodo(int id, Todo todo)
        {
            //if (id != todo.Id)
            //{
            //    return NoContent();
            //}
            var model = await _todoRepository.Update(id, todo);
            if (model == null)
                return NotFound();
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> Delete(int id)
        {
            var todo = await _todoRepository.Delete(id);
            if (todo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
