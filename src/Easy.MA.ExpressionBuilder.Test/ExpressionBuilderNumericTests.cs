using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Easy.MA.ExpressionBuilder.Core;
using Easy.MA.ExpressionBuilder.ExpressionBuilder;
using Easy.MA.ExpressionBuilder.Models;
using Easy.MA.ExpressionBuilder;

namespace PredicateBuilderTests
{
    public class ExpressionBuilderNumericTests
    {
        private IQueryable<Person> GetTestData()
        {
            return new DataGenerator().GeneratePersonsQueryable();
        }

        [Fact]
        public void PredicateFilter_EqualsCondition_ReturnsMatchingNumericResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Score",
                    FilterValue = "95",
                    Operator = "Equals",
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Single(filteredList);
            Assert.Equal(95, filteredList.First().Car.Score);
        }

        [Fact]
        public void PredicateFilter_NotEqualsCondition_ReturnsNonMatchingNumericResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Score",
                    FilterValue = "95",
                    Operator ="NotEquals",
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(5, filteredList.Count);
            Assert.DoesNotContain(filteredList, p => p.Car.Score == 90);
        }

        [Fact]
        public void PredicateFilter_LessThanCondition_ReturnsLessThanNumericResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Score",
                    FilterValue = "90",
                    Operator = "LessThan",
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(4, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.Car.Score < 90));
        }

        [Fact]
        public void PredicateFilter_LessThanOrEqualCondition_ReturnsLessThanOrEqualNumericResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Score",
                    FilterValue = "90",
                    Operator = "LessThanOrEqual",
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(4, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.Car.Score <= 90));
        }

        [Fact]
        public void PredicateFilter_GreaterThanCondition_ReturnsGreaterThanNumericResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Score",
                    FilterValue = "90",
                    Operator = "GreaterThan",
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Single(filteredList);
            Assert.All(filteredList, p => Assert.True(p.Car.Score > 90));
        }

        [Fact]
        public void PredicateFilter_GreaterThanOrEqualCondition_ReturnsGreaterThanOrEqualNumericResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Score",
                    FilterValue = "85",
                    Operator = "GreaterThanOrEqual",
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(3, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.Car.Score >= 85));
        }

        [Fact]
        public void PredicateFilter_InRangeCondition_ReturnsInRangeNumericResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Score",
                    FilterValue = "80",
                    FilterOtherValue = "90",
                    Operator = "InRange",
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(3, filteredList.Count);
            Assert.All(filteredList, p => Assert.True(p.Car.Score >= 80 && p.Car.Score <= 90));
        }
    }
}
