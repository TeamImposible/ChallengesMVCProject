using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Challenger.DataLayer;

namespace Challenger.Models
{
    public class CreateChallengeViewModel
    {
        public string Challenger { get; set; }

        public Task.ChallengeType Type { get; set; }

        public DateTime? DueDate { get; set; }

        public string Assignee { get; set; }

        public string Title { get; set; }

        public int? Quantity { get; set; }

        public string Description { get; set; }
    }

    public class FullChallengeViewModel
    {
        public string Challenger { get; set; }

        public Task.ChallengeType Type { get; set; }

        public DateTime? DueDate { get; set; }

        public string Assignee { get; set; }

        public string Title { get; set; }

        public int? Quantity { get; set; }

        public string Description { get; set; }

        public Task.ChallengeStatus Status { get; set; }

    }

    public class SmallChallengeViewModel
    {
        public string Challenger { get; set; }

        public Task.ChallengeType Type { get; set; }

        public DateTime? DueDate { get; set; }

        public string Assignee { get; set; }

        public string Title { get; set; }

        public Task.ChallengeStatus Status { get; set; }
    }

    public class HomeChallengesViewModel
    {
        public List<SmallChallengeViewModel> Challenges { get; set; }

        public CreateChallengeViewModel CreateChallenge { get; set; }
    }

    public class UpdateChallengeViewModel
    {
        public int ID { get; set; }

        public string Challenger { get; set; }

        public Task.ChallengeType Type { get; set; }

        public DateTime? DueDate { get; set; }

        public string Assignee { get; set; }

        public string Title { get; set; }

        public int? Quantity { get; set; }

        public string Description { get; set; }

        public Task.ChallengeStatus Status { get; set; }

        public int? QuantityLeft { get; set; }
    }
}