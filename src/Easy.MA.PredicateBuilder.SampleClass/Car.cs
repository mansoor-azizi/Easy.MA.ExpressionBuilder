

namespace Easy.MA.ExpressionBuilder.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? ModelName { get; set; }
        public string Description { get; set; }
        public int? Score { get; set; }
        public CarColor Color { get; set; }
    }
}
