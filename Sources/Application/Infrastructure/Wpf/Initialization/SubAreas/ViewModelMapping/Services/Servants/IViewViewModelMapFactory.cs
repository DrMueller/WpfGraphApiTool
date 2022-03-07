using System.Collections.Generic;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants
{
    public interface IViewViewModelMapFactory
    {
        IReadOnlyCollection<ViewViewModelMap> CreateAll();
    }
}