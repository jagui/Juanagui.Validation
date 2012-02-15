using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juanagui.Validation.Tests
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void Notification_AddNotificationMessage_EnumerateAndFind()
        {
            var notification = new Notification { { "field", "was invalid" } };
            var notificationMessage = notification.Single();
            Assert.AreEqual("was invalid", notificationMessage.ErrorMessage);
            Assert.AreEqual("field", notificationMessage.PropertyName);
        }

        [TestMethod]
        public void Notification_AddNotificationMessage_ReadError()
        {
            var notification = new Notification
                                   {
                                       {"field", "was invalid"},
                                       {"other field", "was invalid too"}
                                   };
            notification.ToString().Should().Be("was invalid, was invalid too");
        }

        [TestMethod]
        public void Notification_AddNotificationMessage_GetViaIndexer()
        {
            var notification = new Notification { { "field", "was invalid" } };
            Assert.AreEqual("was invalid", notification["field"]);
        }

        [TestMethod]
        public void Notification_AddNotificationMessage_IsNotValid()
        {
            var notification = new Notification { { "field", "was invalid" } };
            Assert.IsFalse(notification.IsValid());
        }

        [TestMethod]
        public void Notification_OffTheShelf_IsValid()
        {
            var notification = new Notification();
            Assert.IsTrue(notification.IsValid());
        }

    }
}
