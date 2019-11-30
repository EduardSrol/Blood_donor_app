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
    public class CommonUserController : Controller
    {
        #region Session

        public const int PageSize = 20;

        private const string FilterSessionKey = "filter";

        #endregion

        public CommonUserFacade CommonUserFacade { get; set; }


        // GET: Applicant
        public async Task<ActionResult> Index(int page = 1)
        {
            var filter = Session[FilterSessionKey] as CommonUserFilterDto ?? new CommonUserFilterDto { PageSize = PageSize };
            filter.RequestedPageNumber = page;

            var allUsers = await CommonUserFacade.GetCommonUsers(new CommonUserFilterDto ());
            var result = await CommonUserFacade.GetCommonUsers(filter);

            var model = await InitializeCommonUserListViewModel(result, (int)allUsers.TotalItemsCount);
            return View("UserListView", model);
        }
        
        [HttpPost]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await CommonUserFacade.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUserSoft(Guid id)
        {
            await CommonUserFacade.DeleteUserSoftAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditExtended(CommonUserEditProfileExtendedDto user)
        {
            CommonUserFacade.Update(user);
            return View("EditExtended", user);
        }
        public async Task<ActionResult> EditExtended(Guid id)
        {
            var editUserDto = await CommonUserFacade.GetCommonUserEditExtendedDto(id);
            return View("EditExtended", editUserDto);
        }
        
        private async Task<CommonUserListViewModel> InitializeCommonUserListViewModel(QueryResultDto<CommonUserDto, CommonUserFilterDto> result, int totalItemsCount)
        {
            return new CommonUserListViewModel
            {
                Users = new StaticPagedList<CommonUserDto>(result.Items, result.RequestedPageNumber ?? 1, PageSize, totalItemsCount),
                Filter = result.Filter
            };
        }
    }
}