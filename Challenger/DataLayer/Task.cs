using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenger.DataLayer
{
    public class Task
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(72, ErrorMessage = "Name must be 72 characters or less")]
        public string Name { get; set; }

        public int ChallengerID { get; set; }

        public int AssigneeID { get; set; }

        public string Title { get; set; }

        public int Status { get; set; }

        public string DueDate { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual User Challenger { get; set; }

        public virtual User Assignee { get; set; }
    }
}