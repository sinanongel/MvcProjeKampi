using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context c = new Context();
        public int id;
        public ActionResult Index()
        {
            var countCategory = c.Categories.Count();
            var countHeading = c.Headings.Where(x => x.Category.CategoryName == "Yazılım").Count();
            var countWriter = c.Writers.Where(x => x.WriterName.Contains("a")).Count();
            var countCategoryList = c.Headings.GroupBy(x => x.CategoryId).Select(y => new { y.Key, Count = y.Count() }).ToList();
            var countCategoryTrue = c.Categories.Where(x => x.CategoryStatus == true).Count();
            var countCategoryFalse = c.Categories.Where(x => x.CategoryStatus == false).Count();
            var trueFalseFark = countCategoryTrue - countCategoryFalse;

            List<int> Sayilar = new List<int>();
            List<int> Idler = new List<int>();

            int enBuyuk = 0;
            int i = 0;

            foreach (var sayi in countCategoryList)
            {

                Idler.Add(sayi.Key);
                Sayilar.Add(sayi.Count);
                if (Sayilar[i] > enBuyuk)
                {
                    enBuyuk = Sayilar[i];
                    id = Idler[i];
                }
                i++;
            }

            var categoryName = c.Categories.Where(x => x.CategoryId == id).Select(y => y.CategoryName).FirstOrDefault();

            ViewBag.countCategory = countCategory;
            ViewBag.countHeading = countHeading;
            ViewBag.countWriter = countWriter;
            ViewBag.categoryName = categoryName;
            ViewBag.trueFalseFark = trueFalseFark;

            return View("Index");
        }
    }
}