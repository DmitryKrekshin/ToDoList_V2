using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoListService
{
    public class ToDoListService : IToDoListService
    {
        public ToDoListService(ToDoListContext context)
        {
            _context = context;
        }
        
        private readonly ToDoListContext _context;

        /// <inheritdoc />
        public IEnumerable<TaskEntity> GetTasks()
        {
            return _context.Tasks.AsNoTracking();
        }

        /// <inheritdoc />
        public void AddTask(TaskEntity taskEntity)
        {
            _context.Tasks.Add(taskEntity);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void UpdateTask(TaskEntity taskEntity)
        {
            var taskToUpdate = _context.Tasks.Find(taskEntity.Id);

            if (taskToUpdate is null)
            {
                throw new NullReferenceException("Task doesn't exists");
            }
            
            taskToUpdate = taskEntity;
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void DeleteTask(TaskEntity taskEntity)
        {
            var taskToDelete = _context.Tasks.Find(taskEntity);

            if (taskToDelete is null)
            {
                throw new NullReferenceException("Task doesn't exists");
            }

            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void DeleteTask(int id)
        {
            var taskToDelete = _context.Tasks.Find(id);

            if (taskToDelete is null)
            {
                throw new NullReferenceException("Task doesn't exists");
            }

            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();
        }
    }
}