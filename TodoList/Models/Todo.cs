using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public enum TodoStatus { Pending, InProgress, Completed }
    public enum Priority { Low, Medium, High }

    public class Todo
    {
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public TodoStatus Status { get; set; } = TodoStatus.Pending;

        public Priority Priority { get; set; } = Priority.Medium;

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
    }
}