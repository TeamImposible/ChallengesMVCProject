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

        public string Description { get; set; }

        public List<SmallChallengeViewModel> AssignedTasks { get; set; }

        public List<SmallChallengeViewModel> CreatedTasks { get; set; }
    }
    public class RankingViewModel
    {
        public int Level { get; set; }

        public string Name { get; set; }

        public int CompletedChallenges { get; set; }
    }
    public class ManyModels
    {
        public List<RankingViewModel> Users { get; set; }
    }
}