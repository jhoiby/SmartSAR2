using System;
using System.Collections.Generic;
using System.Text;
using SmartSAR.BC.Common.Bases;
using Xunit;

namespace UnitTests.BoundedContextsCommon.Bases
{
    public class EntityBaseTests
    {
        [Fact]
        public void ParamaterlessConstructor_SetsId()
        {
            // Arrange

            // Act
            var sut = new TestEntity().Id;

            // Assert
            Assert.NotEqual(default(Guid), sut);
        }
    }

    public class TestEntity : EntityBase
    {
    }
}
