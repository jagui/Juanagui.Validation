using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juanagui.Validation.Tests
{
    [TestClass]
    public class IDataErrorInfoExtensionsTests
    {
        [TestMethod]
        public void GetErrorData()
        {
            var validatable = new Validatable();
            Assert.AreEqual("The Required field is required.", validatable.GetErrorData("Required"));
            validatable.Required = "valid";
            Assert.IsNull(validatable.GetErrorData("Required"));
        }

        [TestMethod]
        public void GetAllErrors()
        {
            var validatable = new Validatable();
            Assert.AreEqual("The Required field is required. ", validatable.GetAllErrors(" "));
            validatable.Required = "valid";
            Assert.AreEqual(String.Empty, validatable.GetAllErrors(" "));
        }

        [TestMethod]
        public void IsValid()
        {
            var validatable = new Validatable();
            Assert.IsFalse(validatable.IsValid());
            validatable.Required = "valid";
            Assert.IsTrue(validatable.IsValid());
        }
    }
}
