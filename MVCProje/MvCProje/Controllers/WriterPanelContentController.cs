using BusinessLayer.Concrete; // ContentManger sınıfını kullanabilmek için ekledik
using BusinessLayer.FluentValidationRules; // ContentValidator sınıfını kullanabilmek için ekledik
using DataAccessLayer.Concrete; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFContentDal sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Content sınıfını kullanabilmek için ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult WriterContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            //var writerIdInfo = 2;
            var contetValues = cm.GetListByWriter(writerIdInfo);
            return View(contetValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.headingId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            ContentValidator validator = new ContentValidator();
            ValidationResult result = validator.Validate(content);
            if (result.IsValid)
            {
               string mail= (string)Session["WriterMail"];
                var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
                content.WriterId = writerIdInfo;
                content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                content.ContentStatus = true;
                cm.ContentAdd(content);
                TempData["content"] = "Ekleme";
                return RedirectToAction("WriterContent");
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

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}