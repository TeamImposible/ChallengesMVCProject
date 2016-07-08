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
                User user = db.Users.Find(userId);

                model.FullName = user.UserName;
            }

            return View(model);
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
