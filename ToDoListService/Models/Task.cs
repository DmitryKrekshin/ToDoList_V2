using System.ComponentModel.DataAnnotations;

namespace ToDoListService
{
    public class Task
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }
    }
}