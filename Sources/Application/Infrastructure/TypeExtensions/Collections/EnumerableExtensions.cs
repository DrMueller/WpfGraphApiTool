using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmu.WpfGraphApiTool.Infrastructure.TypeExtensions.Collections
{
    public static class EnumerableExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> selector)
        {
            foreach (var entry in source)
            {
                selector(entry);
            }
        }

        public static async Task ForEachAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> selector)
        {
            foreach (var entry in source)
            {
                await selector(entry);
            }
        }
    }
}