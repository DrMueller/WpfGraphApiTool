using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Mmu.WpfGraphApiTool.Infrastructure.Invariance.Servants;

namespace Mmu.WpfGraphApiTool.Infrastructure.Invariance
{
    [PublicAPI]
    public static class Guard
    {
        private const string CollectionNullOrEmptyMessage = "Collection {0} must not be null or empty.";
        private const string NullObjectExceptionMessage = "Object {0} must not be null.";
        private const string StringNullOrEmptyExceptionMessage = "String {0} must not be null or empty.";
        private const string ValueNullOrEmptyExceptionMessage = "Value {0} must not be null or empty.";

        public static void CollectionNotNullOrEmpty<T>(Expression<Func<IEnumerable<T>>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var collection = func();

            if (collection != null && collection.Any())
            {
                return;
            }

            ThrowException(CollectionNullOrEmptyMessage, propertyExpression);
        }

        public static void ObjectNotNull(Expression<Func<object>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var obj = func();

            if (obj != null)
            {
                return;
            }

            ThrowException(NullObjectExceptionMessage, propertyExpression);
        }

        public static void StringNotNullOrEmpty(Expression<Func<string>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var stringValue = func();

            if (!string.IsNullOrEmpty(stringValue))
            {
                return;
            }

            ThrowException(StringNullOrEmptyExceptionMessage, propertyExpression);
        }

        public static void That(Func<bool> guardClause, string exceptionMessage)
        {
            if (guardClause())
            {
                return;
            }

            ThrowException(exceptionMessage);
        }

        public static void ValueNotDefault<T>(Expression<Func<T>> propertyExpression)
            where T : struct
        {
            var func = propertyExpression.Compile();
            var funcValue = func();

            if (!EqualityComparer<T>.Default.Equals(funcValue, default))
            {
                return;
            }

            ThrowException(ValueNullOrEmptyExceptionMessage, propertyExpression);
        }

        private static void ThrowException<T>(string exceptionMessageShell, Expression<Func<T>> propertyExpression)
        {
            var propertyName = ExpressionServant.GetPropertyName(propertyExpression);
            var exceptionMessage = string.Format(exceptionMessageShell, propertyName);
            ThrowException(exceptionMessage);
        }

        private static void ThrowException(string exceptionMessage)
        {
            throw new ArgumentException(exceptionMessage);
        }
    }
}