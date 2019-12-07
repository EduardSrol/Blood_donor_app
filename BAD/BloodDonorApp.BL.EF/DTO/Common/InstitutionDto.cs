using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.DTO.Common
{
    public abstract class InstitutionDto : DtoBase
    {
        [Required(ErrorMessage = "City is required!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required!")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }
}
