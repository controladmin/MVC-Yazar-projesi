using BusinessLayer.Concrete; // MesajManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // MesajValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFMesajDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete; // Mesaj sınıfını kullanabilmek için ekledik
using FluentValidation.Results; //  ValidationResult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        MesajManager mm = new MesajManager(new EFMesajDal());
        /* Yetkisiz girişlerde girilemsin diye sadece oturum olarak giren kişiler erişebilir */
        [Authorize]
        public ActionResult GelenMesajlar(string p)
        {

            var gelenMesajlar = mm.GetListGelenMesajlar(p);
            return View(gelenMesajlar);

        }
        [Authorize]
        public ActionResult GonderilenMesajlar(string p)
        {
            var gonderilenMesajlar = mm.GetListGonderilenMesajlar(p);
            return View(gonderilenMesajlar);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj mesaj)
        {
            MesajValidator validator = new MesajValidator();
            ValidationResult result = validator.Validate(mesaj);
            if(result.IsValid)
            {
                mesaj.MesajTarihi =Convert.ToDateTime(DateTime.Now.ToShortDateString());
                mm.MesajAdd(mesaj);
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
        [Authorize]
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

        public ActionResult GetAllMesaj(string searchContent)
        {
            /* searchContent null ise tüm değerler geliyor */
            if (string.IsNullOrEmpty(searchContent))
            {
                return View(mm.GetListGelenMesajlar(searchContent));
            }
            var searchValues = mm.GetListSearch(searchContent);
            return View(searchValues);
        }
    }
}