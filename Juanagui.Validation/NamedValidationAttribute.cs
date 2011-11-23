using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Juanagui.Validation
{
    public class NamedValidationAttribute : ValidationAttribute
    {
        private readonly ValidationAttribute _validationAttribute;
        private readonly PropertyInfo _propertyInfo;


        public String PropertyName
        {
            get
            {
                return _propertyInfo.Name;
            }
        }


        public NamedValidationAttribute(ValidationAttribute validationAttribute, PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
            _validationAttribute = validationAttribute;
        }

        public Boolean ValidateTarget(object target)
        {
            return IsValid(_propertyInfo.GetValue(target, null));
        }

        public ValidationAttribute ValidationAttribute
        {
            get
            {
                return this._validationAttribute;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return _validationAttribute.FormatErrorMessage(name);
        }

        public override bool IsDefaultAttribute()
        {
            return _validationAttribute.IsDefaultAttribute();
        }

        public override bool IsValid(object value)
        {
            return _validationAttribute.IsValid(value);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        public override bool Match(object obj)
        {
            return _validationAttribute.Match(obj);
        }

        public override object TypeId
        {
            get
            {
                return _validationAttribute.TypeId;
            }
        }
    }
}
