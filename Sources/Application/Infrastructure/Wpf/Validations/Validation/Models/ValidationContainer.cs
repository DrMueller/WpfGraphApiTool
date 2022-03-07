using System.Collections.Generic;
using System.Linq;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Validation.Models
{
    public class ValidationContainer<T>
        where T : ValidatableViewModel<T>
    {
        private readonly IReadOnlyCollection<PropertyValidation> _propertyValidations;
        private readonly ValidatableViewModel<T> _viewModel;
        internal bool HasErrors { get; private set; }

        internal ValidationContainer(
            ValidatableViewModel<T> viewModel,
            IReadOnlyCollection<PropertyValidation> propertyValidations)
        {
            _viewModel = viewModel;
            _propertyValidations = propertyValidations;
        }

        internal IReadOnlyCollection<string> GetErrorMessages(string propertyName)
        {
            var propertyValidation = _propertyValidations.SingleOrDefault(f => f.PropertyName == propertyName);

            if (propertyValidation == null)
            {
                HasErrors = false;

                return new List<string>();
            }

            var propertyValue = _viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel);
            var errorMessages = propertyValidation.GetValidationErrorMessages(propertyValue);
            HasErrors = errorMessages.Any();

            return errorMessages;
        }

        internal void Validate(string propertyName)
        {
            if (GetErrorMessages(propertyName).Any())
            {
                _viewModel.OnErrorsChanged(propertyName);
            }
        }
    }
}