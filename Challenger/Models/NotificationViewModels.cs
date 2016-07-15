using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenger.Models
{
    public class NotificationViewModels
    {
        public string message { get; set; }

        public int ChallengeId { get; set; }
    }

    public class ParseToArrayViewModel
    {
        public List<NotificationViewModels> Models { get; set; }
    }
}