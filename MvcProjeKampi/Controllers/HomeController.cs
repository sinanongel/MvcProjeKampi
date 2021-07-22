using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            var headingCount = hm.GetList().Count;
            ViewBag.hCount = headingCount;

            var writerCount = wm.GetList().Count;
            ViewBag.wCount = writerCount;

            var messageCount = mm.GetList().Count;
            ViewBag.mCount = messageCount;

            return View();
        }
    }
}