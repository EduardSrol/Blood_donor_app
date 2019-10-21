using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using BloodDonorApp.DAL.EF.Models;
using BloodDonorApp.DAL.EF.Enums;

namespace BloodDonorApp.DAL.EF
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<BADDbContext>
    {
        protected override void Seed(BADDbContext context)
        {

            var pp = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "NTS Poprad",
                Street = "Bratislavská 8",
                City = "Poprad"
            };

            var ke = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "NTS Košice",
                Street = "Hlavná 25",
                City = "Košice"
            };

            var ba = new Hospital
            {
                Id = Guid.NewGuid(),
                Name = "Kramáre",
                Street = "Limbová 2645/5",
                City = "Bratislava"
            };

            var karlik = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Karol",
                LastName = "Valko",
                BloodType = BloodType.Ominus,
                UUN = 1
            };

            var laco = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Laco",
                LastName = "Praporcik",
                BloodType = BloodType.ABplus,
                UUN = 2,
                Hospital = ba
            };

            var henrich = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Henrich",
                LastName = "Lako",
                BloodType = BloodType.Bplus,
                UUN = 3,
                Hospital = ba,
                Email = "heno.lako@gmail.com"
            };

            var jano = new Admin
            {
                Id = Guid.NewGuid(),
                FirstName = "Jano",
                LastName = "Dovjo",
                Email = "j.bigD@gmail.com",
                UserName = "JanBoss"
            };

            var numOne = new BloodDonation
            {
                Id = Guid.NewGuid(),
                Applicant = henrich,
                Donor = karlik,
                SampleStation = ke,
                SampleVolume = 450
            };

            context.CommonUsers.AddOrUpdate(user => user.Id, laco, karlik, henrich);
            context.Admins.AddOrUpdate(admin => admin.Id, jano);
            context.SampleStations.AddOrUpdate(ss => ss.Id, ke, pp);
            context.Hospitals.AddOrUpdate(hospital => hospital.Id, ba);
            context.BloodDonations.AddOrUpdate(donation => donation.Id, numOne);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}