using System.Reflection;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public static class BindingObjectExtensions
    {
        public static Binding GetBinding(this BindableObject self, BindableProperty property)
        {
            var methodInfo = typeof(BindableObject).GetTypeInfo().GetDeclaredMethod("GetContext");
            var context = methodInfo?.Invoke(self, new[] { property });

            var propertyInfo = context?.GetType().GetTypeInfo().GetDeclaredField("Binding");
            return propertyInfo?.GetValue(context) as Binding;
        }

        public static object GetBindingExpression(this Binding self)
        {
            var fieldInfo = self?.GetType().GetTypeInfo().GetDeclaredField("_expression");
            return fieldInfo?.GetValue(self);
        }
    }

}
