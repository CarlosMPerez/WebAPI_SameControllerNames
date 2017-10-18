using System.Web.Mvc;

namespace WebAPI_SameNames.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
