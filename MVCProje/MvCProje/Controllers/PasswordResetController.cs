using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvCProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
   [AllowAnonymous]
    public class PasswordResetController : Controller
    {
        // GET: PasswordReset
        AdminManager adm = new AdminManager(new EFAdminDal());
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

             [HttpGet]
        public ActionResult AdminSifreReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminSifreReset(Admin admin)
        {
            var _admin = c.Admins.Where(x => x.AdminMail == admin.AdminMail).FirstOrDefault();
            if (_admin != null)
            {
                Guid rastgele = Guid.NewGuid();
                var adminYeniSifre = rastgele.ToString().Substring(0, 8);
                _admin.AdminPassword = Sifrele.MD5Crypto(adminYeniSifre);
                c.SaveChanges();
                /* mail sunucusu*/
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kahyaali@gmail.com", "Şifre Sıfırlama");
                mail.To.Add(_admin.AdminMail);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre değiştirme talebi";
                mail.Body += "Merhaba" + _admin.AdminUserName + "<br/>Kullanıcı Adınız= " + _admin.AdminUserName + "<br/> Şifreniz= " +adminYeniSifre;
                NetworkCredential network = new NetworkCredential("kahyaalii@gmail.com", "gotkllpxssbwhalz");
                client.Credentials = network;
                client.Send(mail);
                return RedirectToAction("Login","Login");
            }
            ViewBag.hata = "Böyle bir mail adresi mevcut değil!!!";
            return View();
        }

        [HttpGet]
        public ActionResult WriterSifreReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterSifreReset(Writer writer)
        {
            var _writer = c.Writers.Where(x => x.WriterMail == writer.WriterMail).FirstOrDefault();
            if (_writer != null)
            {
                Guid rastgele = Guid.NewGuid();
               var writerYeniSifre= rastgele.ToString().Substring(0, 8);

                _writer.WriterPassword = Sifrele.MD5Crypto(writerYeniSifre);
                c.SaveChanges();
                /* mail sunucusu*/
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("deneme@deneme.com", "Şifre Sıfırlama");
                mail.To.Add(_writer.WriterMail);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre değiştirme talebi";
                mail.Body += "Merhaba" + _writer.WriterName + "<br/>Kullanıcı Adınız= " + _writer.WriterMail + "<br/> Şifreniz= " +writerYeniSifre;
                NetworkCredential network = new NetworkCredential("deneme@deneme.com", "gmail için çift adımlı doğrulama şifresi gelecek");
                client.Credentials = network;
                client.Send(mail);
                return RedirectToAction("WriterLogin","Login");
            }
            ViewBag.hata = "Böyle bir mail adresi mevcut değil!!!";
            return View();
        }
    }
}