using Easy.MA.ExpressionBuilder.Core;

namespace Easy.Ma.ExpressionBuilder.WebApi.Models
{
    public class FilterModel
    {
        public List<Filter> Filters { get; set; }
        internal ExpressionBaseOperator _BaseOperator
        {
            get => (ExpressionBaseOperator)Enum.Parse(typeof(ExpressionBaseOperator), BaseOperator);
        }
        public string BaseOperator { get; set; } = "AND";
    }
}
