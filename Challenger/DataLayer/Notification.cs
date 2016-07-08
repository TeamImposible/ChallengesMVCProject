using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenger.DataLayer
{
    public class Notifications
    {
        public int ID { get; set; }

        public int SenderID { get; set; }

        public int RecipientID { get; set; }

        public int Action { get; set; }

        public bool Seen { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Recipient { get; set; }
    }
}