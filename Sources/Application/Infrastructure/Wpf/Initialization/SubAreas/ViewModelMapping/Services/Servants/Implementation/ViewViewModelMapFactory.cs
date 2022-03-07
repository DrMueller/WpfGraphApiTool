using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Mmu.WpfGraphApiTool.Infrastructure.Reflection.Services;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Models;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.Views.Interfaces;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants.Implementation
{
    [UsedImplicitly]
    public class ViewViewModelMapFactory : IViewViewModelMapFactory
    {
        private static readonly Type _viewModelMapType = typeof(IViewMap<>);
        private readonly ITypeReflectionService _typeReflectionService;

        public ViewViewModelMapFactory(ITypeReflectionService typeReflectionService)
        {
            _typeReflectionService = typeReflectionService;
        }

        public IReadOnlyCollection<ViewViewModelMap> CreateAll()
        {
            var viewMapTypes = GetViewMapTypes();
            var result = viewMapTypes.Select(CreateFromViewMapType).ToList();

            return result;
        }

        private ViewViewModelMap CreateFromViewMapType(Type viewMapType)
        {
            var mapInterface = viewMapType.GetInterfaces().First(f => _typeReflectionService.CheckIfTypeIsAssignableToGenericType(f, _viewModelMapType));

            var viewModelType = mapInterface.GetGenericArguments().First();

            return new ViewViewModelMap(viewMapType, viewModelType);
        }

        private IEnumerable<Type> GetViewMapTypes()
        {
            var result = typeof(ViewViewModelMapFactory).Assembly.GetTypes().Where(
                f =>
                    _typeReflectionService.CheckIfTypeIsAssignableToGenericType(f, _viewModelMapType)
                    && !f.IsInterface
                    && !f.IsAbstract).ToList();

            return result;
        }
    }
}