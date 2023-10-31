using BusinessLayer.Concrete; // HeadingManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // HeadingValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.Concrete; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFHeadingDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Heading sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; // Sayfalama işlemleri için ekliyoruz
using PagedList.Mvc; // Sayfalama işlemleri için ekliyoruz
using System.IO; // Path sınıfını kullanabilmek için ekledik

namespace MvCProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile()
        {
            string writerMail = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterId).FirstOrDefault();
      
            var writerValue = wm.GetById(writerIdInfo);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer, HttpPostedFileBase file)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {
                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string imagePath = Path.Combine(Server.MapPath("/YazarResmi/"), dosyaAdi);
                    file.SaveAs(imagePath);
                    writer.WriterImage = "/YazarResmi/" + dosyaAdi;
                }
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading");
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
        public ActionResult MyHeading(string p,int sayfa=1)
        {
            
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var headingValues = hm.GetListByWriter(writerIdInfo).ToPagedList(sayfa, 5);
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddNewHeading()
        {
         
            /* Başlık eklerken kategori seçebilmek için yazılan kod parçası */
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vwcategory = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewHeading(Heading heading)
        {
            string writermailInfo = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == writermailInfo).Select(y => y.WriterId).FirstOrDefault();

            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(heading);
            if(!result.IsValid)
            {
                List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CategoryName,
                                                          Value = x.CategoryId.ToString()
                                                      }).ToList();
                ViewBag.vwcategory = valueCategory;
            }
            if (result.IsValid)
            {

                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                heading.WriterId = writerIdInfo;
                heading.HeadingStatus = true;
                hm.HeadingAdd(heading);
                TempData["heading"] = "Ekleme";
                return RedirectToAction("MyHeading");
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
        public ActionResult UpdateHeading(int id)
        {
            /* Başlık eklerken kategori seçebilmek için yazılan kod parçası */
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vwcategory = valueCategory;
            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }


        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            HeadingValidator validator = new HeadingValidator();
            ValidationResult result = validator.Validate(heading);
            if (!result.IsValid)
            {
                List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CategoryName,
                                                          Value = x.CategoryId.ToString()
                                                      }).ToList();
                ViewBag.vwcategory = valueCategory;
            }
            if (result.IsValid)
            {
                hm.HeadingUpdate(heading);
                TempData["heading"] = "Güncelleme";
                return RedirectToAction("MyHeading");
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
        public ActionResult DeleteHeading(int id)
        {
            var deleteheading = hm.GetByID(id);
            hm.HeadingDelete(deleteheading);
            TempData["heading"] = "Delete";
            return RedirectToAction("MyHeading");

        }
        public ActionResult StatusChangeHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            hm.HedaingStatusChange(headingValue);
            TempData["heading"] = "Change";
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int sayfa=1)
        {
            /* sayfa=1 sayfalama işleminin kaçtan başlayacağı anlamına gelmektedir */
            /* @model PagedList.IPagedList<Heading> model kısmında bu şekilde ayarlamamız gerek yoksa hata verir view sayfasınıda sayfalama şeklinde ayarlamamız gerek */
            var allHeadings = hm.GetList().ToPagedList(sayfa, 5);
            return View(allHeadings);
        }
    }
}