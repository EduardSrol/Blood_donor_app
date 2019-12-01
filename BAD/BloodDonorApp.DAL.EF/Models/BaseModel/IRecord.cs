using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.Model.BaseModel
{
    public interface IRecord
    {
        int Id { get; set; }
        DateTime Updated { get; set; }
        int UpdatedById { get; set; }

    }
}