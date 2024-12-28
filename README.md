
# Dynamic Expression Builder

.NET 8 Easy Expression Builder by Mansoor Azizi.

A generic dynamic expression builder that works with any type of class.

## Features

- **Dynamic Expression Creation**: Build expressions dynamically for any class.
- **Generic Implementation**: Works seamlessly with different types of classes, including nested classes of any depth.
- **Easy Integration**: Simple to integrate into your existing projects.

## Installation

To install the Dynamic Expression Builder, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/dynamic-expression-builder.git
   ```

## Usage

Here's a basic example of how to use the Dynamic Expression Builder in a C# application:

```csharp
// Define the Person class
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

// Define the Car class
public class Car
{
    public int Id { get; set; }
    public string? ModelName { get; set; }
    public string Description { get; set; }
    public int? Score { get; set; }
    public CarColor Color { get; set; }
}

// Create filter list
var filters = new List<Filter>();
filters.Add(new Filter()
{
    PropertyName = "Car.ModelName",
    FilterValue = "HONDA",
    Operator = "Equals"
});
filters.Add(new Filter()
{
    PropertyName = "Name",
    FilterValue = "Michael",
    Operator = "Equals"
});

// Get filter expression with AND operator
var expressionWithAnd = new ExpressionBuilder<Person>().Create(filters, ExpressionBaseOperator.AND);

// Filter list
var finalListWithAnd = personListQueryable.GeneratePersonsQueryable().Where(expressionWithAnd).ToList();
```

## JSON Input Example

The following JSON can be used as input to the API:

```json
{
    "filters": [
        {
            "PropertyName": "Car.ModelName",
            "FilterValue": "HONDA",
            "Operator": "Equals"
        },
        {
            "PropertyName": "Name",
            "FilterValue": "Michael",
            "Operator": "Equals"
        }
    ],
    "baseOperator": "AND"
}
```

## Supported Operators

The following operators are supported for filtering:

- `Equals`
- `NotEquals`
- `GreaterThan`
- `GreaterThanOrEqual`
- `LessThan`
- `LessThanOrEqual`
- `InRange`
- `Contains`
- `NotContains`
- `InSet`

## Base Operators

The following base operators are supported and applied to all filters:

- `AND`
- `OR`

## Contributing

Contributions are welcome! Please fork the repository and submit pull requests.

## License

This project is free and open source.

## Contact

If you have any questions or need further assistance, feel free to reach out:

- Email: mr.mansour.azizi@gmail.com
- GitHub: mansoor-azizi
```
