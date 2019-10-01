using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAD.DAL
{
    public class BADDbContext : DbContext
    {
        public BADDbContext() : base("BADContextConnection")
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = true;
        }

        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        #region DbSets
        public virtual DbSet<User> Users { get; set; }
        #endregion
    }
}