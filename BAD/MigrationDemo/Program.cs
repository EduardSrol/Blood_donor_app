using BloodDonorApp.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MigrationDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            IList<BloodDonorApp.DAL.EF.Models.CommonUser> commonUsers;
            using (var context = new BDADbContext())
            {
                commonUsers = context.CommonUsers.ToList();
            }
            foreach (var user in commonUsers)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }
            Console.ReadLine();
        }
    }
}
