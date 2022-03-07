using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels
{
    public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged<T>(T newValue, ref T oldValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(newValue, oldValue))
            {
                return;
            }

            oldValue = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}