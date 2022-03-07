using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Configuration.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Configuration.Services.Implementation;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Validation.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors
{
    [PublicAPI]
    public abstract class ValidatableViewModel<T> : ViewModelBase, INotifyDataErrorInfo, IInitializableViewModel
        where T : ValidatableViewModel<T>
    {
        private ValidationContainer<T> _container;
        public bool HasErrors => _container.HasErrors;

        public IEnumerable GetErrors(string propertyName)
        {
            return _container.GetErrorMessages(propertyName);
        }

        public Task InitializeAsync(params object[] initParams)
        {
            var configBuilder = new ValidationConfigurationBuilder<T>(this);
            _container = ConfigureValidation(configBuilder);

            return OnInitializeAsync(initParams);
        }

        internal void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected abstract ValidationContainer<T> ConfigureValidation(IValidationConfigurationBuilder<T> builder);

        protected virtual Task OnInitializeAsync(params object[] initParams)
        {
            return Task.CompletedTask;
        }

        protected override void OnPropertyChanged<T>(T newValue, ref T oldValue, [CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(newValue, ref oldValue, propertyName);
            _container.Validate(propertyName);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}