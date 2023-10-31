using BusinessLayer.Concrete; // WriterManager sınıfını kullanabilmek için ekliyoruz
using BusinessLayer.FluentValidationRules; // WriterValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFWriterDal sınıfını kullanabilmek için ekliyoruz
using EntityLayer.Concrete; // Writer sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için ekledik
using MvCProje.Models; // sifrele sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.IO; // Path kullanabilmek için ekledik
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; // Sayfalama işlemleri için ekliyoruz
using PagedList.Mvc; // Sayfalama işlemleri için ekliyoruz

namespace MvCProje.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer

        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index(int sayfa=1)
        {
            var writerValues = wm.GetList().ToPagedList(sayfa, 5);
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer,HttpPostedFileBase file)
        {
         
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);
            if(result.IsValid)
            {
                if(file!=null && file.ContentLength>0)
                {
                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string imagePath = Path.Combine(Server.MapPath("/YazarResmi/"), dosyaAdi);
                    file.SaveAs(imagePath);
                    writer.WriterImage = "/YazarResmi/" + dosyaAdi;
                }
                var sifre = Sifrele.MD5Crypto(writer.WriterPassword);
                writer.WriterPassword = sifre;
                wm.WriterAdd(writer);
                TempData["writer"] = "Ekleme";
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var updateValues = wm.GetById(id);
            return View(updateValues);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer writer, HttpPostedFileBase file)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);
            if(result.IsValid)
            {                            
                    if (file != null && file.ContentLength > 0)
                    {
                        
                        string dosyaAdi = Path.GetFileName(file.FileName);
                        string imagePath = Path.Combine(Server.MapPath("/YazarResmi/"), dosyaAdi);
                        file.SaveAs(imagePath);
                        writer.WriterImage = "/YazarResmi/" + dosyaAdi;
                    }
                var sifre = Sifrele.MD5Crypto(writer.WriterPassword);
                writer.WriterPassword = sifre;
                wm.WriterUpdate(writer);
                TempData["writer"] = "Güncelleme";
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteWriter(int id)
        {
            var deleteWriter = wm.GetById(id);
            wm.WriterDelete(deleteWriter);
            TempData["writer"] = "Delete";
            return RedirectToAction("Index");
        }
    }
}