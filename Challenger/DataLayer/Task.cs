using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime? DueDate { get; set; }

        public int? Quantity { get; set; }

        [Required]
        [MaxLength(72, ErrorMessage = "Tatle must be 72 characters or less")]
        public string Title { get; set; }

        [Required]
        public ChallengeType Type { get; set; }

        [Required]
        public ChallengeStatus Status { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public virtual User Challenger { get; set; }

        [Required]
        public virtual User Assignee { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public void UpdateStatus()
        {
            
            if (Status == ChallengeStatus.Done || Status == ChallengeStatus.Decline || Status == ChallengeStatus.Expired)
                return;
            if (DueDate != null && CheckForExpired())
            {
                Status = ChallengeStatus.Expired;
                return;
            }
            if (Status == ChallengeStatus.InProcess)
            {
                if ((Type == ChallengeType.Quantity || Type == ChallengeType.StepByStep) && Quantity <= 0)
                {
                    Status = ChallengeStatus.Done;
                    return;
                }
            }
        }

        public bool CheckForExpired()
        {
            return DueDate <= DateTime.Now;
        }
    }
}