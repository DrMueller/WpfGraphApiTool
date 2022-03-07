using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

//// ReSharper disable UnusedParameter.Global
namespace Mmu.WpfGraphApiTool.Infrastructure.Reflection.Extensions
{
    public static class PropertyExtensions
    {
        [SuppressMessage("Microsoft.Usage", "SA1119:StatementMustNotUseUnnecessaryParenthesis", Justification = "Actually needed")]
        public static PropertyInfo GetPropertyInfo<T, TProperty>(Expression<Func<T, TProperty>> property)
        {
            if (!(property.Body is MemberExpression propertyExpression))
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            var prop = propertyExpression.Member.Name;
            var propInfo = typeof(T).GetProperty(prop);

            return propInfo!;
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "owner", Justification = "Extension Method: Implicitly takes type of owner!")]
        public static PropertyInfo GetPropertyInfo<T, TField>(this T owner, Expression<Func<T, TField>> expression)
        {
            return GetPropertyInfo(expression);
        }

        public static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (expression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            if (expression.Body is UnaryExpression unaryExpression)
            {
                if (!(unaryExpression.Operand is MemberExpression mem))
                {
                    throw new NotImplementedException();
                }

                memberExpression = mem;
            }
            else
            {
                throw new NotImplementedException();
            }

            return memberExpression.Member.Name;
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "owner", Justification = "Extension Method: Implicitly takes type of owner!")]
        public static string GetPropertyName<T, TField>(this T owner, Expression<Func<T, TField>> expression)
        {
            return GetPropertyName(expression);
        }
    }
}