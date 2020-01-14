using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Exceptions
{
    public class UsedUsername : Exception
    {
        public UsedUsername()
        {
        }

        public UsedUsername(string message)
            : base(message)
        {
        }

        public UsedUsername(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
