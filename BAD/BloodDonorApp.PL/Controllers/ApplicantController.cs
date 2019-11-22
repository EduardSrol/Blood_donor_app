using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;
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
    public class ApplicantController : Controller
    {
        #region Session

        public const int PageSize = 20;

        private const string FilterSessionKey = "filter";

        #endregion

        public CommonUserFacade CommonUserFacade { get; set ; }


        // GET: Applicant
        public async Task<ActionResult> Index(int page = 1)
        {
            var filter = Session[FilterSessionKey] as CommonUserFilterDto ?? new CommonUserFilterDto { PageSize = PageSize };
            filter.RequestedPageNumber = page;

            var allApplicants = await CommonUserFacade.GetCommonUsers(new CommonUserFilterDto());
            var result = await CommonUserFacade.GetCommonUsers(filter);

            var model = await InitializeProductListViewModel(result, (int)allApplicants.TotalItemsCount);

            return View("AppplicantsListView", model);
        }

        private async Task<ApplicantListViewModel> InitializeProductListViewModel(QueryResultDto<CommonUserDto, CommonUserFilterDto> result, int totalItemsCount)
        {
            return new ApplicantListViewModel
            {
                Applicants = new StaticPagedList<CommonUserDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, totalItemsCount),
                Filter = result.Filter
            };
        }
    }
}