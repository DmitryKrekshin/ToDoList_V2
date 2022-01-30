using Microsoft.EntityFrameworkCore;

namespace ToDoListService
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}