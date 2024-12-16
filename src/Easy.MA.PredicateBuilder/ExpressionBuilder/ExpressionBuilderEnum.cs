using Easy.MA.ExpressionBuilder.Core;
using System;
using System.Linq.Expressions;

namespace Easy.MA.ExpressionBuilder.ExpressionBuilder
{
    internal class ExpressionBuilderEnum : IExpressionBuilder
    {
        public Expression CreateExpression(Expression propertyExpression, FilterCondition filterCondition, object filterValue, object filterOtherValue)
        {
            var values = filterValue.ToString().Split(',');
            var constantValue = GetConstantValueOfEnum(values[0], propertyExpression.Type);

            switch (filterCondition)
            {
                case FilterCondition.Equals:
                    return Expression.Equal(propertyExpression, constantValue);

                case FilterCondition.NotEquals:
                    return Expression.NotEqual(propertyExpression, constantValue);

                case FilterCondition.InSet:
                    Expression orExpression = null;
                    foreach (var value in values)
                    {
                        var enumValue = GetConstantValueOfEnum(value.Trim(), propertyExpression.Type);
                        var equalityExpression = Expression.Equal(propertyExpression, enumValue);
                        orExpression = orExpression == null ? equalityExpression : Expression.OrElse(orExpression, equalityExpression);
                    }
                    return orExpression;

                default:
                    throw new ArgumentException($"Unsupported filter condition for Enum : {filterCondition}");
            }
        }

        private static Expression GetConstantValueOfEnum(string value, Type enumType)
        {
            if (!Enum.IsDefined(enumType, value))
                throw new ArgumentException($"Invalid value '{value}' for enum type '{enumType.Name}'");

            var enumValue = Enum.Parse(enumType, value);
            return Expression.Constant(enumValue, enumType);
        }
    }
}
