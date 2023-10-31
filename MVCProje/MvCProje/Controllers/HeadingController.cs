using BusinessLayer.Concrete; // HeadingManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // HeadingValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.Concrete; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFHeadingDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Heading sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; // Sayfalama işlemleri için ekliyoruz
using PagedList.Mvc; // Sayfalama işlemleri için ekliyoruz


namespace MvCProje.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var headingValues = hm.GetList().ToPagedList(sayfa,5);
            return View(headingValues);
        }
        public ActionResult HeadingReport()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            /* Başlık eklerken kategori seçebilmek için yazılan kod parçası */
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vcategory = valueCategory;


            /* Başlık eklerken yazar seçebilmek için yazılan kod parçası session'dan aldığımız için buna gerek kalmadı */
            //List<SelectListItem> valueWriter = (from x in wm.GetList()
            //                                    select new SelectListItem
            //                                    {
            //                                        Text = x.WriterName + " " + x.WriterSurname,
            //                                        Value = x.WriterId.ToString()
            //                                    }).ToList();
            //ViewBag.vwriter = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
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
                ViewBag.vcategory = valueCategory;
            }
            if (result.IsValid)
            {
                string mail = (string)Session["WriterMail"];
                var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
                heading.WriterId = writerIdInfo;
                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.HeadingAdd(heading);
                TempData["heading"] = "Ekleme";
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

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            /* Başlık eklerken kategori seçebilmek için yazılan kod parçası */
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vcategory = valueCategory;


            /* Başlık eklerken yazar seçebilmek için yazılan kod parçası sessiondan aldığımız için buna gerek kalmadı */
            //List<SelectListItem> valueWriter = (from x in wm.GetList()
            //                                    select new SelectListItem
            //                                    {
            //                                        Text = x.WriterName + " " + x.WriterSurname,
            //                                        Value = x.WriterId.ToString()
            //                                    }).ToList();
            //ViewBag.vwriter = valueWriter;


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
                ViewBag.vcategory = valueCategory;
            }
            if (result.IsValid)
            {           
                hm.HeadingUpdate(heading);
                TempData["heading"] = "Güncelleme";
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
        public ActionResult DeleteHeading(int id)
        {
            var deleteheading = hm.GetByID(id);
            hm.HeadingDelete(deleteheading);
            TempData["heading"] = "Delete";
            return RedirectToAction("Index");

        }
        public ActionResult StatusChangeHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            hm.HedaingStatusChange(headingValue);
            TempData["heading"] = "Change";
            return RedirectToAction("Index");
        }

    }
}