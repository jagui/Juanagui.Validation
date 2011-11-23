using System;
using System.ComponentModel.DataAnnotations;

namespace Juanagui.Validation
{
    [AttributeUsage(AttributeTargets.Property |
     AttributeTargets.Field, AllowMultiple = false)]
    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        public GreaterThanZeroAttribute()
            : base("{0} must be greater than zero")
        { }

        public override bool IsValid(object value)
        {
            try
            {
                return Convert.ToInt64(value) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
