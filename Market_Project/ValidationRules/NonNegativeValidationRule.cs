using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Market_Project.ValidationRules
{
    public class NonNegativeValidationRule : ValidationRule   
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (decimal.TryParse(value?.ToString(), out decimal val) && val >= 0)
                return ValidationResult.ValidResult;

            return new ValidationResult(false, "Value Can't be negative");
            
        }
    }
}
