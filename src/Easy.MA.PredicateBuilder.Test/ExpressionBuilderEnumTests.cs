using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Easy.MA.ExpressionBuilder.Core;
using Easy.MA.ExpressionBuilder.Models;
using Easy.MA.ExpressionBuilder;

namespace PredicateBuilderTests
{
    public class ExpressionBuilderEnumTests
    {
        private IQueryable<Person> GetTestData()
        {
            return new DataGenerator().GeneratePersonsQueryable();
        }

        [Fact]
        public void PredicateFilter_EqualsCondition_ReturnsMatchingEnumResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Color",
                    FilterValue = "Red",
                    Operator = FilterCondition.Equals,
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(2, filteredList.Count);
            Assert.All(filteredList, p => Assert.Equal(CarColor.Red, p.Car.Color));
        }

        [Fact]
        public void PredicateFilter_NotEqualsCondition_ReturnsNonMatchingEnumResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Color",
                    FilterValue = "Red",
                    Operator = FilterCondition.NotEquals,
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(4, filteredList.Count);
            Assert.DoesNotContain(filteredList, p => p.Car.Color == CarColor.Red);
        }

        [Fact]
        public void PredicateFilter_InSetCondition_ReturnsMatchingEnumResults()
        {
            // Arrange
            var persons = GetTestData();

            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Color",
                    FilterValue = "Red,Blue",
                    Operator = FilterCondition.InSet,
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(4, filteredList.Count);
            Assert.Contains(filteredList, p => p.Car.Color == CarColor.Red);
            Assert.Contains(filteredList, p => p.Car.Color == CarColor.Blue);
        }
    }
}
