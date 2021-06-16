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
    public class SkillCardController : Controller
    {
        // GET: SkillCard
        SkillManager sm = new SkillManager(new EFSkillDal());
        public ActionResult Index()
        {
            var skillValues = sm.GetList();
            return View(skillValues);
        }
    }
}