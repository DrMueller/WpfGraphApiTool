using System;
using Mmu.WpfGraphApiTool.Infrastructure.Invariance;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Models
{
    public class ViewViewModelMap
    {
        public Type ViewModelType { get; }
        public Type ViewType { get; }

        public ViewViewModelMap(Type viewType, Type viewModelType)
        {
            Guard.ObjectNotNull(() => viewType);
            Guard.ObjectNotNull(() => viewModelType);

            ViewModelType = viewModelType;
            ViewType = viewType;
        }
    }
}