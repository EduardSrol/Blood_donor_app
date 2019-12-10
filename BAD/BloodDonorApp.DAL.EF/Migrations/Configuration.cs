using BloodDonorApp.DAL.EF.Enums;
using BloodDonorApp.DAL.EF.Models;

namespace BloodDonorApp.DAL.EF.Migrations
{
    using BloodDonorApp.DAL.EF.Models.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BDADbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BDADbContext context)
        {
            var countOfUsersToAdd = 40;
            string[] names = new string[] { "Jana", "Patra", "Petra", "Julia", "Janita",
            "Tatiana", "Hugo", "Diana", "Berta", "Erik", "Daniela", "Zita", "Izidor",
            "Lenka", "Patrik", "Oliver", "Roland", "Lujza", "Darina", "Igor", "Alan",
            "Angela", "Vasil", "Mojmir", "Dana", "Ida", "Dobroslav" ,"Ernest", "Alex",
            "Anton", "Zlatko", "Fedor", "Medard", "Galina", "Peter", "Oxana", "Saskia",
            "Ela", "Urban", "Dusan", "Marta", "Petrana", "Nora", "Noro", "Lea", "Emil",
            "Ema", "Iveta", "Vilma", "Alojz", "Eduard", "Rodan", "Beata", "Lea", "Sona"};

            string[] surnames = new string[] { "Shehu", "Dervishi", "Gjoni", "Murati",
            "Hasani", "Halili", "Hysi", "Leka", "Wagner", "Bauer", "Huber", "Gruber", "Hofer",
            "Fuchs", "Berger", "Eder", "Wolf", "Aigner", "Lehner", "Haas", "Heilig", "Koller",
            "Abbasov", "Abdullayev", "Иванов", "Новик", "Козловский", "Cleas", "Wouters", "Kasa",
            "Dupont", "Simon", "Lambert", "Gooseness", "Delić", "Ibrahimović", "Delemović", "Terzić",
            "Hasanović", "Krličević", "Petersen", "Thomsen", "Olsen", "Johansen", "Christiansen",
            "Pulsen", "Mortensen", "Tamm", "Magi", "Rebane", "Koppel", "Ilves"};

            string[] firstDomains = new string[] { "cz", "sk", "de", "hu", "ru", "com", "net", "edu",
            "eu", "info", "cloud", "online", "store", "fun", "site", "space", "tech", "website", 
            "gen", "gov", "mil", "arpa", "ac", "ad", "ae", "ao", "aq", "al", "ai", "aw", "au", "bz",
            "ca", "cf", "ch", "cl", "cm", "cd"};

            string[] secondDomains = new string[] { "ahaa", "algeria", "aichi", "centrum", "gmail", "email",
            "azet", "atlas", "seznam", "alibaba", "aim", "another", "aol", "anymoment", "amuro", "azimi",
            "ayna", "basket", "barcelona", "bigfoot", "bikerider", "cableone", "cais", "caere", "cia",
            "dognob", "dropzone", "doglover", "discovery", "europe", "eqqu", "every", "eriga", "fromru"};
            var generator = new Random();

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
                Type = UserType.Donor,
                PrefixBN = "771125",
                SufixBN = "2480",
                UUN = 1
            };

            var henrich = new CommonUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Henrich",
                LastName = "Lako",
                BloodType = BloodType.Bplus,
                Type = UserType.Applicant,
                UUN = 3,
                Hospital = mi,
                Email = "heno.lako@gmail.com",
                PrefixBN = "850514",
                SufixBN = "1352"
            };

            var rootAdmin = new CommonUser
            {
                Id = Guid.NewGuid(),
                Type = UserType.RootAdmin,
                FirstName = "Robert",
                LastName = "Fiko",
                UserName = "RootAdmin",
                PasswordHash = "5tcb/axD0SkQ4ZgJQIZzn34jCQc=",
                PasswordSalt = "KV1H+4jMnvVlnd8iYgjiHw=="
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

            List<CommonUser> users = new List<CommonUser>();
            var nameCount = names.Length;
            var surnameCount = surnames.Length;
            var firstDomainCount = firstDomains.Length;
            var secondDomainCount = secondDomains.Length;
            int nameIdx, surnameIdx, prefixBN, sufixBN, fDomainIdx, sDomainIdx, bloodType, uun;
            for (int i = 0; i < countOfUsersToAdd; i++)
            {
                bloodType = generator.Next(0, 8);
                nameIdx = generator.Next(0, nameCount);
                surnameIdx = generator.Next(0, surnameCount);
                fDomainIdx = generator.Next(0, firstDomainCount);
                sDomainIdx = generator.Next(0, secondDomainCount);
                prefixBN = generator.Next(600000, 999999);
                sufixBN = generator.Next(1000, 9999);
                uun = generator.Next(1000, 99999);
                var user = new CommonUser()
                {
                    Id = Guid.NewGuid(),
                    FirstName = names[nameIdx],
                    LastName = surnames[surnameIdx],
                    PrefixBN = prefixBN.ToString(),
                    SufixBN = sufixBN.ToString(),
                    Email = names[nameIdx].ToLower() + "." + surnames[surnameIdx].ToLower() + "@" + secondDomains[sDomainIdx] + "." + firstDomains[fDomainIdx],
                    UserName = names[nameIdx] + surnames[surnameIdx] + generator.Next(0, 1000).ToString(),
                    BloodType = (BloodType)bloodType,
                    Type = UserType.Applicant,
                    UUN = uun,
                    Hospital = kk
                };
                users.Add(user);
            }

            context.CommonUsers.AddRange(users);
            context.CommonUsers.AddOrUpdate(user => user.Id, karlik, henrich, rootAdmin);
            context.SampleStations.AddOrUpdate(ss => ss.Id, ke, pp, nr, ba_kramare, za);
            context.Hospitals.AddOrUpdate(hospital => hospital.Id, kk, dk, mi, tn);
            context.BloodDonations.AddOrUpdate(donation => donation.Id, numOne);

            context.SaveChanges();
        }
    }
}
