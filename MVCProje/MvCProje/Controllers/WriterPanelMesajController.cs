using BusinessLayer.Concrete; // MesajManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // MesajValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.Concrete; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFMesajDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Mesaj Sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    public class WriterPanelMesajController : Controller
    {
        // GET: WriterPanelMesaj
        MesajManager mm = new MesajManager(new EFMesajDal());
        Context c = new Context();
        public ActionResult GelenMesajlar()
        {
            string p = (string)Session["WriterMail"];
            var gelenmesajlar = mm.GetListGelenMesajlar(p);
            return View(gelenmesajlar);
        }

        public PartialViewResult MesajListMenu()
        {
            return PartialView();
        }

        public ActionResult GonderilenMesajlar()
        {
            string p = (string)Session["WriterMail"];
            var gonderilenMesajlar = mm.GetListGonderilenMesajlar(p);
            return View(gonderilenMesajlar);
        }

        public ActionResult GetGelenMesajDetails(int id)
        {
            var gelenmesajDetay = mm.GetById(id);
            return View(gelenmesajDetay);
        }
        [Authorize]
        public ActionResult GetGonderilenMesajDetails(int id)
        {
            var gonderilenmesajDetay = mm.GetById(id);
            return View(gonderilenmesajDetay);
        }

        public ActionResult YeniMesaj()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj mesaj)
        {
            string gondericiMail = (string)Session["WriterMail"];
            MesajValidator validator = new MesajValidator();
            ValidationResult result = validator.Validate(mesaj);
            if (result.IsValid)
            {
                mesaj.GondericiMail = gondericiMail;
                mesaj.MesajTarihi = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                mm.MesajAdd(mesaj);
                TempData["mesaj"] = "Ekleme";
                return RedirectToAction("GonderilenMesajlar");
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