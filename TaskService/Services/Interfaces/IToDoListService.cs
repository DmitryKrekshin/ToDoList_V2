using System.Collections.Generic;

namespace ToDoListService
{
    public interface IToDoListService
    {
        /// <summary>
        /// Получить все задачи
        /// </summary>
        IEnumerable<TaskEntity> GetTasks();
        /// <summary>
        /// Добавить задачу
        /// </summary>
        void AddTask(TaskEntity taskEntity);
        /// <summary>
        /// Изменить задачу
        /// </summary>
        void UpdateTask(TaskEntity taskEntity);

        /// <summary>
        /// Изменить статус задачи
        /// </summary>
        /// <param name="taskEntity"></param>
        void UpdateStatusTask(TaskEntity taskEntity);
        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="taskEntity">Объект задачи</param>
        void DeleteTask(TaskEntity taskEntity);
        /// <summary>
        /// Удалить задачу по Id
        /// </summary>
        /// <param name="id">Id задачи</param>
        void DeleteTask(int id);
    }
}