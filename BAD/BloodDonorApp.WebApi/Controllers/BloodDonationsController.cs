using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.DTO.Filters;
using BloodDonorApp.BL.EF.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BloodDonorApp.WebApi.Controllers
{
    public class BloodDonationsController : ApiController
    {
        public BloodDonationFacade bloodDonationFacade { get; set; }

        // GET api/<controller>
        [HttpGet, Route("api/BloodDonations/Query")]
        public async Task<IEnumerable<BloodDonationDto>> Query(Guid sampleStationId)
        {
            var filter = new BloodDonationFilterDto
            {
                SampleStationId = sampleStationId
            };

            var bloodDonations = (await bloodDonationFacade.GetBloodDonations(filter)).Items;
            foreach (var bloodDonation in bloodDonations)
            {
                bloodDonation.Id = Guid.Empty;
                bloodDonation.SampleStationId = Guid.Empty;
                bloodDonation.ApplicantId = Guid.Empty;
                bloodDonation.DonorId = Guid.Empty;
            }
            return bloodDonations;

        }

        // GET api/<controller>/5
        public async Task<BloodDonationDto> Get(Guid id)
        {
            var bloodDonation = await bloodDonationFacade.GetBloodDonationByIdAsync(id);
            if (bloodDonation == null) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return bloodDonation;
        }

        // POST api/<controller>
        public async Task<string> Post([FromBody]BloodDonationDto bloodDonation)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var bloodDonationId = Guid.Empty;
            try
            {
                bloodDonationId = await bloodDonationFacade.CreateBloodDonation(bloodDonation);
            } catch (Exception) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return $"Created blood donation with id: {bloodDonationId}.";
        }

        // PUT api/<controller>/5
        public async Task<string> Put(Guid id, [FromBody]BloodDonationDto bloodDonation)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var success = await bloodDonationFacade.Update(bloodDonation);
            if (!success)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return $"Updated product with id: {id}";
        }

        // DELETE api/<controller>/5
        public async Task<string> Delete(Guid id)
        {
            var success = await bloodDonationFacade.DeleteAsync(id);
            if (!success)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return $"Deleted product with id: {id}";
        }
    }
}