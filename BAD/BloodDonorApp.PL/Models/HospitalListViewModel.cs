using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace BloodDonorApp.PL.Models
{
    public class HospitalListViewModel
    {
        public IPagedList<HospitalDto> Hospitals { get; set; }

        public HospitalFilterDto Filter { get; set; }
    }
}