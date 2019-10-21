using System.Data.Entity;
using System.Data.Common;
using BloodDonorApp.DAL.EF.Models;

namespace BloodDonorApp.DAL.EF
{
    public class BADDbContext : DbContext
    {
        //private const string ConnectionString = " (localdb)\\MSSQLLocalDB";
        private const string ConnectionString = "Data source=(localdb)\\mssqllocaldb;Database=BLOODDONORAPP-DB;Trusted_Connection=True;MultipleActiveResultSets=true";


        public BADDbContext() : base(ConnectionString)
        {

            //configuration.autodetectchangesenabled = true;
            //configuration.lazyloadingenabled = false;
            //configuration.proxycreationenabled = false;
            //configuration.validateonsaveenabled = true;

            //var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Database.SetInitializer(new DatabaseInitializer());

        }

        public BADDbContext(DbConnection connection) : base(connection, true)
        {
            Database.CreateIfNotExists();
        }
        /*
        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }
        */
        #region DbSets
        public virtual DbSet<CommonUser> CommonUsers { get; set; }

        public virtual DbSet<BloodDonation> BloodDonations { get; set; }

        public virtual DbSet<SampleStation> SampleStations { get; set; }

        public virtual DbSet<Hospital> Hospitals { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }
        #endregion
    }
}