using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace BloodDonorApp.PL.Models
{
    public class SampleStationListViewModel
    {
        public IPagedList<SampleStationDto> SampleStations { get; set; }

        public SampleStationFilterDto Filter { get; set; }

    }
}