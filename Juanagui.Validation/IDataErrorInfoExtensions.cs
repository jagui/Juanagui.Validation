using System;
using System.ComponentModel;
using System.Text;

namespace Juanagui.Validation
{
    public static class IDataErrorInfoExtensions
    {
        public static String GetErrorData(this IDataErrorInfo dataErrorInfo, String propertyName)
        {
            return dataErrorInfo.GetNotificationMessages()[propertyName];
        }

        public static String GetAllErrors(this IDataErrorInfo dataErrorInfo, String separator)
        {
            var error = new StringBuilder();
            foreach (var message in dataErrorInfo.GetNotificationMessages())
            {
                error.AppendFormat("{0}{1}", message.ErrorMessage, separator);
            }
            return error.ToString();
        }

        public static Boolean IsValid(this IDataErrorInfo dataErrorInfo)
        {
            return dataErrorInfo.GetNotificationMessages().IsValid();
        }

        private static Notification GetNotificationMessages(this IDataErrorInfo dataErrorInfo)
        {
            var notification = new Notification();
            Validator.Validate(dataErrorInfo, notification);
            return notification;
        }
    }
}
