using System;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Validation.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Rules
{
    public class GenericValidationRule : IValidationRule
    {
        private readonly Func<object, ValidationResult> _validationCallback;

        public GenericValidationRule(Func<object, ValidationResult> validationCallback)
        {
            _validationCallback = validationCallback;
        }

        public ValidationResult Validate(object value)
        {
            return _validationCallback(value);
        }
    }
}