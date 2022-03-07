namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors
{
    public interface INavigatableViewModel : IDisplayableViewModel
    {
        string NavigationDescription { get; }
        int NavigationSequence { get; }
    }
}