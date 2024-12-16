

namespace Easy.MA.ExpressionBuilder.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Car Car { get; set; }
        public bool? IsActive { get; set; }

    }
}
