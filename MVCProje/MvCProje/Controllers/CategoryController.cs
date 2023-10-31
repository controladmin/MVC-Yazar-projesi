using BusinessLayer.Concrete; // CategoryManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // CategoryValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFCategoryDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Caegory sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
 //using System.ComponentModel.DataAnnotations; // ValidationResult sınıfını kullanabilmek için ekledik bu açık kalırsa hata fırlatır
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; // Sayfalama işlemleri için ekliyoruz
using PagedList.Mvc; // Sayfalama işlemleri için ekliyoruz

namespace MvCProje.Controllers
{

    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
      
        public ActionResult Index(int sayfa=1)
        {
            var categoryValues = cm.GetList().ToPagedList(sayfa, 5);
            return View(categoryValues);
        }
        public ActionResult GetCategoryList()
        {

            /* Eski yöntem kullanım */
            //var categoryValues = cm.GetAllBL();

            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            /* Eski yöntem kullanım */
            //cm.CategoryAddBL(category);
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(category);
            if (result.IsValid)
            {
                cm.CategoryAdd(category);
                TempData["information"] = "Ekleme";
                return RedirectToAction("GetCategoryList","Category");
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
    }
}