using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Juanagui.Validation
{
    public class Validator
    {
        private static readonly Dictionary<Type, List<NamedValidationAttribute>> ValidationAttributesMap = new Dictionary<Type, List<NamedValidationAttribute>>();

        // Find all the ValidationAttribute’s for a given Type, and connect
        // each ValidationAttribute to the correct Property
        private static IEnumerable<NamedValidationAttribute> FindAttributes(Type type)
        {
            if (ValidationAttributesMap.ContainsKey(type))
                return ValidationAttributesMap[type];

            return (from property in type.GetProperties()
                    let attributes = Attribute.GetCustomAttributes(property, typeof (ValidationAttribute))
                    from ValidationAttribute attribute in attributes
                    select new NamedValidationAttribute(attribute, property)).ToList();
        }

        public static void Validate(object target, INotification notification)
        {
            var atts = FindAttributes(target.GetType());
            foreach (var att in atts)
            {
                if (!att.ValidateTarget(target))
                    notification.Add(att.PropertyName, att.FormatErrorMessage(att.PropertyName));
            }
        }
    }
}
