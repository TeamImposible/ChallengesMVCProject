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
            FullChallengeViewModel model = new FullChallengeViewModel()
            {
                Assignee = dataModel.Assignee.UserName,
                Challenger = dataModel.Challenger.UserName,
                Description = dataModel.Description,
                Quantity = dataModel.Quantity,
                Title = dataModel.Title,
                Type = dataModel.Type,
                DueDate = dataModel.DueDate,
                Status = dataModel.ActiveStatus
            };
            return View(model);
        }
        public ActionResult Redirected(string username)
        {
            return View("Create", new CreateChallengeViewModel() {Assignee = username});
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
            try
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
                if ((model.DueDate < DateTime.Now && model.DueDate != null))
                    throw new Exception();
                if ((model.Type == Task.ChallengeType.Quantity || model.Type == Task.ChallengeType.StepByStep) &&
                    (model.Quantity <= 0 || model.Quantity == null))
                    throw new Exception();
                Context.Tasks.Add(taskDataModel);
                Context.SaveChanges();
                Notification notificationDataModel = new Notification()
                {
                    Action = Notification.NotificationAction.Sent,
                    Recipient = taskDataModel.Assignee,
                    Sender = taskDataModel.Challenger,
                    ChallengeID = Context.Tasks.OrderByDescending(x => x.CreationDate).First().ID,
                    CreationDate = DateTime.Now
                };
                Context.Notifications.Add(notificationDataModel);
                
                Context.SaveChanges();
            }
            catch (Exception)
            {
                model.Failed = true;
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult AcceptChallenge(UpdateChallengeViewModel model)
        {
            Task dataModel = Context.Tasks.First(x => x.ID == model.ID);
            dataModel.Status = Task.ChallengeStatus.Accept;

            Context.SaveChanges();
            return RedirectToAction("UpdateChallenge", "Challenge", new { id = model.ID });
        }

        [HttpPost]
        public ActionResult DeclineChallenge(UpdateChallengeViewModel model)
        {
            Task dataModel = Context.Tasks.First(x => x.ID == model.ID);
            dataModel.Status = Task.ChallengeStatus.Decline;

            Context.SaveChanges();
            return RedirectToAction("Details", "Challenge", new { id = model.ID });
        }
        public ActionResult RedirectToChallenge(int id)
        {
            Task item = Context.Tasks.Find(id);
            if (item.Assignee.UserName != User.Identity.Name || item.Status == Task.ChallengeStatus.Done
                                                            || item.Status == Task.ChallengeStatus.Expired
                                                            || item.Status == Task.ChallengeStatus.Decline)
            {
                return RedirectToAction("Details", new { id = id });
            }
            return RedirectToAction("UpdateChallenge", new { id = id });
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
                Status = dataModel.ActiveStatus,
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
            {
                Context.Users.First(x => x.UserName == User.Identity.Name).CompleteChallenge();
                dataModel.Status = Task.ChallengeStatus.Done;
            }
            else if (model.Type == Task.ChallengeType.Quantity)
            {
                dataModel.Quantity -= model.Quantity;
            }
            else if (model.Type == Task.ChallengeType.StepByStep)
            {
                dataModel.Quantity--;
            }
            if (dataModel.Status == Task.ChallengeStatus.Accept)
                dataModel.Status = Task.ChallengeStatus.InProcess;
            if (dataModel.Status == Task.ChallengeStatus.InProcess)
            {
                if ((model.Type == Task.ChallengeType.Quantity || model.Type == Task.ChallengeType.StepByStep) && dataModel.Quantity <= 0)
                {
                    dataModel.Status = Task.ChallengeStatus.Done;
                    Context.Users.First(x => x.UserName == User.Identity.Name).CompleteChallenge();
                }
            }
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
