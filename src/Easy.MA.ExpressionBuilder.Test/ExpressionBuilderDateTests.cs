using Easy.MA.ExpressionBuilder;
using Easy.MA.ExpressionBuilder.Core;
using Easy.MA.ExpressionBuilder.Models;
using Xunit;

namespace expressionBuilderTests
{
    public class ExpressionBuilderDateTests
    {
        private IQueryable<Person> GetTestData()
        {
            return new DataGenerator().GeneratePersonsQueryable();
        }

        [Fact]
        public void PredicateFilter_EqualsCondition_ReturnsMatchingDateResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "DateOfBirth",
                    FilterValue = "1985-05-01",
                    Operator = FilterCondition.Equals,
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = expressionBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Single(filteredList);
            Assert.Equal("Michael", filteredList.First().Name);
        }

        [Fact]
        public void PredicateFilter_NotEqualsCondition_ReturnsNonMatchingDateResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "DateOfBirth",
                    FilterValue = "1985-05-01",
                    Operator = FilterCondition.NotEquals,
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = expressionBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Equal(5, filteredList.Count);
            Assert.DoesNotContain(filteredList, p => p.DateOfBirth == new DateTime(1985, 5, 1));
        }

        [Fact]
        public void PredicateFilter_GreaterThanCondition_ReturnsGreaterThanDateResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "DateOfBirth",
                    FilterValue = "1985-05-01",
                    Operator = FilterCondition.GreaterThan,
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = expressionBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Equal(2, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.DateOfBirth > new DateTime(1985, 5, 1)));
        }

        [Fact]
        public void PredicateFilter_LessThanCondition_ReturnsLessThanDateResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "DateOfBirth",
                    FilterValue = "1985-05-01",
                    Operator = FilterCondition.LessThan,
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = expressionBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Equal(2, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.DateOfBirth < new DateTime(1985, 5, 1)));
        }

        [Fact]
        public void PredicateFilter_GreaterThanOrEqualCondition_ReturnsGreaterThanOrEqualDateResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "DateOfBirth",
                    FilterValue = "1985-05-01",
                    Operator = FilterCondition.GreaterThanOrEqual,
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = expressionBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Equal(3, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.DateOfBirth >= new DateTime(1985, 5, 1)));
        }

        [Fact]
        public void PredicateFilter_LessThanOrEqualCondition_ReturnsLessThanOrEqualDateResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "DateOfBirth",
                    FilterValue = "1985-05-01",
                    Operator = FilterCondition.LessThanOrEqual,
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = expressionBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Equal(3, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.DateOfBirth <= new DateTime(1985, 5, 1)));
        }

        [Fact]
        public void PredicateFilter_InRangeCondition_ReturnsInRangeDateResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "DateOfBirth",
                    FilterValue = "1985-05-01",
                    FilterOtherValue = "1990-07-15",
                    Operator = FilterCondition.InRange,
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = expressionBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Equal(2, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.DateOfBirth >= new DateTime(1985, 5, 1) && p.DateOfBirth <= new DateTime(1990, 7, 15)));
        }
    }
}
