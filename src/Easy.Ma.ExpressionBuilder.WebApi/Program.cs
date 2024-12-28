using Easy.Ma.ExpressionBuilder.WebApi.Models;
using Easy.MA.ExpressionBuilder;
using Easy.MA.ExpressionBuilder.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapPost("/Persons", (FilterModel filterModel) =>
{
    // get filter expression
    var expression = new ExpressionBuilder<Person>().Create(filterModel.Filters, filterModel._BaseOperator);

    // create a custom list
    var personListQueryable = new DataGenerator();

    // filter list
    var result = personListQueryable.GeneratePersonsQueryable().Where(expression).ToList();

    return Results.Created($"/Persons", result);

});

app.Run();
