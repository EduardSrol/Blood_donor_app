﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonorApp.BL.EF.DTO.Common;
using BloodDonorApp.BL.EF.DTO.Enums;

namespace BloodDonorApp.BL.EF.DTO
{
    public class AdminDto : UserDto
    {

        public Guid HospitalId { get; set; }

    }
}
