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
    public class PredicateBuilderBoolTests
    {
        private IQueryable<Person> GetTestData()
        {
            return new DataGenerator().GeneratePersonsQueryable();
        }

        [Fact]
        public void PredicateFilter_EqualsCondition_ReturnsMatchingBoolResults()
        {
            // Arrange
            var persons = GetTestData();


            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "IsActive",
                    FilterValue = "true",
                    Operator = FilterCondition.Equals,
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = expressionBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Equal(4, filteredList.Count);
            Assert.DoesNotContain(filteredList, p => p.IsActive==false);
        }

        [Fact]
        public void PredicateFilter_NotEqualsCondition_ReturnsNonMatchingBoolResults()
        {
            // Arrange
            var persons = GetTestData();


            var filters = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "IsActive",
                    FilterValue = "true",
                    Operator = FilterCondition.NotEquals,
                }
            };

            var predicateBuilder = new ExpressionBuilder<Person>();

            // Act
            var expression = predicateBuilder.Create(filters);
            var filteredList = persons.AsQueryable().Where(expression).ToList();

            // Assert
            Assert.Equal(2, filteredList.Count);
            Assert.DoesNotContain(filteredList, p => p.IsActive==true);
        }
    }
}
