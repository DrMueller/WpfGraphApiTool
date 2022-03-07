using System.Windows;
using System.Windows.Markup;
using JetBrains.Annotations;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Initialization.SubAreas.ViewModelMapping.Services.Servants.Implementation
{
    [UsedImplicitly]
    public class ResourceDictionaryFactory : IResourceDictionaryFactory
    {
        public ResourceDictionary CreateEmpty()
        {
            const string XamlTemplate = "<ResourceDictionary></ResourceDictionary>";

            var context = new ParserContext();
            context.XmlnsDictionary.Add(string.Empty, "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");

            var result = (ResourceDictionary)XamlReader.Parse(XamlTemplate, context);

            return result;
        }
    }
}