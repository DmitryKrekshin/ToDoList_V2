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
        public IEnumerable<Task> GetTasks()
        {
            return _context.Tasks.AsNoTracking();
        }

        /// <inheritdoc />
        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void UpdateTask(Task task)
        {
            var taskToUpdate = _context.Tasks.Find(task.Id);

            if (taskToUpdate is null)
            {
                throw new NullReferenceException("Task doesn't exists");
            }
            
            taskToUpdate = task;
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void DeleteTask(Task task)
        {
            var taskToDelete = _context.Tasks.Find(task);

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