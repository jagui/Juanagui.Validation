using System;
using System.Collections.Generic;

namespace Juanagui.Validation
{
    public interface INotification
    {
        IEnumerator<NotificationMessage> GetEnumerator();

        void Add(string fieldName, string message);

        Boolean IsValid();
    }
}