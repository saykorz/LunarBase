using System.Windows;
using System.Windows.Data;

namespace LunarBase.Library.Extensions
{
    public static class BindingExtensions
    {
        public static BindingExpressionBase SetBinding(this FrameworkElement target, DependencyProperty dp, object source, string path)
        {
            Binding b = new Binding(path);
            b.Source = source;
            b.Mode = BindingMode.TwoWay;
            return BindingOperations.SetBinding(target, dp, b);
        }
        public static BindingExpressionBase SetBinding(this FrameworkElement target, DependencyProperty dp, object source, string path, BindingMode bindingMode)
        {
            Binding b = new Binding(path);
            b.Source = source;
            b.Mode = bindingMode;
            return BindingOperations.SetBinding(target, dp, b);
        }
        public static BindingExpressionBase SetBinding(this FrameworkElement target, DependencyProperty dp, object source, string path, IValueConverter converter)
        {
            Binding b = new Binding(path);
            b.Source = source;
            b.Converter = converter;
            return BindingOperations.SetBinding(target, dp, b);
        }
        public static BindingExpressionBase SetBinding(this FrameworkElement target, DependencyProperty dp, object source, string path, IValueConverter converter, object converterParameter)
        {
            Binding b = new Binding(path);
            b.Source = source;
            b.Converter = converter;
            b.Mode = BindingMode.TwoWay;
            b.ConverterParameter = converterParameter;
            return BindingOperations.SetBinding(target, dp, b);
        }
    }
}
