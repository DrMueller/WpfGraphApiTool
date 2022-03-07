using System;

namespace Mmu.WpfGraphApiTool.Infrastructure.Reflection.Services
{
    public interface ITypeReflectionService
    {
        bool CheckIfTypeIsAssignableToGenericType(Type givenType, Type genericType);
    }
}