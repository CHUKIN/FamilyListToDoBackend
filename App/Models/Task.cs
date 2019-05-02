using System;

namespace App.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public TaskType TaskType { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public DateTimeOffset OpeningDate { get; set; }
        public DateTimeOffset? ClosingDate { get; set; }
    }
}