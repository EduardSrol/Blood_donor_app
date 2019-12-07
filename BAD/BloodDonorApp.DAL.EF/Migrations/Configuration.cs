using BloodDonorApp.DAL.EF.Enums;
using BloodDonorApp.DAL.EF.Models;

namespace BloodDonorApp.DAL.EF.Migrations
{
    using BloodDonorApp.DAL.EF.Models.Common;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BloodDonorApp.DAL.EF.BDADbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BloodDonorApp.DAL.EF.BDADbContext context)
        {
            var pp = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "Poprad",
                Street = "Banícka 803/28",
                City = "Poprad",
                OpeningHours = new Day[] {
                    new Day(new Time(6, 0), new Time(14, 0)),
                    new Day(new Time(6, 0), new Time(17, 0)),
                    new Day(new Time(6, 0), new Time(14, 0)),
                    new Day(new Time(6, 0), new Time(14, 0)),
                    new Day(new Time(6, 0), new Time(14, 0)),
                    null,
                    null
                },
                Email = "popradnts@ntssr.sk",
                PhoneNumber = "+421 527 125 700",
                WebLink = "http://www.ntssr.sk/kde-darovat-krv/poprad"
            };

            var ba_kramare = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "Bratislava - Kramáre",
                Street = "Limbová 3",
                City = "Bratislava",
                OpeningHours = new Day[] {
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(17, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    null,
                    null
                },
                Email = "kramarents@ntssr.sk",
                PhoneNumber = "+421 259 103 025",
                WebLink = "http://www.ntssr.sk/kde-darovat-krv/bratislava-kramare"
            };

            var za = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "Žilina",
                Street = "Vojtecha Spanyola 43",
                City = "Žilina",
                OpeningHours = new Day[] {
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(17, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    null,
                    null
                },
                Email = "zilinants@ntssr.sk",
                PhoneNumber = "+421 417 074 711",
                WebLink = "http://www.ntssr.sk/kde-darovat-krv/zilina"
            };

            var ke = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "Košice",
                Street = "Trieda SNP 1",
                City = "Košice",
                OpeningHours = new Day[] {
                    new Day(new Time(7, 0), new Time(17, 0)),
                    new Day(new Time(7, 0), new Time(17, 0)),
                    new Day(new Time(7, 0), new Time(17, 0)),
                    new Day(new Time(7, 0), new Time(17, 0)),
                    new Day(new Time(7, 0), new Time(17, 0)),
                    null,
                    null
                },
                Email = "kosicents@ntssr.sk",
                PhoneNumber = "+421 556 404 146",
                WebLink = "http://www.ntssr.sk/kde-darovat-krv/kosice"
            };

            var nr = new SampleStation
            {
                Id = Guid.NewGuid(),
                Name = "Nitra",
                Street = "Špitálska 6",
                City = "Nitra",
                OpeningHours = new Day[] {
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(17, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    new Day(new Time(7, 0), new Time(14, 0)),
                    null,
                    null
                },
                Email = "nitrants@ntssr.sk",
                PhoneNumber = "+421 556 404 146",
                WebLink = "http://www.ntssr.sk/kde-darovat-krv/nitra"
            };

            var kk = new Hospital
            {
                Id = Guid.NewGuid(),
                Name = "Nemocnica Dr. Vojtecha Alexandra v Kežmarku n. o.",
                Street = "Huncovská 42",
                City = "Kežmarok"
            };

            var dk = new Hospital
            {
                Id = Guid.NewGuid(),
                Name = "Dolnooravská nemocnica s poliklinikou MUDr. Ladislava Nádaši Jégého Dolný Kubín",
                Street = "Nemocničná 1944",
                City = "Dolný Kubín"
            };

            var mi = new Hospital
            {
                Id = Guid.NewGuid(),
                Name = "Svet zdravia, a.s. - Nemocnica Michalovce",
                Street = "Špitálska 2",
                City = "Michalovce"
            };

            var tn = new Hospital
            {
                Id = Guid.NewGuid(),
                Name = "Fakultná nemocnica Trenčín",
                Street = "Špitálska 2",
                City = "Trenčín"
            };

            var karlik = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Karol",
                LastName = "Valko",
                BloodType = BloodType.Ominus,
                Type = CommonUserType.Donor,
                PrefixBN = "771125",
                SufixBN = "2480",
                UUN = 1
            };

            var jozo = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Jozef",
                LastName = "Čarnogurský",
                BloodType = BloodType.Oplus,
                Type = CommonUserType.Donor,
                PrefixBN = "870512",
                SufixBN = "4510",
                UUN = 154
            };

            var anna = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Anna",
                LastName = "Novotná",
                BloodType = BloodType.ABminus,
                Type = CommonUserType.Donor,
                PrefixBN = "875701",
                SufixBN = "8752",
                UUN = 12979
            };

            var laura = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Laura",
                LastName = "Novysedláková",
                BloodType = BloodType.Bminus,
                Type = CommonUserType.Donor,
                PrefixBN = "995701",
                SufixBN = "8852",
                UUN = 54989
            };

            var marta = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Marta",
                LastName = "Poliaková",
                BloodType = BloodType.Bminus,
                Type = CommonUserType.Applicant,
                Hospital = kk,
                PrefixBN = "905522",
                SufixBN = "4578",
                UUN = 54989
            };

            var laco = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Laco",
                LastName = "Praporcik",
                BloodType = BloodType.ABplus,
                Type = CommonUserType.Applicant,
                UUN = 2,
                PrefixBN = "781010",
                SufixBN = "0211",
                Hospital = dk
            };

            var henrich = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Henrich",
                LastName = "Lako",
                BloodType = BloodType.Bplus,
                Type = CommonUserType.Applicant,
                UUN = 3,
                Hospital = mi,
                Email = "heno.lako@gmail.com",
                PrefixBN = "850514",
                SufixBN = "1352"
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
                SampleVolume = 450,
                BloodType = karlik.BloodType
            };

            context.CommonUsers.AddOrUpdate(user => user.Id, laco, karlik, henrich);
            context.Admins.AddOrUpdate(admin => admin.Id, jano);
            context.SampleStations.AddOrUpdate(ss => ss.Id, ke, pp, nr, ba_kramare, za);
            context.Hospitals.AddOrUpdate(hospital => hospital.Id, mi);
            context.BloodDonations.AddOrUpdate(donation => donation.Id, numOne);

            context.SaveChanges();
        }
    }
}
