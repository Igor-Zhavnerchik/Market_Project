using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Market_Project.ValidationRules
{
    internal class DiscountValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value?.ToString(), out int val) && val >= 0 && val <= 1)
                return ValidationResult.ValidResult;

            return new ValidationResult(false, "Discount must be in range of 0 and 1");
        }
    }
}
