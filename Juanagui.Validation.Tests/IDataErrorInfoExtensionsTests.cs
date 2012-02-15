using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juanagui.Validation.Tests
{
    [TestClass]
    public class IDataErrorInfoExtensionsTests
    {
        [TestMethod]
        public void GetErrorData()
        {
            var validatable = new ValidateableForTests();
            validatable.GetErrorData("RequiredProperty").Should().Contain("RequiredProperty");
            validatable.RequiredProperty = "valid";
            validatable.GetErrorData("RequiredProperty").Should().BeNull();
        }

        [TestMethod]
        public void GetAllErrors()
        {
            var validatable = new ValidateableForTests();
            validatable.GetAllErrors(" ").Should().Contain("RequiredProperty");
            validatable.RequiredProperty = "valid";
            validatable.GetAllErrors(" ").Should().BeEmpty();
        }

        [TestMethod]
        public void IsValid()
        {
            var validatable = new ValidateableForTests();
            validatable.IsValid().Should().BeFalse();
            validatable.RequiredProperty = "valid";
            validatable.IsValid().Should().BeTrue();
        }
    }
}
