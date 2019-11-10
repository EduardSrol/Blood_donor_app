using System.Data.Entity;
using System.Data.Common;
using BloodDonorApp.DAL.EF.Config;
using BloodDonorApp.DAL.EF.Models;

namespace BloodDonorApp.DAL.EF
{
    public class BDADbContext : DbContext
    {
        //private const string ConnectionString = " (localdb)\\MSSQLLocalDB"


        public BDADbContext() : base(EFInstaller.ConnectionString)
        {
            //Database.SetInitializer(new DatabaseInitializer());
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

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