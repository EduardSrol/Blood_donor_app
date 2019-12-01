using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace BloodDonorApp.PL.Models
{
    public class CommonUserListViewModel
    {
        public IPagedList<CommonUserDto> Users { get; set; }

        public CommonUserFilterDto Filter { get; set; }
    }
}