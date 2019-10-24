using System.Data.Entity;
using System.Data.Common;
using BloodDonorApp.DAL.EF.Models;

namespace BloodDonorApp.DAL.EF
{
    public class BDADbContext : DbContext
    {
        //private const string ConnectionString = " (localdb)\\MSSQLLocalDB";
        private const string ConnectionString = "Data source=(localdb)\\mssqllocaldb;Database=BLOODDONORAPP-DB;Trusted_Connection=True;MultipleActiveResultSets=true";


        public BDADbContext() : base(ConnectionString)
        {
            Database.SetInitializer(new DatabaseInitializer());

        }

        public BDADbContext(DbConnection connection) : base(connection, true)
        {
            Database.CreateIfNotExists();
        }
        
        #region DbSets
        public virtual DbSet<CommonUser> CommonUsers { get; set; }

        public virtual DbSet<BloodDonation> BloodDonations { get; set; }

        public virtual DbSet<SampleStation> SampleStations { get; set; }

        public virtual DbSet<Hospital> Hospitals { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }
        #endregion
    }
}