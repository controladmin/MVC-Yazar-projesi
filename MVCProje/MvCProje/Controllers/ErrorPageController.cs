using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvCProje.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Page403()
        {
            /* bir http durum kodudur. yani ulaşmaya çalıştığınız sayfaya veya kaynağa erişimin bazı nedenlerle kesinlikle yasak olduğu anlamına gelir */
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult Page404()
        {
            /* istenilen dosyanın ilgili web sitesinin server sisteminde bulunamadığı anlamına gelir. aslında kullanıcı sunucuya bağlanabiliyor ancak istediği sunucuya erişemiyor */
            /* bu metotları oluşturduktan sonra Web.Config dosyası içindede işlem yapıyoruz system web içine  
             <customErrors mode="on">
              <error statusCode="404" redirect="/ErrorPage/Page404/"/>
             </customErrors> bu kodu yazıyoruz*/
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}