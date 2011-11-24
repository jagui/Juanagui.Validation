using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Juanagui.Validation.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void Validator_ValidateInvalidClass_NotificationIsAskedToAddANotificationMessage()
        {
            var notification = MockRepository.GenerateMock<INotification>();
            var validatable = new Validatable {Required = null};
            Validator.Validate(validatable, notification);
            notification.AssertWasCalled(n => n.Add(Arg<String>.Is.Equal("Required"), Arg<String>.Is.Anything));
        }

        [TestMethod]
        public void Validator_ValidateValidClass_NotificationIsNotAskedToAddANotificationMessage()
        {
            var notification = MockRepository.GenerateMock<INotification>();
            var validatable = new Validatable { Required = "validValue" };
            Validator.Validate(validatable, notification);
            notification.AssertWasNotCalled(n => n.Add(Arg<String>.Is.Equal("Required"), Arg<String>.Is.Anything));
        }
    }
}
