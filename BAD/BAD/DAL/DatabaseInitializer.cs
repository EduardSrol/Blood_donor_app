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
            var karlik = new User
            {
                Id = 1,
                FirstName = "Karol",
                LastName = "Valko",
                BloodType = BloodType.Ominus,
                UUN = 1
            };

            var laco = new User
            {
                Id = 2,
                FirstName = "Laco",
                LastName = "Praporcik",
                BloodType = BloodType.ABplus,
                UUN = 2
            };

            context.Users.AddOrUpdate(user => user.UUN, karlik, laco);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}