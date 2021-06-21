using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Admin
        AdminManager ad = new AdminManager(new EFAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            string password = p.AdminPassword;
            string result = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
            p.AdminPassword = result;

            var adminUserInfo = ad.GetList().FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == result);

            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Hatalı!";
                return View();
            }
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            //string password = p.AdminPassword;
            //string result = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
            //p.AdminPassword = result;

            //var adminUserInfo = ad.GetList().FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == result);
            var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                //ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Hatalı!";
                //return View();
                return RedirectToAction("WriterLogin");
            }
        }
    }
}