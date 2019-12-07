using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonorApp.DAL.EF.Models.Common
{

    public class Time {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public Time(int Hours, int Minutes) {
            this.Hours = Hours;
            this.Minutes = Minutes;
       }
    }
    public class Day {
        public Time OpeningTime { get; set; }
        public Time ClosingTime { get; set; }

        public Day(Time openingTime, Time closingTime) {
            this.OpeningTime = openingTime;
            this.ClosingTime = closingTime;
        }
    }

    public abstract class Institution : Record
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Name { get; set; }

        public Day[] OpeningHours { get; set; } = new Day[7];
    }
}