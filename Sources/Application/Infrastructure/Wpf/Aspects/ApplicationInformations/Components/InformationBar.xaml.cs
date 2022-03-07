using System.Windows;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.ViewData;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Aspects.ApplicationInformations.Components
{
    internal partial class InformationBar
    {
        public static readonly DependencyProperty InformationEntryProperty =
            DependencyProperty.Register(
                nameof(InformationEntry),
                typeof(InformationEntryViewData),
                typeof(InformationBar));

        public InformationEntryViewData InformationEntry
        {
            get => (InformationEntryViewData)GetValue(InformationEntryProperty);
            set => SetValue(InformationEntryProperty, value);
        }

        public InformationBar()
        {
            InitializeComponent();
        }
    }
}