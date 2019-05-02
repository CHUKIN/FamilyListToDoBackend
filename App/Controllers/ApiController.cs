using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Helpers;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Task = App.Models.Task;
using TaskStatus = App.Models.TaskStatus;

namespace App.Controllers
{
    public class ApiController : Controller
    {
        private FamilyContext db;
        public ApiController(FamilyContext context)
        {
            db = context;
        }
        
        [HttpGet]
        public IActionResult GetFamilyListToDo()
        {
            var tasks = db.Tasks.Where(i => i.TaskStatus == TaskStatus.Open && (i.TaskType == TaskType.Purchases || i.TaskType == TaskType.Tasks));
            var taskTypes = new []{
                new {id = TaskType.Purchases, text = Constants.Purchases}, 
                new {id = TaskType.Tasks, text = Constants.Tasks}
            };
            return Json(new
            {
                shoppingList = tasks.Where(i=>i.TaskType == TaskType.Purchases),
                toDoList = tasks.Where(i=>i.TaskType == TaskType.Tasks),
                taskTypeList = taskTypes,
            });
        }

        [HttpPost]
        public IActionResult CreateNewTask(Task newTask)
        {
            newTask.OpeningDate = DateTimeOffset.Now;
            db.Tasks.Add(newTask);
            db.SaveChanges();
            return Json(newTask);
        }
        
        [HttpPost]
        public IActionResult CompleteTask(Task task)
        {
            var findedTask = db.Tasks.Find(task.Id);
            if (findedTask != null)
            {
                findedTask.TaskStatus = TaskStatus.Complete;
                findedTask.ClosingDate = DateTimeOffset.Now; 
                db.SaveChanges();
            }

            return Json(task);
        }
    }
}