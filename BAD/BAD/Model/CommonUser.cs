using BAD.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAD.Model
{
    public class CommonUser : User
    {
        public string PrefixBN { get; set; }

        public string SufixBN { get; set; }
        
        public BloodType BloodType { get; set; }
        
        public Hospital Hospital { get; set; }

        public bool Approved { get; set; }

        public bool Active { get; set; }

        public int UUN { get; set; }
    }
}