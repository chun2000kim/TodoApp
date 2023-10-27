using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required()]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

    }
}
