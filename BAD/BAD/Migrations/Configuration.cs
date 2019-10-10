namespace BAD.Migrations
{
    using BAD.DAL;
    using BAD.Enums;
    using BAD.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BADDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BADDbContext context)
        {

            var pp = new SampleStation
            {
                Id = new Guid(),
                Name = "NTS Poprad",
                Street = "Bratislavská 8",
                City = "Poprad"
            };

            var ke = new SampleStation
            {
                Id = new Guid(),
                Name = "NTS Košice",
                Street = "Hlavná 25",
                City = "Košice"
            };

            var ba = new Hospital
            {
                Id = new Guid(),
                Name = "Kramáre",
                Street = "Limbová 2645/5",
                City = "Bratislava"
            };

            var karlik = new CommonUser
            {
                Id = new Guid(),
                FirstName = "Karol",
                LastName = "Valko",
                BloodType = BloodType.Ominus,
                UUN = 1
            };

            var laco = new CommonUser
            {
                Id = new Guid(),
                FirstName = "Laco",
                LastName = "Praporcik",
                BloodType = BloodType.ABplus,
                UUN = 2,
                Hospital = ba
            };

            var henrich = new CommonUser
            {
                Id = new Guid(),
                FirstName = "Henrich",
                LastName = "Lako",
                BloodType = BloodType.Bplus,
                UUN = 3,
                Hospital = ba,
                Email = "heno.lako@gmail.com"
            };

            var jano = new Admin
            {
                Id = new Guid(),
                FirstName = "Jano",
                LastName = "Dovjo",
                Email = "j.bigD@gmail.com",
                UserName = "JanBoss"
            };

            var numOne = new BloodDonation
            {
                Id = new Guid(),
                Applicant = henrich,
                Donor = karlik,
                SampleStation = ke,
                SampleVolume = 450
            };

            context.CommonUsers.AddOrUpdate(user => user.Id, laco);
            //context.Admins.AddOrUpdate(admin => admin.Id, jano);
            //context.SampleStations.AddOrUpdate(ss => ss.Id, ke, pp);
            //context.Hospitals.AddOrUpdate(hospital => hospital.Id, ba);
            //context.BloodDonations.AddOrUpdate(donation => donation.Id, numOne);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
