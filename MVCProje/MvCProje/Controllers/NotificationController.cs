using MvCProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
          ViewBag.s=Sifrele.MD5Crypto("1234");
            ViewBag.s1 = Sifrele.MD5Crypto1("1234");
            return View();
        }
    }
}