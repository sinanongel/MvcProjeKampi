using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class SkillCardController : Controller
    {
        // GET: SkillCard
        SkillManager sm = new SkillManager(new EFSkillDal());
        public ActionResult Index()
        {
            var skillValues = sm.GetList();
            return View(skillValues);
        }
        public ActionResult SkillCardList()
        {
            var skillValues = sm.GetList();
            return View(skillValues);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skill p)
        {
            SkillValidator skillValidator = new SkillValidator();
            ValidationResult result = skillValidator.Validate(p);
            if (result.IsValid)
            {
                TempData["addSkill"] = "";
                sm.SkillAdd(p);
                return RedirectToAction("SkillCardList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skillValues = sm.GetById(id);
            return View(skillValues);
        }
        [HttpPost]
        public ActionResult EditSkill(Skill p)
        {
            TempData["updateSkill"] = "";
            sm.SkillUpdate(p);
            return RedirectToAction("SkillCardList");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skillValues = sm.GetById(id);
            sm.SkillDelete(skillValues);

            return RedirectToAction("SkillCardList");
        }
    }
}