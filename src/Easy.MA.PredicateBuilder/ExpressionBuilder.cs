using Easy.MA.ExpressionBuilder.Core;
using Easy.MA.ExpressionBuilder.ExpressionBuilder;
using System.Linq.Expressions;

namespace Easy.MA.ExpressionBuilder
{
    public class ExpressionBuilder<T> where T : class
    {

        public Expression<Func<T, bool>> Create(List<Filter> filterParams, ExpressionBaseOperator baseOperator = ExpressionBaseOperator.AND)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            Expression mainExpression = null;
            foreach (Filter filterParam in filterParams)
            {
                var property = GetExpressionProperty(param, filterParam.PropertyName);
                var expressionBuilder = ExpressionBuilderFactory.GetExpressionBuilder(property.Type);
                var currentPredicate = expressionBuilder.CreateExpression(property, filterParam.Operator,
                    filterParam.FilterValue, filterParam.FilterOtherValue);
                if (mainExpression == null)
                {
                    mainExpression = currentPredicate;
                }
                else
                {
                    mainExpression = baseOperator == ExpressionBaseOperator.AND ? Expression.AndAlso(mainExpression, currentPredicate) : Expression.OrElse(mainExpression, currentPredicate);
                }
            }
            return Expression.Lambda<Func<T, bool>>(mainExpression, param);
        }

        private Expression GetExpressionProperty(ParameterExpression param, string propertyName)
        {
            Expression property = param;
            foreach (var prop in propertyName.Split('.'))
            {
                property = Expression.Property(property, prop);
            }
            return property;
        }

    }
}
