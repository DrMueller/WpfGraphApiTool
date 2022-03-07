using JetBrains.Annotations;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors
{
    [PublicAPI]
    public interface IDisplayableViewModel : IViewModelWithBehavior
    {
        string HeadingDescription { get; }
    }
}