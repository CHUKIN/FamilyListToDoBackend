using System.Collections.Generic;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ApiController : Controller
    {
        // GET
        public IActionResult GetFamilyListToDo()
        {
            var taskTypeTask = new TaskType
            {
                Id=1,
                Text = "Задача"
            };
            var taskTypeShop = new TaskType
            {
                Id=0,
                Text = "Покупка"
            };

            var shopTask = new Task
            {
                Id = 0,
                Text = "Купить мясо",
                TaskType = taskTypeShop
            };
            var taskTask = new Task
            {
                Id = 1,
                Text = "Вкрутить лампочку",
                TaskType = taskTypeTask
            };
            
            return Json(new
            {
                FamilyListToDo = new{
                    ShoppingList = new List<Task>{shopTask},
                    ToDoList=new List<Task> { taskTask},
                    TaskTypeList= new List<TaskType> { taskTypeShop, taskTypeTask}
            }
            });
        }
    }
}