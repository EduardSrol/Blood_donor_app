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
    public class BloodDonationController : BaseController
    {
        #region Session

        public const int PageSize = 20;

        private const string FilterSessionKey = "filter";

        #endregion

        public BloodDonationFacade BloodDonationFacade { get; set; }
        // GET: BloodDonation
        public async Task<ActionResult> BloodDonationListView(int page = 1)
        {
            var filter = Session[FilterSessionKey] as BloodDonationFilterDto ?? new BloodDonationFilterDto { PageSize = PageSize };
            filter.RequestedPageNumber = page;

            var allUsers = await BloodDonationFacade.GetBloodDonations(new BloodDonationFilterDto());
            var result = await BloodDonationFacade.GetBloodDonations(filter);

            var model = await InitializeBloodDonationListViewModel(result, (int)allUsers.TotalItemsCount);
            return View("BloodDonationListView", model);
        }

        public async Task<ActionResult> Detail(Guid id)
        {
            var bloodDonation = await BloodDonationFacade.GetBloodDonationByIdAsync(id);
            return View("Detail", bloodDonation);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(BloodDonationDto bloodDonationDto)
        {
            try
            {
                await BloodDonationFacade.CreateBloodDonation(bloodDonationDto);

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("SampleStation", "Sample Station cannot be created");
                return View();
            }
        }

        private async Task<BloodDonationListViewModel> InitializeBloodDonationListViewModel(QueryResultDto<BloodDonationDto, BloodDonationFilterDto> result, int totalItemsCount)
        {
            return new BloodDonationListViewModel
            {
                BloodDonations = new StaticPagedList<BloodDonationDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, totalItemsCount),
                Filter = result.Filter
            };
        }
    }
}