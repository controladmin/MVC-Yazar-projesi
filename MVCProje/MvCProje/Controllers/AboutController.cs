using BusinessLayer.Concrete; // AboutManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // AboutValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFAboutDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // About sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; // Sayfalama işlemleri için ekliyoruz
using PagedList.Mvc; // Sayfalama işlemleri için ekliyoruz
using MvCProje.Models; // ToastNotify kullanabilmek için ekledik

namespace MvCProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EFAboutDal());
        public ActionResult Index(int sayfa=1)
        {
            var aboutValue = abm.GetList().ToPagedList(sayfa, 5);
            return View(aboutValue);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about, HttpPostedFileBase file)
        {
            AboutValidator validator = new AboutValidator();
            ValidationResult result = validator.Validate(about);
            if (result.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {

                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string imagePath = Path.Combine(Server.MapPath("/AboutResim/"), dosyaAdi);
                    file.SaveAs(imagePath);
                    about.AboutImage = "/AboutResim/" + dosyaAdi;
                }
                about.Status = true;
                abm.AboutAdd(about);
                TempData["information"] = "Ekleme";
                return RedirectToAction("Index");
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
        public PartialViewResult AddAboutPartial()
        {
            /* Partial view sayfasını index sayfasında istediğimiz yerde çağırabiliriz*/
            return PartialView();
        }
        public ActionResult DeleteAbout(int id)
        {
            var deleteabout = abm.GetById(id);
            abm.AboutDelete(deleteabout);
            TempData["information"] = "Delete";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var updateAbout = abm.GetById(id);
            return View(updateAbout);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about, HttpPostedFileBase file)
        {
            AboutValidator validator = new AboutValidator();
            ValidationResult result = validator.Validate(about);
            if (result.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {

                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string imagePath = Path.Combine(Server.MapPath("/AboutResim/"), dosyaAdi);
                    file.SaveAs(imagePath);
                    about.AboutImage = "/AboutResim/" + dosyaAdi;
                }
                about.Status = true;
                abm.AboutUpdate(about);
                TempData["information"] = "Güncelleme";
                return RedirectToAction("Index");
               
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

        public ActionResult StatusChangeAbout(int id)
        {
            var aboutValue = abm.GetById(id);
            abm.AboutStatusChange(aboutValue);
            TempData["information"] = "Change";
            return RedirectToAction("Index");
        }
    }
}