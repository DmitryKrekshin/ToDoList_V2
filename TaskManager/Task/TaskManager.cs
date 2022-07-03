using System;
using System.Collections.Generic;
using AutoMapper;
using ToDoListService;

namespace TaskManager
{
    public class TaskManager : ITaskManager
    {
        public TaskManager(IToDoListService service)
        {
            _service = service;
        }
        
        private readonly IToDoListService _service;
        private readonly IMapper _mapper = Map.TaskMapper();

        /// <inheritdoc/>
        public IEnumerable<Task> GetTasks()
        {
            return _mapper.Map<IEnumerable<Task>>(_service.GetTasks());
        }

        /// <inheritdoc/>
        public void CreateTask(Task task)
        {
            task.CreateDate = DateTime.Now;
            _service.AddTask(_mapper.Map<TaskEntity>(task));
        }

        /// <inheritdoc/>
        public void UpdateTask(Task task)
        {
            _service.UpdateTask(_mapper.Map<TaskEntity>(task));
        }

        /// <inheritdoc/>
        public void UpdateTaskStatus(Task task)
        {
            _service.UpdateTaskStatus(_mapper.Map<TaskEntity>(task));
        }

        /// <inheritdoc/>
        public void UpdateTaskName(Task task)
        {
            _service.UpdateTaskName(_mapper.Map<TaskEntity>(task));
        }

        /// <inheritdoc/>
        public void DeleteTask(int taskId)
        {
            _service.DeleteTask(taskId);
        }
    }
}