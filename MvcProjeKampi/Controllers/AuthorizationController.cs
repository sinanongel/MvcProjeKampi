using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager ad = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var adminValues = ad.GetList();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> RoleList = new List<SelectListItem>();
            RoleList.Add(new SelectListItem() { Text = "A" });
            RoleList.Add(new SelectListItem() { Text = "B" });
            RoleList.Add(new SelectListItem() { Text = "C" });

            ViewBag.RoleList = RoleList;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            ad.AdminAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = ad.GetById(id);

            List<SelectListItem> RoleList = new List<SelectListItem>();
            RoleList.Add(new SelectListItem() { Text = "A" });
            RoleList.Add(new SelectListItem() { Text = "B" });
            RoleList.Add(new SelectListItem() { Text = "C" });

            ViewBag.RoleList = RoleList;
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            ad.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}