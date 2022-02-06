using System.Collections.Generic;

namespace ToDoListService
{
    public interface IToDoListService
    {
        /// <summary>
        /// Получить все задачи
        /// </summary>
        IEnumerable<Task> GetTasks();
        /// <summary>
        /// Добавить задачу
        /// </summary>
        void AddTask(Task task);
        /// <summary>
        /// Изменить задачу
        /// </summary>
        void UpdateTask(Task task);
        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="task">Объект задачи</param>
        void DeleteTask(Task task);
        /// <summary>
        /// Удалить задачу по Id
        /// </summary>
        /// <param name="id">Id задачи</param>
        void DeleteTask(int id);
    }
}