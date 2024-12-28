using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.MA.ExpressionBuilder.Core
{
    public class Filter
    {
        public required string PropertyName { get; set; }

        public required string FilterValue { get; set; }

        public string FilterOtherValue { get; set; }

        internal FilterCondition _Operator 
        { 
            get => (FilterCondition) Enum.Parse(typeof(FilterCondition), Operator); 
        }

        public string Operator { get; set; } = "Equals";
    }
}
