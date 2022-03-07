using System;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Rules;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Validation.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Configuration.Services
{
    public interface IPropertyRulesBuilder<T>
        where T : ValidatableViewModel<T>
    {
        IPropertyRulesBuilder<T> ApplyRule(IValidationRule rule);

        IPropertyRulesBuilder<T> ApplyRule(Func<object, ValidationResult> ruleExpression);

        IValidationConfigurationBuilder<T> BuildForProperty();
    }
}