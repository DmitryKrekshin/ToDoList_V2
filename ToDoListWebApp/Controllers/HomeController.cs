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
        private readonly ITaskLogic _taskLogic;
        private readonly IMapper _mapper = ModelsMapper.Map();
        
        public HomeController(ITaskLogic taskLogic)
        {
            _taskLogic = taskLogic;
        }
        
        public IActionResult Index()
        {
            var tasks = _mapper.Map<IEnumerable<TaskView>>(_taskLogic.GetTasks());
            
            return View(tasks);
        }

        public IActionResult CreateTask(TaskView taskView)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("~/Home/Index");
            }
            
            var task = _mapper.Map<Task>(taskView);
            task.Status = TaskStatus.Normal;
            
            _taskLogic.CreateTask(task);

            return Redirect("~/Home/Index");
        }

        public IActionResult TaskDone(int taskId)
        {
            var taskForUpdate = new Task
            {
                Id = taskId,
                Status = TaskStatus.Done,
            };
            _taskLogic.UpdateTaskStatus(taskForUpdate);
            
            return Redirect("~/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}