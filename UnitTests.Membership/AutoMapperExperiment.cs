using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoMapper;

namespace UnitTests.Contexts.Membership
{
    public class AutoMapperExperiment
    {
        [Fact]
        public void AutoMapperFirstTry()
        {
            // Arrange
            Mapper.Initialize(cfg => cfg.CreateMap<Person,PersonDto>());
            var person = new Person {FirstName = "Bilbo", LastName = "Baggins"};

            // Act
            PersonDto personDto = Mapper.Map<PersonDto>(person);

            // Assert
            Assert.Equal("Bilbo", personDto.FirstName);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
