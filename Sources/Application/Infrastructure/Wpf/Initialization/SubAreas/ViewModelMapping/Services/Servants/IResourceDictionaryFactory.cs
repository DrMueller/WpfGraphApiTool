using System.Windows;
using JetBrains.Annotations;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants
{
    [UsedImplicitly]
    public interface IResourceDictionaryFactory
    {
        ResourceDictionary CreateEmpty();
    }
}