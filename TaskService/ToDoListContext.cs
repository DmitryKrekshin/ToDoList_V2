using Microsoft.EntityFrameworkCore;

namespace ToDoListService
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}