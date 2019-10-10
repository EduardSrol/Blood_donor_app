using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.Infrastructure.Data
{
    public abstract class Record
    {
        public DateTime? Updated { get; set; }
        public Guid UpdatedById { get; set; }
    }
}