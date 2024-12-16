using System;
using System.Linq.Expressions;
using Easy.MA.ExpressionBuilder.Core;

namespace Easy.MA.ExpressionBuilder.ExpressionBuilder
{
    internal class ExpressionBuilderDate : IExpressionBuilder
    {
        public Expression CreateExpression(Expression nameProperty, FilterCondition filterCondition, object filterValue, object filterOtherValue)
        {
            switch (filterCondition)
            {
                case FilterCondition.Equals:
                    return GetDateTimeEqualExpression(nameProperty, filterValue);
                case FilterCondition.NotEquals:
                    return GetDateTimeNotEqualExpression(nameProperty, filterValue);
                case FilterCondition.GreaterThan:
                    return GetDateTimeGreaterThanExpression(nameProperty, filterValue);
                case FilterCondition.LessThan:
                    return GetDateTimeLessThanExpression(nameProperty, filterValue);
                case FilterCondition.GreaterThanOrEqual:
                    return GetDateTimeGreaterThanOrEqualExpression(nameProperty, filterValue);
                case FilterCondition.LessThanOrEqual:
                    return GetDateTimeLessThanOrEqualExpression(nameProperty, filterValue);
                case FilterCondition.InRange:
                    return GetDateTimeInRangeExpression(nameProperty, filterValue, filterOtherValue);
                default:
                    throw new ArgumentException($"Unsupported filter condition for DateTime: {filterCondition}");
            }
        }

        private static Expression GetDateTimeEqualExpression(Expression nameProperty, object filterValue)
        {
            var dateTime = DateTime.Parse((string)filterValue);
            var dateTimeNextDay = dateTime.AddDays(1);

            var constantDateTime = Expression.Constant(dateTime, nameProperty.Type);
            var constantDateTimeNextDay = Expression.Constant(dateTimeNextDay, nameProperty.Type);

            var greaterThanOrEqual = Expression.GreaterThanOrEqual(nameProperty, constantDateTime);
            var lessThan = Expression.LessThan(nameProperty, constantDateTimeNextDay);

            return Expression.AndAlso(greaterThanOrEqual, lessThan);
        }


        private static Expression GetDateTimeNotEqualExpression(Expression nameProperty, object filterValue)
        {
            var equalExpression = GetDateTimeEqualExpression(nameProperty, filterValue);
            return Expression.Not(equalExpression);
        }

        private static Expression GetDateTimeGreaterThanExpression(Expression nameProperty, object filterValue)
        {
            var dateTime = DateTime.Parse((string)filterValue);
            return Expression.GreaterThan(nameProperty, Expression.Constant(dateTime, nameProperty.Type));
        }

        private static Expression GetDateTimeLessThanExpression(Expression nameProperty, object filterValue)
        {
            var dateTime = DateTime.Parse((string)filterValue);
            return Expression.LessThan(nameProperty, Expression.Constant(dateTime, nameProperty.Type));
        }

        private static Expression GetDateTimeGreaterThanOrEqualExpression(Expression nameProperty, object filterValue)
        {
            var dateTime = DateTime.Parse((string)filterValue);
            return Expression.GreaterThanOrEqual(nameProperty, Expression.Constant(dateTime, nameProperty.Type));
        }

        private static Expression GetDateTimeLessThanOrEqualExpression(Expression nameProperty, object filterValue)
        {
            var dateTime = DateTime.Parse((string)filterValue);
            return Expression.LessThanOrEqual(nameProperty, Expression.Constant(dateTime, nameProperty.Type));
        }

        private static Expression GetDateTimeInRangeExpression(Expression nameProperty, object filterValue, object filterOtherValue)
        {
            var dateTimeStart = DateTime.Parse((string)filterValue);
            var dateTimeEnd = DateTime.Parse((string)filterOtherValue);

            var greaterThanOrEqual = Expression.GreaterThanOrEqual(nameProperty, Expression.Constant(dateTimeStart, nameProperty.Type));
            var lessThanOrEqual = Expression.LessThanOrEqual(nameProperty, Expression.Constant(dateTimeEnd, nameProperty.Type));

            return Expression.AndAlso(greaterThanOrEqual, lessThanOrEqual);
        }
    }
}
