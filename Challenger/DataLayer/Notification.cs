using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Challenger.DataLayer
{
    public class Notification
    {
        public enum NotificationAction
        {
            Sent = 0,
            Accepted = 1,
            Declined = 2,
            Done = 3,
            Expired = 4
        }

        [Required]
        public int ID { get; set; }

        [Required]
        public int SenderID { get; set; }

        [Required]
        public int RecipientID { get; set; }

        [Required]
        public NotificationAction Action { get; set; }

        [Required]
        public bool Seen { get; set; }

        [Required]
        public virtual User Sender { get; set; }

        [Required]
        public virtual User Recipient { get; set; }
    }
}