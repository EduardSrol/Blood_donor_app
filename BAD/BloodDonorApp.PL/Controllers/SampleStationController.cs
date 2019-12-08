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
    public class SampleStationController : BaseController
    {
        #region Session

        public const int PageSize = 20;

        private const string FilterSessionKey = "filter";

        #endregion

        public SampleStationFacade SampleStationFacade { get; set; }
        // GET: SampleStation
        public async Task<ActionResult> Index(int page = 1)
        {
            var filter = Session[FilterSessionKey] as SampleStationFilterDto ?? new SampleStationFilterDto { PageSize = PageSize };
            filter.RequestedPageNumber = page;

            var allHospitals = await SampleStationFacade.GetSampleStations(new SampleStationFilterDto());
            var result = await SampleStationFacade.GetSampleStations(filter);

            var model = await InitializeSampleStationListViewModel(result, (int)allHospitals.TotalItemsCount);
            return View("SampleStationListView", model);
        }

        private async Task<SampleStationListViewModel> InitializeSampleStationListViewModel(QueryResultDto<SampleStationDto, SampleStationFilterDto> result, int totalItemsCount)
        {
            return new SampleStationListViewModel
            {
                SampleStations = new StaticPagedList<SampleStationDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, totalItemsCount),
                Filter = result.Filter
            };
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var user = await SampleStationFacade.GetSampleStationByIdAsync(id);
            return View("Details", user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(SampleStationDto sampleStationCreateDto)
        {
            try
            {
                await SampleStationFacade.CreateSampleStation(sampleStationCreateDto);
                return RedirectToAction("Index", "SampleStation");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("SampleStation", "Sample Station cannot be created");
                return View("Error", null, "Sample Station cannot be created (maybe it is already registered).");
            }
        }
    }
}