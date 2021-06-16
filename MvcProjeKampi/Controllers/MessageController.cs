using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValues = mm.GetById(id);
            messageValues.Read = true;
            mm.MessageUpdate(messageValues);
            return View(messageValues);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p, string value)
        {
            ValidationResult result = messageValidator.Validate(p);

            if (value == "send")
            {
                if (result.IsValid)
                {
                    p.SenderMail = "admin@gmail.com";
                    p.Draft = false;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(p);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (value == "draft")
            {
                p.SenderMail = "admin@gmail.com";
                p.Draft = true;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Draft");
            }
            return View();
        }

        public ActionResult Draft()
        {
            var draftValues = mm.GetListDraft();
            return View(draftValues);
        }
    }
}