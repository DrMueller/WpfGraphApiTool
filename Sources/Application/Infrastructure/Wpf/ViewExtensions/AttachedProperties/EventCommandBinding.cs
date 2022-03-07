using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.ViewExtensions.AttachedProperties
{
    public static class EventCommandBinding
    {
        public static readonly DependencyProperty EventNameProperty =
            DependencyProperty.RegisterAttached(
                "EventName",
                typeof(string),
                typeof(EventCommandBinding),
                new PropertyMetadata(null, null));
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICommand),
                typeof(EventCommandBinding),
                new PropertyMetadata(null, CommandPropertyChangedCallback));
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached(
                "CommandParameter",
                typeof(object),
                typeof(EventCommandBinding),
                new PropertyMetadata(null, null));

        public static ICommand GetCommand(DependencyObject dependencyObject)
        {
            return (ICommand)dependencyObject.GetValue(CommandProperty);
        }

        public static object GetCommandParameter(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(CommandParameterProperty);
        }

        public static string GetEventName(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(EventNameProperty);
        }

        public static void SetCommand(DependencyObject dependencyObject, ICommand value)
        {
            dependencyObject.SetValue(CommandProperty, value);
        }

        public static void SetCommandParameter(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(CommandParameterProperty, value);
        }

        public static void SetEventName(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(EventNameProperty, value);
        }

        private static void CommandPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement uiElement)
            {
                var routedEvent = GetRoutedEvent(uiElement);

                if (e.OldValue != null)
                {
                    uiElement.RemoveHandler(routedEvent, new RoutedEventHandler(OnEvent));
                }

                if (e.NewValue != null)
                {
                    uiElement.AddHandler(routedEvent, new RoutedEventHandler(OnEvent), true);
                }
            }
        }

        private static RoutedEvent GetRoutedEvent(UIElement uiElement)
        {
            var eventName = GetEventName(uiElement);

            if (string.IsNullOrEmpty(eventName))
            {
                throw new NotImplementedException($"EventName for the Element {uiElement.Uid} is not set.");
            }

            // The RoutedEvents end all with Event, so we concat this to make sure we find the Field via Reflection
            eventName += "Event";

            var allRoutedEvents = typeof(UIElement)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(f => typeof(RoutedEvent).IsAssignableFrom(f.FieldType));

            var fieldInfoRoutedEvent = allRoutedEvents.FirstOrDefault(f => f.Name == eventName);
            var result = (RoutedEvent)fieldInfoRoutedEvent?.GetValue(null);

            if (result == null)
            {
                throw new NotImplementedException($"Routed Event {eventName} not found on UIElement.");
            }

            return result;
        }

        private static void OnEvent(object sender, RoutedEventArgs e)
        {
            var uiElement = sender as UIElement;

            if (uiElement?.GetValue(CommandProperty) is ICommand cmd)
            {
                var parameter = uiElement.GetValue(CommandParameterProperty);

                if (cmd.CanExecute(parameter))
                {
                    cmd.Execute(parameter);
                }
            }
        }
    }
}