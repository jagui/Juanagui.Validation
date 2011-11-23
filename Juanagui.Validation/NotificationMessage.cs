using System;

namespace Juanagui.Validation
{
    public struct NotificationMessage : IEquatable<NotificationMessage>
    {
        private readonly String _propertyName;
        private readonly String _errorMessage;

        public String PropertyName
        {
            get { return _propertyName; }
        }
        public String ErrorMessage
        {
            get { return _errorMessage; }
        }


        public NotificationMessage(String propertyName, String errorMessage)
        {
            _errorMessage = errorMessage;
            _propertyName = propertyName;
        }


        public bool Equals(NotificationMessage other)
        {
            return Equals(other._propertyName, _propertyName) && Equals(other._errorMessage, _errorMessage);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(NotificationMessage)) return false;
            return Equals((NotificationMessage)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((_propertyName != null ? _propertyName.GetHashCode() : 0) * 397) ^ (_errorMessage != null ? _errorMessage.GetHashCode() : 0);
            }
        }
        public static bool operator ==(NotificationMessage left, NotificationMessage right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(NotificationMessage left, NotificationMessage right)
        {
            return !left.Equals(right);
        }
    }
}