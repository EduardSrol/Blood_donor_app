namespace BloodDonorApp.DAL.EF.Migrations
{
    using BloodDonorApp.DAL.EF.Enums;
    using BloodDonorApp.DAL.EF.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BloodDonorApp.DAL.EF.BADDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BADDbContext context)
        {

            var pp = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "NTS Poprad",
                Street = "Bratislavsk� 8",
                City = "Poprad"
            };

            var ke = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "NTS Ko�ice",
                Street = "Hlavn� 25",
                City = "Ko�ice"
            };

            var ba = new Hospital
            {
                Id = Guid.NewGuid(),
                Name = "Kram�re",
                Street = "Limbov� 2645/5",
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
