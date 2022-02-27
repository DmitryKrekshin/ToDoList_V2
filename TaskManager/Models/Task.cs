using System;

namespace TaskManager
{
    public class Task
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }
        
        public TaskStatus Status { get; set; }
        
        public DateTime CreateDate { get; set; }
    }
}