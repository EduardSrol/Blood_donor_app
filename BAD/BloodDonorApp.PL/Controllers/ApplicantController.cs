using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades;
using BloodDonorApp.BL.EF.DTO.Enums;
using BloodDonorApp.PL.Models;
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
        [HttpGet]
        public async Task<ActionResult> Index(int page = 1)
        {
            var filter = Session[FilterSessionKey] as CommonUserFilterDto ?? new CommonUserFilterDto { PageSize = PageSize };
            filter.RequestedPageNumber = page;

            var allApplicants = await CommonUserFacade.GetCommonUsers(new CommonUserFilterDto { UserTypes = new[] { UserType.Applicant } });
            var result = await CommonUserFacade.GetCommonUsers(filter);

            var model = InitializeApplicantListViewModel(result, (int)allApplicants.TotalItemsCount);
            return View("ApplicantListView", model);
        }

        [HttpPost]

        public async Task<ActionResult> Filter()
        {
            BloodType[] bloodTypes = new[] { BloodType.ABminus, BloodType.ABplus, BloodType.Aminus, BloodType.Aplus, BloodType.Bminus, BloodType.Bplus, BloodType.Ominus, BloodType.Oplus};

            if (Enum.TryParse(Request.Form["Blood_type"], out BloodType bloodType))
            {
                bloodTypes = new[] { bloodType };
            }

            var filter = Session[FilterSessionKey] as CommonUserFilterDto ?? new CommonUserFilterDto { UserTypes = new[] { UserType.Applicant }, BloodTypes = bloodTypes };

            if (Int32.TryParse(Request.Form["UUN"], out int uun)) {
                filter.UUN = uun;
            }

            var allApplicants = await CommonUserFacade.GetCommonUsers(new CommonUserFilterDto {});
            var result = await CommonUserFacade.GetCommonUsers(filter);

            var model = InitializeApplicantListViewModel(result, (int)allApplicants.TotalItemsCount);
            return View("ApplicantListView", model);
        }

        private ApplicantListViewModel InitializeApplicantListViewModel(QueryResultDto<CommonUserDto, CommonUserFilterDto> result, int totalItemsCount)
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