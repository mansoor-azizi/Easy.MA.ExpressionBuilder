// See https://aka.ms/new-console-template for more information
using Easy.MA.ExpressionBuilder;
using Easy.MA.ExpressionBuilder.Core;
using Easy.MA.ExpressionBuilder.Models;

Console.ForegroundColor = ConsoleColor.Red;
Console.Write(" ♥ ");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(" Easy Expression Bulider by Mansoor Azizi ...");

// create a custom list
var personsGenerator = new DataGenerator();

// create filter list
var filters = new List<Filter>();
filters.Add(new Filter()
{
    PropertyName = "Car.ModelName",
    FilterValue = "HONDA",
    Operator = "InRange",

});
filters.Add(new Filter()
{
    PropertyName = "Name",
    FilterValue = "Michael",
    Operator = "Equals",

});

// get filter expression AND
var expressionWithAnd = new ExpressionBuilder<Person>().Create(filters,ExpressionBaseOperator.AND);

// filter list
var finalListWithAnd = personsGenerator.GeneratePersonsQueryable().Where(expressionWithAnd).ToList();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("");
Console.WriteLine("Final Filtered List With AND Operator");

Console.ForegroundColor = ConsoleColor.Gray;
finalListWithAnd.ForEach(person => Console.WriteLine("{0,-25} {1}" ,person.Name + " "+ person.Family,person.Car.ModelName));


// get filter expression OR
var expressionWithOR = new ExpressionBuilder<Person>().Create(filters, ExpressionBaseOperator.OR);

// filter list
var finalListWithOr = personsGenerator.GeneratePersonsQueryable().Where(expressionWithOR).ToList();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("");
Console.WriteLine("Final Filtered List With OR Operator");

Console.ForegroundColor = ConsoleColor.Gray;
finalListWithOr.ForEach(person => Console.WriteLine("{0,-25} {1}", person.Name + " " + person.Family, person.Car.ModelName));


// to show how to use expression with list and compiled expression
var compiledExpressionOr= expressionWithOR.Compile();

var finalListWithCompiledQuery = personsGenerator.GeneratePersonsList().Where(compiledExpressionOr).ToList();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("");
Console.WriteLine("Final Compiled Expression With OR Operator On List");

Console.ForegroundColor = ConsoleColor.Gray;
finalListWithCompiledQuery.ForEach(person => Console.WriteLine("{0,-25} {1}", person.Name + " " + person.Family, person.Car.ModelName));

Console.ReadKey();

