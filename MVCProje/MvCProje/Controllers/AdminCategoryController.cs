using BusinessLayer.Concrete; // CategoryManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // CategoryValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFCategoryDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Category sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; // Sayfalama işlemleri için ekliyoruz
using PagedList.Mvc; // Sayfalama işlemleri için ekliyoruz

namespace MvCProje.Controllers
{

    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory

        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        /* Giriş yapmamıs kişi bu sayfaya erişemeyecek index sayfasını sadece giriş yapan kişiler görebilecek */
        /* Rol ataması A olanlar sadece burayı görebilecek */
        //[Authorize(Roles = "A")]
        public ActionResult Index(int sayfa=1)
        {
            var categoryValues = cm.GetList().ToPagedList(sayfa, 10);
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
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(category);
            if(result.IsValid)
            {
                cm.CategoryAdd(category);
                TempData["information"] = "Ekleme";
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
        public ActionResult DeleteCategory(int id)
        {
            var deletecategory = cm.GetById(id);
            cm.CategoryDelete(deletecategory);
            TempData["information"] = "Delete";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var updatecategoty = cm.GetById(id);
            return View(updatecategoty);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(category);
            if (result.IsValid)
            {
                cm.CategoryUpdate(category);
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

    }
}