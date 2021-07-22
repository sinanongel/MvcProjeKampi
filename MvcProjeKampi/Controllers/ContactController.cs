using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            var iletisim = cm.GetList().Count();
            ViewBag.iletisim = iletisim;

            var gelenMesaj = mm.GetListInbox(p).Count();
            ViewBag.gelenMesaj = gelenMesaj;

            var gidenMesaj = mm.GetListSendbox(p).Count();
            ViewBag.gidenMesaj = gidenMesaj;

            var draftMessage = mm.GetListDraft(p).Count();
            ViewBag.draftMessage = draftMessage;

            var readMessage = mm.GetListInbox(p).Where(x => x.Read == true).Count();
            ViewBag.readMessage = readMessage;

            var unReadMessage = mm.GetListUnRead(p).Count();
            ViewBag.unReadMessage = unReadMessage;

            return PartialView();
        }
    }
}