using System;

namespace Mmu.WpfGraphApiTool.Infrastructure.Reflection.Services
{
    public interface IEnumerableTypeReflectionService
    {
        Type GetGenericTypeOfIEnumerable(object genericEnumerable);
    }
}