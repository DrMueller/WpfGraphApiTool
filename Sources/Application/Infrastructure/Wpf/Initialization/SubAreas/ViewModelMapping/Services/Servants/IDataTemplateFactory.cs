using System.Windows;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants
{
    public interface IDataTemplateFactory
    {
        DataTemplate CreateWithViewModelMappings(ViewViewModelMap map);
    }
}