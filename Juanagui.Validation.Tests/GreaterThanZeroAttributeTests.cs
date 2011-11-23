using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juanagui.Validation.Tests
{
    [TestClass]
    public class GreaterThanZeroAttributeTests
    {
        [TestMethod]
        public void GreaterThanZeroAttribute_PassSomethingGreaterThanZeroToIsValid_ReturnsTrue()
        {
            var greaterThanZero = new GreaterThanZeroAttribute();
            Assert.IsTrue(greaterThanZero.IsValid(1));
        }

        [TestMethod]
        public void GreaterThanZeroAttribute_PassSomethingEqualOrLessThanZeroToIsValid_ReturnsFalse()
        {
            var greaterThanZero = new GreaterThanZeroAttribute();
            Assert.IsFalse(greaterThanZero.IsValid(0));
            Assert.IsFalse(greaterThanZero.IsValid(-1));
        }

        [TestMethod]
        public void GreaterThanZeroAttribute_PassSomethingNotNumeric_ReturnsFalse()
        {
            var greaterThanZero = new GreaterThanZeroAttribute();
            Assert.IsFalse(greaterThanZero.IsValid("a"));
        }

        [TestMethod]
        public void GreaterThanZeroAttribute_PassSomethingWhenInvalid_ErrorMessageIsProperlyFormatted()
        {
            var greaterThanZero = new GreaterThanZeroAttribute();
            Assert.AreEqual("field must be greater than zero",greaterThanZero.FormatErrorMessage("field"));
        }
    }
}
