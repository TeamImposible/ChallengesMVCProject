using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenger.DataLayer
{
    public class Task
    {
        public enum ChallengeStatus
        {
            Sent = 0,
            Accept = 1,
            Decline = 2,
            InProcess = 3,
            Done = 4,
            Expired = 5
        }

        public enum ChallengeType
        {
            OneTime = 0,
            StepByStep = 1,
            Quantity = 2
        }

        public int ID { get; set; }

        [Required]
        [MaxLength(72, ErrorMessage = "Name must be 72 characters or less")]
        public string Name { get; set; }

        public int ChallengerID { get; set; }

        public int AssigneeID { get; set; }
        
        public string Title { get; set; }

        public ChallengeType Type { get; set; }

        public ChallengeStatus Status { get; set; }

        public DateTime DueDate { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual User Challenger { get; set; }

        public virtual User Assignee { get; set; }
    }
}