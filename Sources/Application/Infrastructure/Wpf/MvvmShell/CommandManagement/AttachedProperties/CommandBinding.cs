using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.AttachedProperties
{
    public static class CommandBinding
    {
        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty.RegisterAttached(
                "ViewModelCommand",
                typeof(IViewModelCommand),
                typeof(CommandBinding),
                new PropertyMetadata(AttachBinding));

        public static void AttachBinding(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var viewModelCommand = (IViewModelCommand)args.NewValue;

            if (dependencyObject is ButtonBase buttonBase)
            {
                if (viewModelCommand != null)
                {
                    buttonBase.Content = viewModelCommand.Description;
                    buttonBase.Command = viewModelCommand.Command;
                }
                else
                {
                    buttonBase.Content = null;
                    buttonBase.Command = null;
                }
            }
            else
            {
                throw new Exception("ViewModelCommand must implement ButtonBase.");
            }
        }

        public static IViewModelCommand GetViewModelCommand(DependencyObject dependencyObject)
        {
            return (IViewModelCommand)dependencyObject.GetValue(ViewModelCommandProperty);
        }

        public static void SetViewModelCommand(DependencyObject dependencyObject, IViewModelCommand value)
        {
            dependencyObject.SetValue(ViewModelCommandProperty, value);
        }
    }
}