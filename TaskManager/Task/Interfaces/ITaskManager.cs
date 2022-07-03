using System.Collections.Generic;
using ToDoListService;

namespace TaskManager
{
    public interface ITaskManager
    {
        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <returns>Коллекция объектов Task</returns>
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
        /// Обновить статус задачи
        /// </summary>
        void UpdateTaskStatus(Task task);
        /// <summary>
        /// Изменить назваие задачи
        /// </summary>
        void UpdateTaskName(Task task);
        /// <summary>
        /// Удалить задачу
        /// </summary>
        void DeleteTask(int taskId);
    }
}