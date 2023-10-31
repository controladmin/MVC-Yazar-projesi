using BusinessLayer.Concrete; // RoleManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // RoleValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFRoleDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Role sınıfını kullanabilmek için ekledik
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
    public class RoleController : Controller
    {
        // GET: Role
        RoleManager rm = new RoleManager(new EFRoleDal());
        public ActionResult Index(int sayfa=1)
        {
            var valueRole = rm.GetRoles().ToPagedList(sayfa, 5);
            return View(valueRole);
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            RoleValidator validator = new RoleValidator();
            ValidationResult result = validator.Validate(role);
            if(result.IsValid)
            {
                rm.RoleAdd(role);
                TempData["role"] = "Ekleme";
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
        public ActionResult DeleteRole(int id)
        {
           var deleteRole= rm.GetById(id);
            rm.RoleDelete(deleteRole);
            TempData["role"] = "Delete";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateRole(int id)
        {
            var updateRole = rm.GetById(id);
            return View(updateRole);
        }
        [HttpPost]
        public ActionResult UpdateRole(Role role)
        {
            RoleValidator validator = new RoleValidator();
            ValidationResult result = validator.Validate(role);
            if (result.IsValid)
            {
                rm.RoleAdd(role);
                TempData["role"] = "Güncelleme";
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