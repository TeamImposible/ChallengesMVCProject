using Challenger.DataLayer;
using Challenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenger.Controllers
{
    public class NotificationController : ApiController
    {
        DbContext context = DbContext.Create();
        // GET: api/Notification
        public IEnumerable<NotificationViewModels> Get()
        {
            List<NotificationViewModels> c = new List<NotificationViewModels>();
            var list = context.Notifications.Where(x => x.Recipient.UserName == User.Identity.Name).OrderByDescending(x => x.CreationDate).ToList();
            foreach (var notification in list)
            {
                string message = "";
                if (notification.Action == Notification.NotificationAction.Accepted)
                    message = string.Format("{0}, accepted your challenge.", notification.Sender.UserName);

                else if (notification.Action == Notification.NotificationAction.Declined)
                    message = string.Format("{0}, declined your challenge.", notification.Sender.UserName);

                else if (notification.Action == Notification.NotificationAction.Done)
                    message = string.Format("{0}, done your challenge.", notification.Sender.UserName);

                else if (notification.Action == Notification.NotificationAction.Expired)
                    message = string.Format("{0}, expired your challenge.", notification.Sender.UserName);

                else if (notification.Action == Notification.NotificationAction.Sent)
                    message = string.Format("{0}, challenged you.", notification.Sender.UserName);

                NotificationViewModels b = new NotificationViewModels() { message = message, ChallengeId = notification.ChallengeID };
                c.Add(b);
            }
            return c;
        }

        // GET: api/Notification/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Notification
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Notification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Notification/5
        public void Delete(int id)
        {
        }
    }
}
