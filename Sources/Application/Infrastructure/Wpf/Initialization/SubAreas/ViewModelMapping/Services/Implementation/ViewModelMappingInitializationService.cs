using System.Collections;
using System.Windows;
using Mmu.WpfGraphApiTool.Infrastructure.TypeExtensions.Collections;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Models;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Implementation
{
    public class ViewModelMappingInitializationService : IViewModelMappingInitializationService
    {
        private readonly IDataTemplateFactory _dataTemplateFactory;
        private readonly IResourceDictionaryFactory _resourceDictionaryFactory;
        private readonly IViewViewModelMapFactory _viewViewModelMapFactory;

        public ViewModelMappingInitializationService(
            IDataTemplateFactory dataTemplateFactory,
            IResourceDictionaryFactory resourceDictionaryFactory,
            IViewViewModelMapFactory viewViewModelMapFactory)
        {
            _dataTemplateFactory = dataTemplateFactory;
            _resourceDictionaryFactory = resourceDictionaryFactory;
            _viewViewModelMapFactory = viewViewModelMapFactory;
        }

        public void Initialize()
        {
            var resourceDictionary = _resourceDictionaryFactory.CreateEmpty();
            _viewViewModelMapFactory
                .CreateAll()
                .ForEach(map => AddDataTemplate(resourceDictionary, map));

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void AddDataTemplate(IDictionary resourceDictionary, ViewViewModelMap map)
        {
            var dataTemplate = _dataTemplateFactory.CreateWithViewModelMappings(map);
            if (dataTemplate.DataTemplateKey == null)
            {
                return;
            }

            resourceDictionary.Add(dataTemplate.DataTemplateKey, dataTemplate);
        }
    }
}