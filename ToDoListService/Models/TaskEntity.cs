using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListService
{
    public class TaskEntity
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string AuthorName { get; set; }

        public TaskStatus Status { get; set; }
        
        public DateTime CreateDate { get; set; }
    }
}