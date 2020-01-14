using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorApp.BL.EF.Exceptions
{
    using System;

    public class UsedEmail : Exception
    {
        public UsedEmail()
        {
        }

        public UsedEmail(string message)
            : base(message)
        {
        }

        public UsedEmail(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
