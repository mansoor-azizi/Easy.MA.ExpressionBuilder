using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.MA.ExpressionBuilder.Core
{
    public enum FilterCondition
    {
        Equals = 0,
        NotEquals = 1,
        GreaterThan = 2,
        GreaterThanOrEqual = 3,
        LessThan = 4,
        LessThanOrEqual = 5,
        InRange = 6,
        Contains = 7,
        NotContains = 8,
        InSet = 9
    }
}
