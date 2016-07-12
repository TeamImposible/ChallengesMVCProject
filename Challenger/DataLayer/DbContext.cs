using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using Challenger.DataLayer;

namespace Challenger.DataLayer
{
    public class DbContext : IdentityDbContext<User>
    {
        public DbContext() : base("name=DefaultConnection") { }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public static DbContext Create()
        {
            return new DbContext();
        }

        public List<Task> GetTasksByChallengerID(string username)
        {
            return Tasks.Where(x => x.Challenger.UserName == username).ToList();
        }

        public List<Task> GetTasksByAssigneeID(string username)
        {
            return Tasks.Where(x => x.Assignee.UserName == username).ToList();
        }
    }
}