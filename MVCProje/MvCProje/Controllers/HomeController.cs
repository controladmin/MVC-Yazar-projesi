using BusinessLayer.Concrete; // WriterLoginManager sınıfını kullanabilmek için ekledik
using DataAccessLayer.Concrete; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFWriterDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Writer sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; // Cookie kullanabilmek için ekledik

namespace MvCProje.Controllers
{
    public class HomeController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());
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
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }


        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //Context c = new Context();
            //var writerInfo = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            var writeruserInfo = wlm.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (writeruserInfo != null)
            {
                /* sisteme giriş yapan kullanıcının bilgilerini alıyoruz çerezlere ekliyoruz yetkili sayfalara erişebilsin diye*/
                /* kalıcı Cookie oluşsun mu diye ikinci parametre istiyor o yüzden false yaptık kalıcı oluşmasın diye */
                /* Bu session kodlarını yazmaz isek sayfaya yönlendirmez 401 yetkisiz erişim sayar */
                FormsAuthentication.SetAuthCookie(writeruserInfo.WriterMail, false);
                Session["WriterMail"] = writeruserInfo.WriterMail;
                return RedirectToAction("WriterContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("HomePage","Home");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            Context c = new Context();
            var adminInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (adminInfo != null)
            {
                /* sisteme giriş yapan kullanıcının bilgilerini alıyoruz çerezlere ekliyoruz yetkili sayfalara erişebilsin diye*/
                /* kalıcı Cookie oluşsun mu diye ikinci parametre istiyor o yüzden false yaptık kalıcı oluşmasın diye */
                /* Bu session kodlarını yazmaz isek sayfaya yönlendirmez 401 yetkisiz erişim sayar */
                FormsAuthentication.SetAuthCookie(adminInfo.AdminUserName, false);
                Session["AdminUserName"] = adminInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("HomePage","Home");
            }
        }
    }
}