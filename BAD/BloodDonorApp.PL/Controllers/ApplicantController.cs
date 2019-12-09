using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades;
using BloodDonorApp.PL.App_Start.Windsor;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.PL.Models;
using Castle.Windsor;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using X.PagedList;

namespace BloodDonorApp.PL.Controllers
{
    public class ApplicantController : BaseController
    {
        #region Session

        public const int PageSize = 50;

        private const string FilterSessionKey = "filter";

        #endregion

        public CommonUserFacade CommonUserFacade { get; set ; }


        // GET: Applicant
        public async Task<ActionResult> Index(int page = 1)
        {
            var filter = Session[FilterSessionKey] as CommonUserFilterDto ?? new CommonUserFilterDto { PageSize = PageSize };
            filter.RequestedPageNumber = page;

            var allApplicants = await CommonUserFacade.GetCommonUsers(new CommonUserFilterDto { UserTypes = new[] { UserType.Applicant } });
            var result = await CommonUserFacade.GetCommonUsers(filter);

            var model = await InitializeApplicantListViewModel(result, (int)allApplicants.TotalItemsCount);
            return View("ApplicantListView", model);
        }

        private async Task<ApplicantListViewModel> InitializeApplicantListViewModel(QueryResultDto<CommonUserDto, CommonUserFilterDto> result, int totalItemsCount)
        {
            return new ApplicantListViewModel
            {
                Applicants = new StaticPagedList<CommonUserDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, totalItemsCount),
                Filter = result.Filter
            };
        }

        public async Task<ActionResult> Detail(Guid id)
        {
            var commonUser = await CommonUserFacade.GetApplicantByIdAsync(id);
            return View("Detail", commonUser);
        }
    }
}