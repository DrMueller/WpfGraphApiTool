using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.ViewExtensions.Grids.AttachedProperties
{
    public static class DoubleClickBinding
    {
        public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.RegisterAttached("DoubleClickCommand", typeof(ICommand), typeof(DoubleClickBinding), new PropertyMetadata(AttachOrRemoveDataGridDoubleClickEvent));
        public static readonly DependencyProperty DoubleClickParameterProperty = DependencyProperty.RegisterAttached("DoubleClickParameter", typeof(object), typeof(DoubleClickBinding), new PropertyMetadata(AttachOrRemoveDataGridDoubleClickEvent));

        public static void AttachOrRemoveDataGridDoubleClickEvent(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is DataGrid dataGrid)
            {
                if (args.OldValue == null && args.NewValue != null)
                {
                    dataGrid.MouseDoubleClick += ExecuteDataGridDoubleClick;
                }
                else if (args.OldValue != null && args.NewValue == null)
                {
                    dataGrid.MouseDoubleClick -= ExecuteDataGridDoubleClick;
                }
            }
        }

        public static ICommand GetDoubleClickCommand(DependencyObject dependencyObject)
        {
            return (ICommand)dependencyObject.GetValue(DoubleClickCommandProperty);
        }

        public static object GetDoubleClickParameter(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(DoubleClickParameterProperty);
        }

        public static void SetDoubleClickCommand(DependencyObject dependencyObject, ICommand value)
        {
            dependencyObject.SetValue(DoubleClickCommandProperty, value);
        }

        public static void SetDoubleClickParameter(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(DoubleClickParameterProperty, value);
        }

        private static void ExecuteDataGridDoubleClick(object sender, MouseButtonEventArgs args)
        {
            var dependencyObject = sender as DependencyObject;
            var cmd = (ICommand)dependencyObject?.GetValue(DoubleClickCommandProperty);

            if (cmd == null)
            {
                return;
            }

            var commandParameter = dependencyObject.GetValue(DoubleClickParameterProperty);
            commandParameter ??= dependencyObject;

            if (cmd.CanExecute(commandParameter))
            {
                cmd.Execute(commandParameter);
            }
        }
    }
}