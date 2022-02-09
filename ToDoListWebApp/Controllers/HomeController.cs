using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ITaskLogic taskLogic)
        {
            _taskLogic = taskLogic;
        }
        
        private readonly ITaskLogic _taskLogic;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}