using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.Navigation.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.Navigation.Services
{
    public interface INavigationEntryFactory
    {
        Task<IReadOnlyCollection<NavigationEntry>> CreateAllAsync();
    }
}