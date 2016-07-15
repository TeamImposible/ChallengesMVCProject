using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Challenger.DataLayer;
using Challenger.Models;

namespace Challenger.Controllers
{
    public class HomeController : Controller
    {
        public static DbContext Context = DbContext.Create();

        public ActionResult Index(int id)
        {
            Context = DbContext.Create();
            if (User.Identity.IsAuthenticated)
            {
                HomeChallengesViewModel challenges =new HomeChallengesViewModel();
                List<Task> tasks = Context.Tasks.OrderByDescending(x => x.CreationDate).ToList();
                challenges.Challenges = new List<SmallChallengeViewModel>();
                for (int i = 1 * id; i < (1 * id) + 10; i++)
                {
                    try
                    {
                        challenges.Challenges.Add(new SmallChallengeViewModel()
                        {
                            Assignee = tasks[i].Assignee.UserName,
                            Challenger = tasks[i].Challenger.UserName,
                            DueDate = tasks[i].DueDate,
                            Title = tasks[i].Title,
                            Type = tasks[i].Type,
                            Status = tasks[i].ActiveStatus,ID = tasks[i].ID
                        });
                    }
                    catch (Exception)
                    {
                        break;
                    }

                }
                challenges.CreateChallenge = new CreateChallengeViewModel();
                return View(challenges);
            }
            else
            {
                return View("IndexForAllUsers");
            }

        }

        public ActionResult IndexForAllUsers()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}