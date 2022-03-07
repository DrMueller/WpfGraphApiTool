using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.ViewExtensions.Converters
{
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }

            return (Visibility)value == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }

            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}