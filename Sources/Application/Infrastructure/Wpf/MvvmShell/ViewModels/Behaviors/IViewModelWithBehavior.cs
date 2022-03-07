using System.Diagnostics.CodeAnalysis;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors
{
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "Marker Interface")]
    public interface IViewModelWithBehavior : IViewModel
    {
    }
}