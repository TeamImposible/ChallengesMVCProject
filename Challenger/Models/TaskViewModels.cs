using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenger.Models
{
    public class TaskViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public UserViewModel Assignee { get; set; }

        public UserViewModel Challenger { get; set; }
    }
}