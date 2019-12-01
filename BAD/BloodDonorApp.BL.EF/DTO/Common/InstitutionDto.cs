using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.DTO.Common
{
    public abstract class InstitutionDto : DtoBase
    {
        public string City { get; set; }

        public string Street { get; set; }

        public string Name { get; set; }
    }
}
