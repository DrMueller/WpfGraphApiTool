using System.Collections.ObjectModel;
using System.Windows;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.ViewExtensions.Grids.InformationGrids.ViewData;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.ViewExtensions.Grids.InformationGrids.Components
{
    public partial class InformationGrid
    {
        public static readonly DependencyProperty InformationEntriesProperty = DependencyProperty.Register(nameof(InformationEntries), typeof(ObservableCollection<InformationGridEntryViewData>), typeof(InformationGrid));

        public ObservableCollection<InformationGridEntryViewData> InformationEntries
        {
            get => (ObservableCollection<InformationGridEntryViewData>)GetValue(InformationEntriesProperty);
            set => SetValue(InformationEntriesProperty, value);
        }

        public InformationGrid()
        {
            InitializeComponent();
        }
    }
}