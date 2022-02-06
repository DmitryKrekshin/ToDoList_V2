using System.Collections.Generic;
using ToDoListService;

namespace ToDoList
{
    public interface ITaskLogic
    {
        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <returns></returns>
        IEnumerable<Task> GetTasks();
        /// <summary>
        /// Создать задачу
        /// </summary>
        void CreateTask(Task task);
        /// <summary>
        /// Обновить задачу
        /// </summary>
        void UpdateTask(Task task);
        /// <summary>
        /// Удалить задачу
        /// </summary>
        void DeleteTask(int taskId);
    }
}