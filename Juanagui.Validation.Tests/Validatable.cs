using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Juanagui.Validation.Tests
{
    internal class Validatable : IDataErrorInfo
    {
        [Required]
        public String Required { get; set; }

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