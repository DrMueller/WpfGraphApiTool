using System.Windows;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.Components.CommandButtons
{
    public partial class CommandButton
    {
        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty.Register(
                nameof(ViewModelCommand),
                typeof(ViewModelCommand),
                typeof(CommandButton),
                new PropertyMetadata(null, null));

        public ViewModelCommand ViewModelCommand
        {
            get => (ViewModelCommand)GetValue(ViewModelCommandProperty);
            set => SetValue(ViewModelCommandProperty, value);
        }

        public CommandButton()
        {
            InitializeComponent();
        }
    }
}