using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Juanagui.Validation
{
    public class Notification : INotification
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

        public string this[string field]
        {
            get { return _notificationMessages.Where(msg => msg.PropertyName.Equals(field)).Select(msg => msg.ErrorMessage).FirstOrDefault(); }
        }

        public void Add(string fieldName, string message)
        {
            _notificationMessages.Add(new NotificationMessage(fieldName, message));
        }

        public Boolean IsValid()
        {
            return !_notificationMessages.Any();
        }

        public override string ToString()
        {
            return String.Concat(this);
        }
    }
}
