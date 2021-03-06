using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskManager _taskManager;
        private readonly IMapper _mapper = ModelsMapper.Map();

        public HomeController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = _mapper.Map<IEnumerable<TaskView>>(_taskManager.GetTasks());
            return View(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskView taskView)
        {
            if (ModelState.IsValid)
            {
                var task = _mapper.Map<Task>(taskView);
                task.Status = TaskStatus.Normal;

                _taskManager.CreateTask(task);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateTask(int id, string name)
        {
            var task = new Task
            {
                Id = id,
                Name = name
            };
            _taskManager.UpdateTaskName(task);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public StatusCodeResult TaskDone(int taskId)
        {
            var taskForUpdate = new Task
            {
                Id = taskId,
                Status = TaskStatus.Done,
            };
            _taskManager.UpdateTaskStatus(taskForUpdate);

            return Ok();
        }

        public IActionResult DeleteTask(int taskId)
        {
            _taskManager.DeleteTask(taskId);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}