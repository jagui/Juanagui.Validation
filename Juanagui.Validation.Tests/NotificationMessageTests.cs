using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Juanagui.Validation.Tests
{
    [TestClass]
    public class NotificationMessageTests
    {
        [TestMethod]
        public void NotificationMessage_Equality()
        {
            var notificationMessage1 = new NotificationMessage("propertyName1", "errorMessage1");
            var notificationMessage2 = new NotificationMessage("propertyName1", "errorMessage1");
            var notificationMessage3 = new NotificationMessage("propertyName3", "errorMessage3");

            Assert.AreEqual(notificationMessage1, notificationMessage2);
            Assert.AreNotEqual(notificationMessage1, notificationMessage3);
            Assert.IsTrue(notificationMessage1 == notificationMessage2);
            Assert.IsTrue(notificationMessage1 != notificationMessage3);
        }
    }
}
