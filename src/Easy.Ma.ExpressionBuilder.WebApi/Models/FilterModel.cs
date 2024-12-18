using Easy.MA.ExpressionBuilder.Core;

namespace Easy.Ma.ExpressionBuilder.WebApi.Models
{
    public class FilterModel
    {
        public List<Filter> Filters {get;set;} 
        public ExpressionBaseOperator BaseOperator { get;set;}
    }
}
