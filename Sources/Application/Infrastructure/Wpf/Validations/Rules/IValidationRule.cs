using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Validation.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Rules
{
    public interface IValidationRule
    {
        ValidationResult Validate(object value);
    }
}