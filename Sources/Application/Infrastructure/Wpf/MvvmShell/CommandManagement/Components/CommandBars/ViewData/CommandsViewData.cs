using System.Collections.Generic;
using Mmu.WpfGraphApiTool.Infrastructure.Invariance;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.Components.CommandBars.ViewData
{
    public class CommandsViewData
    {
        public IReadOnlyCollection<IViewModelCommand> Entries { get; }

        public CommandsViewData(params IViewModelCommand[] entries)
        {
            Guard.ObjectNotNull(() => entries);
            Entries = entries;
        }
    }
}