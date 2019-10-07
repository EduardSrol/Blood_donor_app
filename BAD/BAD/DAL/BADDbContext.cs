﻿using BAD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Common;

namespace BAD.DAL
{
    public class BADDbContext : DbContext
    {
        private const string ConnectionString = " (localdb)\\MSSQLLocalDB";
        public BADDbContext() : base(ConnectionString)
        {
            /*
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = true;
            */
        }

        public BADDbContext(DbConnection connection) : base(connection, true)
        {
            Database.CreateIfNotExists();
        }

        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
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