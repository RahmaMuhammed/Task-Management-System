using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management_System.Models.Entites
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedToUserId { get; set; }
        [ForeignKey("AssignedToUserId")]
        public ApplicationUser AssignedToUser { get; set; } // NP

        // Enum to track task state
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
    }
}
