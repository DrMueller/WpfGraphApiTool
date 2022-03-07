using System.Windows.Input;
using Mmu.WpfGraphApiTool.Infrastructure.Invariance;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.Navigation.Models
{
    public class NavigationEntry
    {
        public ICommand NavigationCommand { get; }
        public string NavigationDescription { get; }

        public NavigationEntry(ICommand navigationCommand, string navigationDescription)
        {
            Guard.ObjectNotNull(() => navigationCommand);
            Guard.StringNotNullOrEmpty(() => navigationDescription);

            NavigationCommand = navigationCommand;
            NavigationDescription = navigationDescription;
        }
    }
}