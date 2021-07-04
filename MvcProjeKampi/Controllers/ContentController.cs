using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        //Context c = new Context();
        public ActionResult GetAllContent(string p)
        {
            //p = "çok";
            //var values = from x in c.Contents select x;

            //if (!string.IsNullOrEmpty(p))
            //{
            //    values = values.Where(y => y.ContentValue.Contains(p));
            //}
            //var values = c.Contents.ToList();
            var values = cm.GetList();
            if (!string.IsNullOrEmpty(p))
            {
                values = cm.GetList(p);
            }
            return View(values.ToList());
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}