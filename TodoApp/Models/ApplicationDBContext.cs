using Microsoft.EntityFrameworkCore;

namespace TodoApp.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }
    }
}
