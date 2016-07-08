using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Challenger.DataLayer
{
    public class DbContext : IdentityDbContext<User>
    {
        public DbContext() : base("name=DefaultConnection") { }

        public DbSet<Task> Tasks { get; set; }

        public static DbContext Create()
        {
            return new DbContext();
        }
    }
}