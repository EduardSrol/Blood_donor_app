using BloodDonorApp.BL.EF.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonorApp.PL.Controllers
{
    public class SampleStationController : Controller
    {
        #region Session

        public const int PageSize = 20;

        private const string FilterSessionKey = "filter";

        #endregion

        public SampleStationFacade SampleStationFacade { get; set; }
        // GET: SampleStation
        public ActionResult Index()
        {
            return View();
        }
    }
}