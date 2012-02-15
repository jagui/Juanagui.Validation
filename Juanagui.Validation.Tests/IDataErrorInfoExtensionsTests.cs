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
            var validateableForTests = new ValidateableForTests();
            validateableForTests.GetErrorData("RequiredProperty").Should().Contain("RequiredProperty");
            validateableForTests.RequiredProperty = "valid";
            validateableForTests.GetErrorData("RequiredProperty").Should().BeNull();
        }

        [TestMethod]
        public void GetAllErrors()
        {
            var validateableForTests = new ValidateableForTests();
            validateableForTests.GetAllErrors(" ").Should().Contain("RequiredProperty");
            validateableForTests.RequiredProperty = "valid";
            validateableForTests.GetAllErrors(" ").Should().BeEmpty();
        }

        [TestMethod]
        public void IsValid()
        {
            var validateableForTests = new ValidateableForTests();
            validateableForTests.IsValid().Should().BeFalse();
            validateableForTests.RequiredProperty = "valid";
            validateableForTests.IsValid().Should().BeTrue();
        }
    }
}
