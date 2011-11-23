using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Juanagui.Validation
{
    public class Notification : IEnumerable<NotificationMessage>, INotification
    {
        private readonly List<NotificationMessage> _notificationMessages = new List<NotificationMessage>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<NotificationMessage> GetEnumerator()
        {
            return _notificationMessages.GetEnumerator();
        }

        public void Add(string fieldName, string message)
        {
            _notificationMessages.Add(new NotificationMessage(fieldName, message));
        }

        public Boolean IsValid()
        {
            return !_notificationMessages.Any();
        }
    }
}
