using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Common.Extensions;
using Xunit;

namespace UnitTests.BoundedContextsCommon.Extensions
{
    public class ValueRequiredExtensionTests
    {
        public class RequireValidatorExtensionTests
        {
            private string _nullString = null;
            private string _defaultString = default(string);
            private string _zeroLengthString = "";

            // STRING VALIDATION TESTS
            //

            [Fact]
            public void Require_GivenString_ReturnsSame()
            {
                // Arrange
                string testString = "Where we're going we don't need roads.";

                // Act
                var sut = testString.Require();
                bool equalReference = ReferenceEquals(testString, sut);

                // Assert
                Assert.Same(testString, sut);
            }

            [Fact]
            public void Require_GivenNullString_ThrowsArgumentNullException()
            {
                // Arrange

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => _nullString.Require());
            }

            [Fact]
            public void Require_GivenDefaultString_ThrowsArgumentNullException()
            {
                // Arrange

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => _defaultString.Require());
            }

            [Fact]
            public void Require_GivenZeroLengthString_ThrowsArgumentException()
            {
                // Arrange

                // Act & Assert
                Assert.Throws<ArgumentException>(() => _zeroLengthString.Require());
            }

            [Theory]
            [InlineData(" ")]
            [InlineData("  ")]
            [InlineData("\t")]
            [InlineData("\r")]
            [InlineData("\n")]
            public void Require_GivenWhitespace_ThrowsArgumentException(string testString)
            {
                // Arrange

                // Act + Assert
                Assert.Throws<ArgumentException>(() => testString.Require());
            }

            // GUID VALIDATION TESTS
            //
            [Fact]
            public void Require_GivenValidGuid_ReturnsEqualGuid()
            {
                // Arrange
                Guid _validGuid = Guid.NewGuid();

                // Act
                Guid sut = _validGuid.Require();

                // Assert
                Assert.Equal(_validGuid, sut);
            }

            [Fact]
            public void Require_GivenEmptyGuid_ThrowsArgumentException()
            {
                // Arrange
                Guid _emptyGuid = Guid.Empty;

                // Act + Assert
                Assert.Throws<ArgumentException>(() => _emptyGuid.Require());
            }
        }
    }
}
