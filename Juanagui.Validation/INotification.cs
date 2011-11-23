using System;
using System.Collections.Generic;

namespace Juanagui.Validation
{
    public interface INotification : IEnumerable<NotificationMessage>
    {
        String this[String field] { get; }

        void Add(string fieldName, string message);

        Boolean IsValid();
    }
}