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
            var iletisim = cm.GetList().Count();
            ViewBag.iletisim = iletisim;

            var gelenMesaj = mm.GetListInbox().Count();
            ViewBag.gelenMesaj = gelenMesaj;

            var gidenMesaj = mm.GetListSendbox().Count();
            ViewBag.gidenMesaj = gidenMesaj;

            return PartialView();
        }
    }
}