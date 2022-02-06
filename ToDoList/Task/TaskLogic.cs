using System.Collections.Generic;
using ToDoListService;

namespace ToDoList
{
    public class TaskLogic : ITaskLogic
    {
        private readonly IToDoListService _service;

        public TaskLogic(IToDoListService service)
        {
            _service = service;
        }
        
        /// <inheritdoc/>
        public IEnumerable<Task> GetTasks()
        {
            return _service.GetTasks();
        }

        /// <inheritdoc/>
        public void CreateTask(Task task)
        {
            _service.AddTask(task);
        }

        /// <inheritdoc/>
        public void UpdateTask(Task task)
        {
            _service.UpdateTask(task);
        }

        /// <inheritdoc/>
        public void DeleteTask(int taskId)
        {
            _service.DeleteTask(taskId);
        }
    }
}