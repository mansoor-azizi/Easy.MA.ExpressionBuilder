﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.MA.ExpressionBuilder.Core
{
    public class Filter
    {
        public required string PropertyName { get; set; }

        public required object FilterValue { get; set; }

        public object FilterOtherValue { get; set; }

        public FilterCondition Operator { get; set; } = FilterCondition.Equals;
    }
}
