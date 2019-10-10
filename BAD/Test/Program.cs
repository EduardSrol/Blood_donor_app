using BAD.DAL;
using BAD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<CommonUser> commonUsers;
            using (var context = new BADDbContext())
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
