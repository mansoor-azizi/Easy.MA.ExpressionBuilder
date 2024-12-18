// See https://aka.ms/new-console-template for more information
using Easy.MA.ExpressionBuilder;
using Easy.MA.ExpressionBuilder.Core;
using Easy.MA.ExpressionBuilder.Models;
using System;
using System.Text.Json;

Console.WriteLine("This is a Predicate Bulider App by Mansoor Azizi");

// create a custom list
var personListQueryable = new DataGenerator();

// create filter list
var filters = new List<Filter>();
filters.Add(new Filter()
{
    PropertyName = "Car.ModelName",
    FilterValue = "HONDA",
    Operator = FilterCondition.Equals,

});
filters.Add(new Filter()
{
    PropertyName = "Name",
    FilterValue = "Michael",
    Operator = FilterCondition.Equals,

});

// get filter expression AND
var expressionWithAnd = new ExpressionBuilder<Person>().Create(filters,ExpressionBaseOperator.AND);

// filter list
var finalListWithAnd = personListQueryable.GeneratePersonsQueryable().Where(expressionWithAnd).ToList();

Console.WriteLine("");
Console.WriteLine("Final Filtered List With AND Operator");
foreach (var person in finalListWithAnd) {
    Console.WriteLine($"{person.Name} {person.Family} - {person.Car.ModelName}");
}

// get filter expression OR
var expressionWithOR = new ExpressionBuilder<Person>().Create(filters, ExpressionBaseOperator.OR);

// filter list
var finalListWithOr = personListQueryable.GeneratePersonsQueryable().Where(expressionWithOR).ToList();
Console.WriteLine("");
Console.WriteLine("Final Filtered List With OR Operator");
foreach (var person in finalListWithOr)
{
    Console.WriteLine($"{person.Name} {person.Family} - {person.Car.ModelName}");
}

// to show how to use expression with list
var compiledExpressionOr= expressionWithOR.Compile();
var personList = personListQueryable.GeneratePersonsList();
var folteredPersonList = personList.Where(compiledExpressionOr);
Console.WriteLine("");
Console.WriteLine("Final Compiled Expression With OR Operator On List");
foreach (var person in finalListWithOr)
{
    Console.WriteLine($"{person.Name} {person.Family} - {person.Car.ModelName}");
}

Console.ReadKey();

