using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace BloodDonorApp.PL.Models
{
    public class ApplicantListViewModel
    {
        public IPagedList<CommonUserDto> Applicants { get; set; }

        public CommonUserFilterDto Filter { get; set; }
    }
}