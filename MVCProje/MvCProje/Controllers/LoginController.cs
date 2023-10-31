using BusinessLayer.Concrete; // AdminManager sınıfını kullanabilmek için ekledik
using DataAccessLayer.Concrete; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFAdminDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Admin Sınıfını kullanabilmek için ekledik
using MvCProje.Models; // Sifrele sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail; // SmtpClient sınıfını kullanabilmek için ekledik
using System.Web;
using System.Web.Mvc;
using System.Web.Security; // Session işlemleri için bu kütüphaneyi ekliyoruz
using System.Net;

namespace MvCProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adm = new AdminManager(new EFAdminDal());
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            Context c = new Context();
            var adminSifre = Sifrele.MD5Crypto(admin.AdminPassword);
            var adminInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == adminSifre);
            if(adminInfo!=null)
            {
                /* sisteme giriş yapan kullanıcının bilgilerini alıyoruz çerezlere ekliyoruz yetkili sayfalara erişebilsin diye*/
                /* kalıcı Cookie oluşsun mu diye ikinci parametre istiyor o yüzden false yaptık kalıcı oluşmasın diye */
                /* Bu session kodlarını yazmaz isek sayfaya yönlendirmez 401 yetkisiz erişim sayar */
                FormsAuthentication.SetAuthCookie(adminInfo.AdminUserName,false);
                Session["AdminUserName"] = adminInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Login");
            }
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
            var writerSifre = Sifrele.MD5Crypto(writer.WriterPassword);
            var writeruserInfo = wlm.GetWriter(writer.WriterMail, writerSifre);
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
                return RedirectToAction("WriterLogin");
            }            
        }

        public ActionResult WriterLogOut()
        {
            /*Çıkış işlemi için bu kadar işlem yapıyoruz başka alanda başka bir kod yazmıyoruz */
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }

        public ActionResult AdminLogOut()
        {
            /*Çıkış işlemi için bu kadar işlem yapıyoruz başka alanda başka bir kod yazmıyoruz */
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Login");
        }

    }
}