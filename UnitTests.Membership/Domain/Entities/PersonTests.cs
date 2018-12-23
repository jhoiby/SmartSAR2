using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Common.Bases;
using Contexts.Membership.Domain.Entities;
using Xunit;

namespace UnitTests.Membership.Domain.Entities
{
    public class PersonTests
    {
        private string _validFirstName = "Wiley";
        private string _validLastName = "Coyote";
        private Guid _validAddressBookId = Guid.NewGuid();

        [Fact]
        public void Person_IsAssignableFromAggregateRootBase()
        {
            // Arrange
            
            // Act
            var sut = new PersonAggregate(_validFirstName, _validLastName);

            // Assert
            Assert.IsAssignableFrom<AggregateRootBase>(sut);
        }

        [Fact]
        public void NewPersonHasNonDefaultId()
        {
            // Arrange

            // Act
            var sut = new PersonAggregate(_validFirstName, _validLastName).Id;

            // Assert
            Assert.NotEqual(default(Guid), sut);
        }

        // "NAMES ONLY" CONSTRUCTOR TESTS

        [Fact]
        public void Constructor_GivenFirstName_SetsFirstName()
        {
            // Arrange

            // Act
            var sut = new PersonAggregate(_validFirstName, _validLastName);

            // Assert
            Assert.Same(_validFirstName, sut.FirstName);
        }

        [Fact]
        public void Constructor_GivenLastName_SetsLastName()
        {
            // Arrange

            // Act
            var sut = new PersonAggregate(_validFirstName, _validLastName);

            // Assert
            Assert.Same(_validLastName, sut.LastName);
        }

        [Fact]
        public void Constructor_GivenNullFirstName_ThrowsArgumentNullException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new PersonAggregate(null, _validLastName));
        }

        [Fact]
        public void Constructor_GivenNullLastName_ThrowsArgumentNullException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new PersonAggregate(_validFirstName, null));
        }

        [Fact]
        public void Constructor_GivenEmptyStringFirstName_ThrowsArgumentException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new PersonAggregate("", _validLastName));
        }

        [Fact]
        public void Constructor_GivenEmptyStringLastName_ThrowsArgumentException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new PersonAggregate(_validFirstName, ""));
        }

        [Theory]
        [InlineData(" Bobby Sue")]
        [InlineData("Bobby Sue    ")]
        [InlineData("Bobby Sue\n")]
        public void Constructor_GivenPaddedFirstName_TrimsName(string paddedName)
        {
            // Arrange

            // Act
            var sut = new PersonAggregate(paddedName, _validLastName).FirstName;

            // Assert
            Assert.Equal("Bobby Sue", sut);
        }
        
        [Theory]
        [InlineData(" Giffords")]
        [InlineData("Giffords    ")]
        [InlineData("Giffords\n")]
        public void Constructor_GivenPaddedLastName_TrimsName(string paddedName)
        {
            // Arrange

            // Act
            var sut = new PersonAggregate(_validFirstName, paddedName).LastName;

            // Assert
            Assert.Equal("Giffords", sut);
        }
    }
}
