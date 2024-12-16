using Easy.MA.ExpressionBuilder.Core;
using System;
using System.Linq.Expressions;

namespace Easy.MA.ExpressionBuilder.ExpressionBuilder
{
    internal class ExpressionBuilderNumeric : IExpressionBuilder
    {
        public Expression CreateExpression(Expression propertyExpression, FilterCondition filterCondition, object filterValue, object filterOtherValue)
        {
            var constantValue = GetConstantValueOfNumber(filterValue.ToString(), propertyExpression.Type);

            switch (filterCondition)
            {
                case FilterCondition.Equals:
                    return Expression.Equal(propertyExpression, constantValue);

                case FilterCondition.NotEquals:
                    return Expression.NotEqual(propertyExpression, constantValue);

                case FilterCondition.LessThan:
                    return Expression.LessThan(propertyExpression, constantValue);

                case FilterCondition.LessThanOrEqual:
                    return Expression.LessThanOrEqual(propertyExpression, constantValue);

                case FilterCondition.GreaterThan:
                    return Expression.GreaterThan(propertyExpression, constantValue);

                case FilterCondition.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(propertyExpression, constantValue);

                case FilterCondition.InRange:
                    var constantOtherValue = GetConstantValueOfNumber(filterOtherValue.ToString(), propertyExpression.Type);
                    var greaterThanOrEqual = Expression.GreaterThanOrEqual(propertyExpression, constantValue);
                    var lessThanOrEqual = Expression.LessThanOrEqual(propertyExpression, constantOtherValue);
                    return Expression.AndAlso(greaterThanOrEqual, lessThanOrEqual);

                default:
                    return Expression.Equal(propertyExpression, constantValue);
            }
        }

        private static Expression GetConstantValueOfNumber(string value, Type targetType)
        {
            return Type.GetTypeCode(Nullable.GetUnderlyingType(targetType) ?? targetType) switch
            {
                TypeCode.Byte => Expression.Constant(byte.TryParse(value, out var byteResult) ? (byte?)byteResult : null, targetType),
                TypeCode.SByte => Expression.Constant(sbyte.TryParse(value, out var sbyteResult) ? (sbyte?)sbyteResult : null, targetType),
                TypeCode.UInt16 => Expression.Constant(ushort.TryParse(value, out var ushortResult) ? (ushort?)ushortResult : null, targetType),
                TypeCode.UInt32 => Expression.Constant(uint.TryParse(value, out var uintResult) ? (uint?)uintResult : null, targetType),
                TypeCode.UInt64 => Expression.Constant(ulong.TryParse(value, out var ulongResult) ? (ulong?)ulongResult : null, targetType),
                TypeCode.Int16 => Expression.Constant(short.TryParse(value, out var shortResult) ? (short?)shortResult : null, targetType),
                TypeCode.Int32 => Expression.Constant(int.TryParse(value, out var intResult) ? (int?)intResult : null, targetType),
                TypeCode.Int64 => Expression.Constant(long.TryParse(value, out var longResult) ? (long?)longResult : null, targetType),
                TypeCode.Decimal => Expression.Constant(decimal.TryParse(value, out var decimalResult) ? (decimal?)decimalResult : null, targetType),
                TypeCode.Double => Expression.Constant(double.TryParse(value, out var doubleResult) ? (double?)doubleResult : null, targetType),
                TypeCode.Single => Expression.Constant(float.TryParse(value, out var floatResult) ? (float?)floatResult : null, targetType),
                _ => Expression.Constant(double.TryParse(value, out var defaultResult) ? (double?)defaultResult : null, targetType),
            };
        }

    }
}
