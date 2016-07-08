using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Challenger.DataLayer
{
    public class User : IdentityUser
    {
        private string defaultEmail = "DefaultEmail@email.com";

        public User()
        {
            base.Email = defaultEmail;
        }
        public string Password { get; set; }

        public int Level { get; set; }

        public string Description { get; set; }

        public int CompletedChallenges { get; set; }

        [InverseProperty("Assignee")]
        public virtual ICollection<Task> AssignedTasks { get; set; }

        [InverseProperty("Challenger")]
        public virtual ICollection<Task> ChallengedTasks { get; set; }

        [InverseProperty("Sender")]
        public virtual ICollection<Notifications> FromNotifications { get; set; }

        [InverseProperty("Recipient")]
        public virtual ICollection<Notifications> ToNotifications { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}