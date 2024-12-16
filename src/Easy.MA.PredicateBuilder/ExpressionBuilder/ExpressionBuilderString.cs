using Easy.MA.ExpressionBuilder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Easy.MA.ExpressionBuilder.ExpressionBuilder
{
    internal class ExpressionBuilderString : IExpressionBuilder
    {
        public Expression CreateExpression(Expression nameProperty, FilterCondition filterCondition,object filterValue,object filterOtherValue)
        {
            return filterCondition switch
            {
                FilterCondition.Equals => GetStringEqualExpression(nameProperty,(string)filterValue),
                FilterCondition.NotEquals => GetStringNotEqualExpression(nameProperty, (string)filterValue),
                FilterCondition.Contains => GetStringContainsExpression( nameProperty, (string)filterValue),
                FilterCondition.InSet=> GetStringSetExpression(nameProperty, (string)filterValue),
                _ => GetStringEqualExpression(nameProperty, (string)filterValue)
            };
        }



        private static Expression GetStringContainsExpression(Expression nameProperty, string propertyValue)
        {
            BinaryExpression instance = Expression.Coalesce(nameProperty, Expression.Constant(string.Empty));
            MethodInfo method = typeof(string).GetMethod("Contains", new Type[1] { typeof(string) });
            ConstantExpression constantExpression = Expression.Constant(propertyValue, typeof(string));
            return Expression.Call(instance, method, constantExpression);
        }

        private static Expression GetStringEqualExpression(Expression nameProperty, string propertyValue)
        {
            BinaryExpression left = Expression.Coalesce(nameProperty, Expression.Constant(string.Empty));
            ConstantExpression right = Expression.Constant(propertyValue, typeof(string));
            return Expression.Equal(left, right);
        }

        private static Expression GetStringNotEqualExpression(Expression nameProperty, string propertyValue)
        {
            BinaryExpression left = Expression.Coalesce(nameProperty, Expression.Constant(string.Empty));
            ConstantExpression right = Expression.Constant(propertyValue, typeof(string));
            return Expression.NotEqual(left, right);
        }

        private static Expression GetStringSetExpression(Expression nameProperty, string propertyValue)
        {
            string[] propertyValues = propertyValue.ToString().Split(',');
            Expression expression = null;
            foreach (string value in propertyValues)
            {
                Expression stringEqualExpression = GetStringEqualExpression(nameProperty, value);
                expression = ((expression != null) ? Expression.Or(expression, stringEqualExpression) : stringEqualExpression);
            }
            return expression;
        }

    }
}
