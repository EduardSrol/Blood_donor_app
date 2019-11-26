using BloodDonorApp.BL.EF.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BloodDonorApp.PL.Controllers
{
    public class HomeController : Controller
    {
        public CommonUserFacade CommonUserFacade { get; set; }


        public async Task<ActionResult> Index()
        {
            var user = await CommonUserFacade.GetCommonUserByUun(2);
            return View(user.FullName);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}