using BusinessLayer.Concrete; // ContactManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // ContactValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFContactDal sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator validator = new ContactValidator();
        ValidationResult result;
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult MesajListBox()
        {
            return PartialView();
        }
    }
}