using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Challenger.DataLayer;
using Challenger.Models;

namespace Challenger.Controllers
{
    public class ChallengeController : Controller
    {
        public static DbContext Context = DbContext.Create();
        // GET: Challenge/Details/5
        public ActionResult Details(int id)
        {
            Task dataModel = Context.Tasks.First(x => x.ID == id);
            CreateChallengeViewModel model = new CreateChallengeViewModel()
            {
                Assignee = dataModel.Assignee.UserName,
                Challenger = dataModel.Challenger.UserName,
                Description = dataModel.Description,
                Quantity = dataModel.Quantity,
                Title = dataModel.Title,
                Type = dataModel.Type,
                DueDate = dataModel.DueDate
            };
            return View(model);
        }

        // GET: Challenge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Challenge/Create
        [HttpPost]
        public ActionResult Create(CreateChallengeViewModel model)
        {
            Task taskDataModel = new Task()
            {
                Title = model.Title,
                Type = model.Type,
                Quantity = model.Quantity,
                DueDate = model.DueDate,
                Challenger = Context.Users.First(x => x.UserName == model.Challenger),
                Assignee = Context.Users.First(x => x.UserName == model.Assignee),
                Description = model.Description,
                CreationDate = DateTime.Now
            };
            Notification notificationDataModel = new Notification()
            {
                Action = Notification.NotificationAction.Sent,
                Recipient = taskDataModel.Assignee,
                Sender = taskDataModel.Challenger
            };
            Context.Tasks.Add(taskDataModel);
            Context.Notifications.Add(notificationDataModel);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateChallenge(int id)
        {
            Task dataModel = Context.Tasks.First(x => x.ID == id);
            UpdateChallengeViewModel model = new UpdateChallengeViewModel()
            {
                Assignee = dataModel.Assignee.UserName,
                Challenger = dataModel.Challenger.UserName,
                Description = dataModel.Description,
                Title = dataModel.Title,
                Type = dataModel.Type,
                DueDate = dataModel.DueDate,
                Status = dataModel.Status,
                ID = dataModel.ID,
                QuantityLeft = dataModel.Quantity
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateChallenge(UpdateChallengeViewModel model)
        {
            Task dataModel = Context.Tasks.First(x => x.ID == model.ID);
            if (model.Type == Task.ChallengeType.OneTime)
                dataModel.Status = Task.ChallengeStatus.Done;
            dataModel.UpdateStatus();
            return RedirectToAction("Index", "Home");
        }
    }
}
