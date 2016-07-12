using Challenger.DataLayer;
using Challenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Challenger.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private DbContext db = DbContext.Create();

        // GET: UserProfile
        public ActionResult Index()
        {
            UserProfileViewModel model = new UserProfileViewModel();

            if (System.Web.HttpContext.Current != null &&
                System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                User user = db.Users.First(x => x.UserName == "random3");

                model.FullName = user.UserName;
                model.Description = user.Description;
                model.AssignedTasks = ParseTasks(db.Tasks.Where(x => x.Assignee.UserName == user.UserName).OrderByDescending(x => x.CreationDate).ToList());
                model.CreatedTasks = ParseTasks(db.Tasks.Where(x => x.Challenger.UserName == user.UserName).OrderByDescending(x => x.CreationDate).ToList());
                model.CurrentLevel = user.Level;
            }

            return View(model);
        }
        public ActionResult OtherIndex(string username)
        {
            UserProfileViewModel model = new UserProfileViewModel();

            if (System.Web.HttpContext.Current != null &&
                System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                User user = db.Users.First(x => x.UserName == username);

                model.FullName = user.UserName;
                model.Description = user.Description;
                model.AssignedTasks = ParseTasks(db.Tasks.Where(x => x.Assignee.UserName == user.UserName).OrderByDescending(x => x.CreationDate).ToList());
                model.CreatedTasks = ParseTasks(db.Tasks.Where(x => x.Challenger.UserName == user.UserName).OrderByDescending(x => x.CreationDate).ToList());
                model.CurrentLevel = user.Level;
            }

            return View(model);
        }

        List<SmallChallengeViewModel> ParseTasks(List<DataLayer.Task> tasks)
        {
            List<SmallChallengeViewModel> models = new List<SmallChallengeViewModel>();
            foreach (var task in tasks)
            {
                models.Add(new SmallChallengeViewModel()
                {
                    Challenger = task.Challenger.UserName,
                    Title = task.Title,
                    Type = task.Type,
                    DueDate = task.DueDate,
                    Assignee = task.Assignee.UserName,
                    Status = task.Status
                });
            }
            return models;
        } 
        // GET: UserProfile/Details/5
        public ActionResult Details(int id)
        {
            User user = db.Users.Find(id);

            UserProfileViewModel model = new UserProfileViewModel()
            {
                FullName = user.UserName
            };

            return View(model);
        }

        public ActionResult MyProfile()
        {
            return View();
        }
    }
}
