using BloodDonorApp.BL.EF.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BloodDonorApp.PL.Controllers
{
    public class HomeController : BaseController
    {
        public CommonUserFacade CommonUserFacade { get; set; }


        public ActionResult Index()
        {
            var x = currentUser?.UserName;
            return View();
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