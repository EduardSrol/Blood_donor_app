using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAD.Infrastructure.Query.Predicates.Operators
{
    public enum ValueComparingOperator
    {
        None,
        GreaterThan,
        GreaterThanOrEqual,
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        StringContains
    }
}