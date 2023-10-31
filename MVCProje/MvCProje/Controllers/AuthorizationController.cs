using BusinessLayer.Concrete; // AdminManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // AdminValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFAdminDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Admin sınıfını kullanabilmek için ekledik
using FluentValidation.Results; //  ValidationResult sınıfını kullanabilmek için ekledik
using MvCProje.Models; // Sifrele sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; // Sayfalama işlemleri için ekliyoruz
using PagedList.Mvc; // Sayfalama işlemleri için ekliyoruz

namespace MvCProje.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        // GET: Authorization

        AdminManager adm = new AdminManager(new EFAdminDal());
        RoleManager rm = new RoleManager(new EFRoleDal());
        public ActionResult Index(int sayfa=1)
        {
            var adminValues = adm.GetList().ToPagedList(sayfa, 5);
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {

            List<SelectListItem> valueRole = (from c in rm.GetRoles()
                                              select new SelectListItem
                                              {
                                                  Text = c.RoleName,
                                                  Value = c.RoleId.ToString()

                                              }).ToList();

            ViewBag.adminrole = valueRole;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin,HttpPostedFileBase file)
        {
            AdminValidator validator = new AdminValidator();
            ValidationResult result = validator.Validate(admin);

            if (!result.IsValid)
            {
                List<SelectListItem> valueRole = (from c in rm.GetRoles()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.RoleName,
                                                      Value = c.RoleId.ToString()

                                                  }).ToList();

                ViewBag.adminrole = valueRole;
            }

            if (result.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {

                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string imagePath = Path.Combine(Server.MapPath("/AdminResmi/"), dosyaAdi);
                    file.SaveAs(imagePath);
                    admin.AdminImage = "/AdminResmi/" + dosyaAdi;
                }
                var sifre = Sifrele.MD5Crypto(admin.AdminPassword);
                admin.AdminPassword = sifre;
                adm.AdminAdd(admin);
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

        public ActionResult DeleteAdmin(int id)
        {
            var deleteAdmin = adm.GetById(id);
            adm.AdminDelete(deleteAdmin);
            TempData["information"] = "Delete";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {

            List<SelectListItem> valueRole = (from c in rm.GetRoles()
                                              select new SelectListItem
                                              {
                                                  Text = c.RoleName,
                                                  Value = c.RoleId.ToString()

                                              }).ToList();

            ViewBag.adminrole = valueRole;



            var updateAdmin = adm.GetById(id);
            return View(updateAdmin);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin,HttpPostedFileBase file)
        {
            AdminValidator validator = new AdminValidator();
            ValidationResult result = validator.Validate(admin);
            if(!result.IsValid)
            {
                List<SelectListItem> valueRole = (from c in rm.GetRoles()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.RoleName,
                                                      Value = c.RoleId.ToString()

                                                  }).ToList();

                ViewBag.adminrole = valueRole;
            }
            if (result.IsValid)
            {

            

                if (file != null && file.ContentLength > 0)
                {

                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string imagePath = Path.Combine(Server.MapPath("/AdminResmi/"), dosyaAdi);
                    file.SaveAs(imagePath);
                    admin.AdminImage = "/AdminResmi/" + dosyaAdi;
                }
                var sifre = Sifrele.MD5Crypto(admin.AdminPassword);
                admin.AdminPassword = sifre;
                adm.AdminUpdate(admin);
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

        public ActionResult StatusChangeAdmin(int id)
        {
            var adminValue = adm.GetById(id);
            adm.adminStatusChange(adminValue);
            TempData["information"] = "Change";
            return RedirectToAction("Index");
        }
    }
}