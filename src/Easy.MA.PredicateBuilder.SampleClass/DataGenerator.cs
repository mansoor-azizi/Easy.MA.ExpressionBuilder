using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.MA.ExpressionBuilder.Models
{
    public class DataGenerator
    {
        public IQueryable<Person> GeneratePersonsQueryable()
        {
            return GeneratePersonsList().AsQueryable();
        }
        public IList<Person> GeneratePersonsList()
        {
            return new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Michael",
                Family = "Johnson",
                Mobile = "555-1234",
                DateOfBirth = new DateTime(1985, 5, 1),
                Car = new Car
                {
                    Id = 1,
                    ModelName = "HONDA",
                    Description = "Great HONDA car",
                    Score = null,
                    Color = CarColor.Red
                },
                IsActive = true
            },
            new Person
            {
                Id = 2,
                Name = "Sarah",
                Family = "Connor",
                Mobile = "555-5678",
                DateOfBirth = null,//new DateTime(1990, 7, 15),
                Car = new Car
                {
                    Id = 2,
                    ModelName = "HONDA",
                    Description = "Reliable HONDA car",
                    Score = 80,
                    Color = CarColor.Blue
                },
                IsActive = true
            },
            new Person
            {
                Id = 3,
                Name = "Alice",
                Family = "Brown",
                Mobile = "555-9101",
                DateOfBirth = new DateTime(1975, 10, 20),
                Car = new Car
                {
                    Id = 3,
                    ModelName = "TOYOTA",
                    Description = "Toyota car",
                    Score = 85,
                    Color = CarColor.Green
                },
                IsActive = false
            },
            new Person
            {
                Id = 4,
                Name = "Bob",
                Family = "Smith",
                Mobile = "555-1122",
                DateOfBirth = new DateTime(1980, 3, 3),
                Car = new Car
                {
                    Id = 4,
                    ModelName = "FORD",
                    Description = "Ford car",
                    Score = 75,
                    Color = CarColor.Yellow
                },
                IsActive = null
            },
            new Person
            {
                Id = 5,
                Name = "John",
                Family = "Doe",
                Mobile = "555-2233",
                DateOfBirth = new DateTime(1995, 8, 22),
                Car = new Car
                {
                    Id = 5,
                    ModelName = "NISSAN",
                    Description = "Fast NISSAN car",
                    Score = 95,
                    Color = CarColor.Red
                },
                IsActive = true
            },
            new Person
            {
                Id = 6,
                Name = "Jane",
                Family = "Doe",
                Mobile = "555-3344",
                DateOfBirth = new DateTime(1987, 6, 16),
                Car = new Car
                {
                    Id = 6,
                    ModelName = "HONDA",
                    Description = "Powerful HONDA car",
                    Score = 88,
                    Color = CarColor.Blue
                },
                IsActive = true
            }
        };
        }
    }
}
