using BusinessLayer.Concrete; // COntentManager sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // ContentValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.Concrete; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFContentDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Content sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // Validationresult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; // Sayfalama işlemleri için ekliyoruz
using PagedList.Mvc; // Sayfalama işlemleri için ekliyoruz

namespace MvCProje.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string searchContent,int sayfa=1)
        {
            /* searchContent null ise tüm değerler geliyor */
            if(string.IsNullOrEmpty(searchContent))
            {
                var allList = cm.GetList().ToPagedList(sayfa, 5);
                return View(allList);
            }
            var searchValues = cm.GetListSearch(searchContent).ToPagedList(sayfa, 5);
            return View(searchValues);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contetValues = cm.GetListByHeadingId(id);
            return View(contetValues);
        }
        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            ContentValidator validator = new ContentValidator();
            ValidationResult result = validator.Validate(content);
            if(result.IsValid)
            {
                string mail = (string)Session["WriterMail"];
                var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
                content.WriterId = writerIdInfo;
                content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                content.ContentStatus = true;
                cm.ContentAdd(content);
                return RedirectToAction("ContentByHeading");
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