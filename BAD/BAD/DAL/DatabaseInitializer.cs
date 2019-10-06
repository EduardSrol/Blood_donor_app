using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BAD.Model;
using BAD.Enums;
using System.Data.Entity.Migrations;

namespace BAD.DAL
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<BADDbContext>
    {
        protected override void Seed(BADDbContext context)
        {
            var pp = new SampleStation
            {
                Id = 5,
                Name = "NTS Poprad",
                Street = "Bratislavská 8",
                City = "Poprad"
            };

            var ke = new SampleStation
            {
                Id = 6,
                Name = "NTS Košice",
                Street = "Hlavná 25",
                City = "Košice"
            };

            var ba = new Hospital
            {
                Id = 7,
                Name = "Kramáre",
                Street = "Limbová 2645/5",
                City = "Bratislava",
            };

            var karlik = new CommonUser
            {
                Id = 1,
                FirstName = "Karol",
                LastName = "Valko",
                BloodType = BloodType.Ominus,
                UUN = 1,
            };

            var laco = new CommonUser
            {
                Id = 2,
                FirstName = "Laco",
                LastName = "Praporcik",
                BloodType = BloodType.ABplus,
                UUN = 2,
                Hospital = ba
            };

            var henrich = new CommonUser
            {
                Id = 3,
                FirstName = "Henrich",
                LastName = "Lako",
                BloodType = BloodType.Bplus,
                UUN = 3,
                Hospital = ba,
                Email = "heno.lako@gmail.com"
            };

            var jano = new Admin
            {
                Id = 1000,
                FirstName = "Jano",
                LastName = "Dovjo",
                Email = "j.bigD@gmail.com",
                UserName = "JanBoss"
            };

            var numOne = new BloodDonation
            {
                Id = 8,
                Applicant = henrich,
                Donor = karlik,
                SampleStation = ke,
                SampleVolume = 450
            };

            context.Users.AddOrUpdate(user => user.UUN, karlik, laco);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}