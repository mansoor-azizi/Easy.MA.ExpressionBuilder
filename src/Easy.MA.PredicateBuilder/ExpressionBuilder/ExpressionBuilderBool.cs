using Easy.MA.ExpressionBuilder.Core;
using System;
using System.Linq.Expressions;

namespace Easy.MA.ExpressionBuilder.ExpressionBuilder
{
    internal class ExpressionBuilderBool : IExpressionBuilder
    {
        public Expression CreateExpression(Expression propertyExpression, FilterCondition filterCondition, object filterValue, object filterOtherValue)
        {
            var constantValue = Expression.Constant(bool.Parse(filterValue.ToString()), propertyExpression.Type);

            switch (filterCondition)
            {
                case FilterCondition.Equals:
                    return Expression.Equal(propertyExpression, constantValue);

                case FilterCondition.NotEquals:
                    return Expression.NotEqual(propertyExpression, constantValue);

                default:
                    throw new ArgumentException($"Unsupported filter condition: {filterCondition}");
            }
        }
    }
}
