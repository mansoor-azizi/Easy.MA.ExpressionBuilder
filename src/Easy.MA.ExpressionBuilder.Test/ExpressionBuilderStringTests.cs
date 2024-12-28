using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Easy.MA.ExpressionBuilder.Core;
using Easy.MA.ExpressionBuilder.Models;
using Easy.MA.ExpressionBuilder;

namespace expressionBuilderTests
{
    public class ExpressionBuilderStringTests
    {
        private IQueryable<Person> GetTestData()
        {
            return new DataGenerator().GeneratePersonsQueryable();
        }

        [Fact]
        public void Create_PredicateFilter_EqualsCondition_ReturnsCorrectResults()
        {
            // Arrange
            var personList = GetTestData();

            var filterPredicateList = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.ModelName",
                    FilterValue = "HONDA",
                    Operator = "Equals",
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = expressionBuilder.Create(filterPredicateList);
            var finalList = personList.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(3, finalList.Count);
            Assert.All(finalList, p => Assert.Equal("HONDA", p.Car.ModelName));
        }

        [Fact]
        public void Create_PredicateFilter_NotEqualsCondition_ReturnsCorrectResults()
        {
            // Arrange
            var personList = GetTestData();

            var filterPredicateList = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.ModelName",
                    FilterValue = "HONDA",
                    Operator ="NotEquals",
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = expressionBuilder.Create(filterPredicateList);
            var finalList = personList.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(3, finalList.Count);
            Assert.Contains(finalList, p => p.Car.ModelName == "TOYOTA");
            Assert.Contains(finalList, p => p.Car.ModelName == "FORD");
            Assert.Contains(finalList, p => p.Car.ModelName == "NISSAN");
        }

        [Fact]
        public void Create_PredicateFilter_ContainsCondition_ReturnsCorrectResults()
        {
            // Arrange
            var personList = GetTestData();

            var filterPredicateList = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.Description",
                    FilterValue = "HONDA",
                    Operator = "Contains",
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = expressionBuilder.Create(filterPredicateList);
            var finalList = personList.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(3, finalList.Count);
            Assert.All(finalList, p => p.Car.Description.Contains("HONDA"));
        }

        [Fact]
        public void Create_PredicateFilter_InSetCondition_ReturnsCorrectResults()
        {
            // Arrange
            var personList = GetTestData();

            var filterPredicateList = new List<Filter>
            {
                new Filter
                {
                    PropertyName = "Car.ModelName",
                    FilterValue = "HONDA,TOYOTA",
                    Operator = "InSet",
                }
            };

            var expressionBuilder = new ExpressionBuilder<Person>();

            // Act
            var predicate = expressionBuilder.Create(filterPredicateList);
            var finalList = personList.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.Equal(4, finalList.Count);
            Assert.Contains(finalList, p => p.Car.ModelName == "HONDA");
            Assert.Contains(finalList, p => p.Car.ModelName == "TOYOTA");
        }
    }
}
