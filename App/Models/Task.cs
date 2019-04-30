using System;

namespace App.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public TaskType TaskType { get; set; }
    }
}