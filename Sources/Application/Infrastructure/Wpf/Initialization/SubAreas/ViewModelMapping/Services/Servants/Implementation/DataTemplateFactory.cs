using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using JetBrains.Annotations;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Models;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants.Implementation
{
    [UsedImplicitly]
    public class DataTemplateFactory : IDataTemplateFactory
    {
        public DataTemplate CreateWithViewModelMappings(ViewViewModelMap map)
        {
            var context = CreateContext(map);
            var dataTemplateXaml = CreateDataTemplateXaml(map.ViewModelType.Name, map.ViewType.Name);

            var result = (DataTemplate)XamlReader.Parse(dataTemplateXaml, context);

            return result;
        }

        private static ParserContext CreateContext(ViewViewModelMap map)
        {
            var context = new ParserContext { XamlTypeMapper = new XamlTypeMapper(Array.Empty<string>()) };

            context.XamlTypeMapper.AddMappingProcessingInstruction(
                "vm",
                map.ViewModelType.Namespace ?? string.Empty,
                map.ViewModelType.Assembly.FullName ?? string.Empty);

            context.XamlTypeMapper.AddMappingProcessingInstruction(
                "v",
                map.ViewType.Namespace ?? string.Empty,
                map.ViewType.Assembly.FullName ?? string.Empty);

            context.XmlnsDictionary.Add(string.Empty, "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            return context;
        }

        private static string CreateDataTemplateXaml(string viewModelTypeName, string viewTypeName)
        {
            const string XamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
            var result = string.Format(CultureInfo.InvariantCulture, XamlTemplate, viewModelTypeName, viewTypeName);

            return result;
        }
    }
}