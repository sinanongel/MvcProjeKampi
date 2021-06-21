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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messageValidator = new MessageValidator();
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
        public PartialViewResult MessageListMenu()
        {
            var gelenMesaj = mm.GetListInbox().Count();
            ViewBag.gelenMesaj = gelenMesaj;

            var gidenMesaj = mm.GetListSendbox().Count();
            ViewBag.gidenMesaj = gidenMesaj;

            var draftMessage = mm.GetListDraft().Count();
            ViewBag.draftMessage = draftMessage;

            var readMessage = mm.GetListInbox().Where(x => x.Read == true).Count();
            ViewBag.readMessage = readMessage;

            var unReadMessage = mm.GetListUnRead().Count();
            ViewBag.unReadMessage = unReadMessage;

            return PartialView();
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
                    p.SenderMail = "serpily@gmail.com";
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
                p.SenderMail = "serpily@gmail.com";
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