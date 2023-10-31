using BusinessLayer.Concrete; //ImageManager sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFImageDal sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        ImageManager im = new ImageManager(new EFImageDal());
        public ActionResult Index()
        {
            var imageValues = im.GetList();
            return View(imageValues);
        }
    }
}