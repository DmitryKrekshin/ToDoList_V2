using System;

namespace ToDoListWebApp
{
    public class TaskView
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string AuthorName { get; set; }

        public TaskStatusView Status { get; set; }
        
        public DateTime CreateDate { get; set; }
    }
}