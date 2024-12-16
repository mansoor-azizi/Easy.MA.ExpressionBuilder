using Easy.MA.ExpressionBuilder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Easy.MA.ExpressionBuilder.ExpressionBuilder
{
    internal interface IExpressionBuilder
    {
        Expression CreateExpression(Expression nameProperty, FilterCondition filterCondition, object filterValue, object filterOtherValue);
    }
}
