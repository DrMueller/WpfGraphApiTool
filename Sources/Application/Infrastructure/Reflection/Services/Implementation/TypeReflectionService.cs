using System;
using System.Linq;

namespace Mmu.WpfGraphApiTool.Infrastructure.Reflection.Services.Implementation
{
    public class TypeReflectionService : ITypeReflectionService
    {
        public bool CheckIfTypeIsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            if (interfaceTypes.Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == genericType))
            {
                return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            var baseType = givenType.BaseType;

            return baseType != null && CheckIfTypeIsAssignableToGenericType(baseType, genericType);
        }
    }
}