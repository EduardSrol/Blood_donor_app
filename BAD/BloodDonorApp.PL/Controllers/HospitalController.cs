using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades;
using BloodDonorApp.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace BloodDonorApp.PL.Controllers
{
    public class HospitalController : Controller
    {
        #region Session

        public const int PageSize = 20;

        private const string FilterSessionKey = "filter";

        #endregion

        public HospitalFacade HospitalFacade { get; set; }

        // GET: Hospital
        public async Task<ActionResult> Index(int page = 1)
        {
            var filter = Session[FilterSessionKey] as HospitalFilterDto ?? new HospitalFilterDto { PageSize = PageSize };
            filter.RequestedPageNumber = page;

            var allHospitals = await HospitalFacade.GetHospitals(new HospitalFilterDto());
            var result = await HospitalFacade.GetHospitals(filter);

            var model = await InitializeHospitalListViewModel(result, (int)allHospitals.TotalItemsCount);
            return View("HospitalListView", model);
        }

        private async Task<HospitalListViewModel> InitializeHospitalListViewModel(QueryResultDto<HospitalDto, HospitalFilterDto> result, int totalItemsCount)
        {
            return new HospitalListViewModel
            {
                Hospitals = new StaticPagedList<HospitalDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, totalItemsCount),
                Filter = result.Filter
            };
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var user = await HospitalFacade.GetHospitalByIdAsync(id);
            return View("Details", user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(HospitalDto hospitaCreatelDto)
        {
            try
            {
                await HospitalFacade.CreateHospital(hospitaCreatelDto);

                return RedirectToAction("Index");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("SampleStation", "Sample Station cannot be created");
                return View();
            }
        }
    }
}