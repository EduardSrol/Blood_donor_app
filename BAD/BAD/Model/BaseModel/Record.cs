using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.Model.BaseModel
{
    public abstract class Record
    {
        public int Id { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedById { get; set; }

    }
}