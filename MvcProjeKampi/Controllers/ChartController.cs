using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });

            return ct;
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult HedaingChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> cc = new List<CategoryClass>();
            foreach (var item in hm.GetList().GroupBy(x=> new { x.Category.CategoryName }))
            {
                cc.Add(new CategoryClass()
                {
                    CategoryName = item.Key.CategoryName,
                    CategoryCount = hm.GetList().Where(x => x.Category.CategoryName == item.Key.CategoryName).Count()
                });
            }           

            return cc;
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult MessageChart()
        {
            return Json(MessageList(), JsonRequestBehavior.AllowGet);
        }
        public List<MessageClass> MessageList()
        {
            List<MessageClass> mc = new List<MessageClass>();
            foreach (var item in mm.GetList().GroupBy(x => new { x.SenderMail }))
            {
                mc.Add(new MessageClass()
                {
                    MessageWriter = item.Key.SenderMail,
                    MessageCount = mm.GetList().Where(x => x.SenderMail == item.Key.SenderMail).Count()
                });
            }

            return mc;
        }
    }
}