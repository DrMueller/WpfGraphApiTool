using System;
using System.Linq.Expressions;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Validation.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Configuration.Services
{
    public interface IValidationConfigurationBuilder<T>
        where T : ValidatableViewModel<T>
    {
        ValidationContainer<T> Build();

        IPropertyRulesBuilder<T> ForProperty<TField>(Expression<Func<T, TField>> expression);
    }
}