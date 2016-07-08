using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Challenger.DataLayer;

namespace Challenger.Models
{
    public class CreateChallengeViewModel
    {
        public string Title { get; set; }
        public Task.ChallengeType Type { get; set; }
    }
}