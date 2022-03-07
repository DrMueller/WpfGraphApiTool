using System.Windows;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.Components.CommandBars.ViewData;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.Components.CommandBars.Controls
{
    public partial class CommandBar
    {
        public static readonly DependencyProperty CommandsProperty =
            DependencyProperty.Register(
                nameof(Commands),
                typeof(CommandsViewData),
                typeof(CommandBar),
                new PropertyMetadata(null, null));

        public CommandsViewData Commands
        {
            get => (CommandsViewData)GetValue(CommandsProperty);
            set => SetValue(CommandsProperty, value);
        }

        public CommandBar()
        {
            InitializeComponent();
        }
    }
}