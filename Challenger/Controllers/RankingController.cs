using Challenger.DataLayer;
using Challenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenger.Controllers
{
    public class RankingController : Controller
    {
        DbContext context = DbContext.Create();
        // GET: Ranking
        public ActionResult Index()
        {
            ManyModels models = new ManyModels();
            models.Users = new List<RankingViewModel>();
            foreach (var item in context.Users.OrderBy(x => x.CompletedChallenges).ThenBy(x => x.UserName))
            {
                models.Users.Add(new RankingViewModel()
                {
                    CompletedChallenges = item.CompletedChallenges,
                    Level = item.Level,
                    Name = item.UserName
                });
            }
            return View(models);
        }

        //[HttpPost]
        //public ActionResult Index()
        //{

        //}
    }
}