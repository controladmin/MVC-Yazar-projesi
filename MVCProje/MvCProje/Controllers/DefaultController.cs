using BusinessLayer.Concrete; //HeadingManager sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; //EFHeadingDal sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    /* herkesin erişebilmesi için izin verdik */
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        /* Bu sayfa projenin ana sayfası olacak herkesin erişimine serbest olacak */

        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());

        public ActionResult Headings()
        {
            var headings = hm.GetList();
            return View(headings);
        }
        public PartialViewResult Index(int id = 0)
        {
            /* ilk yüklediğinde id boş gelecek hata fırlatmasın diye default değer 0 verdik */
            var contentList = cm.GetListByHeadingId(id);
            return PartialView(contentList);
        }

        //public PartialViewResult Index(int? id)
        //{
        //    int _id = id ?? 0;
        //    if (_id != 0 && _id != null)
        //    {
        //        var contentList = cm.GetListByHeadingId(_id);
        //        return PartialView(contentList);
        //    }
        //    else
        //    {
        //        var contentList = cm.GetList();
        //        return PartialView(contentList);
        //    }
        //}
    }
}