using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Market_Project.ValidationRules
{
    public class NonEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (!string.IsNullOrWhiteSpace(str))
                return ValidationResult.ValidResult;

            return new ValidationResult(false, "This field can't be empty");
        }
    }
}
