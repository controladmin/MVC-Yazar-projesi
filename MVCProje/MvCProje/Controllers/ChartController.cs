using EntityLayer.Concrete; // Category sınıfını kullanabilmek için ekledik
using MvCProje.Models; // CategoryClass sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeadingPieChart()
        {
            return View();
        }
        public ActionResult WriterColumnChart()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }

        public List<WriterClass> WriterList()
        {
            List<WriterClass> rt = new List<WriterClass>();
            rt.Add(new WriterClass()
            {
                WriterName = "Yazılım",
                WriterCount = 8
            });
            rt.Add(new WriterClass()
            {
                WriterName = "Yazılım",
                WriterCount = 8
            });
            rt.Add(new WriterClass()
            {
                WriterName = "Yazılım",
                WriterCount = 8
            });
            rt.Add(new WriterClass()
            {
                WriterName = "Yazılım",
                WriterCount = 8
            });
            return rt;
        }

        public List<HeadingClass> HeadingList()
        {
            List<HeadingClass> ht = new List<HeadingClass>();
            ht.Add(new HeadingClass()
            {
                HeadingName = "Yazılım",
                ContentCount = 8
            });
            ht.Add(new HeadingClass()
            {
                HeadingName = "Yazılım",
                ContentCount = 8
            });
            ht.Add(new HeadingClass()
            {
                HeadingName = "Yazılım",
                ContentCount = 8
            });
            ht.Add(new HeadingClass()
            {
                HeadingName = "Yazılım",
                ContentCount = 8
            });
            return ht;
        }
    }
}