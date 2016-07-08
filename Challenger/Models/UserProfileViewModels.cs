using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenger.Models
{
    public class UserProfileViewModel
    {
        public string FullName { get; set; }

        public int CurrentLevel { get; set; }

        public double CurrentLevelProgress { get; set; }

        public List<TaskViewModel> AssignedTasks { get; set; }
    }
}