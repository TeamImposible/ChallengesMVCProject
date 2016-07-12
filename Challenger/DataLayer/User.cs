using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Challenger.DataLayer
{
    public class User : IdentityUser
    {
        [Required]
        public int Level { get; set; }


        public string Description { get; set; }


        public int CompletedChallenges { get; set; }
        
        [InverseProperty("Assignee")]
        public virtual ICollection<Task> AssignedTasks { get; set; }

        [InverseProperty("Challenger")]
        public virtual ICollection<Task> ChallengedTasks { get; set; }

        [InverseProperty("Sender")]
        public virtual ICollection<Notification> FromNotifications { get; set; }

        [InverseProperty("Recipient")]
        public virtual ICollection<Notification> ToNotifications { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}