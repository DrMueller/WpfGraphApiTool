using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Validation.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Configuration.Services.Implementation
{
    internal class ValidationConfigurationBuilder<T> : IValidationConfigurationBuilder<T>
        where T : ValidatableViewModel<T>
    {
        private readonly List<PropertyRulesBuilder<T>> _rulesBuilders;
        private readonly ValidatableViewModel<T> _viewModel;

        internal ValidationConfigurationBuilder(ValidatableViewModel<T> viewModel)
        {
            _rulesBuilders = new List<PropertyRulesBuilder<T>>();
            _viewModel = viewModel;
        }

        public ValidationContainer<T> Build()
        {
            var propertyValidations = _rulesBuilders.Select(f => f.BuildValidation()).ToList();
            var container = new ValidationContainer<T>(_viewModel, propertyValidations);

            return container;
        }

        public IPropertyRulesBuilder<T> ForProperty<TField>(Expression<Func<T, TField>> expression)
        {
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(expression.Body is MemberExpression propertyExpression))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            var propertyName = propertyExpression.Member.Name;
            var rulesBuilder = _rulesBuilders.SingleOrDefault(f => f.PropertyName == propertyName);

            if (rulesBuilder != null)
            {
                return rulesBuilder;
            }

            rulesBuilder = new PropertyRulesBuilder<T>(propertyName, this);
            _rulesBuilders.Add(rulesBuilder);

            return rulesBuilder;
        }
    }
}