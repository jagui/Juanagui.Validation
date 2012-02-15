using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Juanagui.Validation.Tests
{
    internal class ValidateableForTests : IDataErrorInfo
    {
        [Required]
        public String RequiredProperty { get; set; }

        public string this[string columnName]
        {
            get { return this.GetErrorData(columnName); }
        }

        public string Error
        {
            get
            {
                return this.GetAllErrors(" ");
            }
        }
    }
}