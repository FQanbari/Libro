using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static void RegisterAllEntities<BaseType>(this ModelBuilder builder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(x => x.GetExportedTypes())
            .Where(x => !x.IsAbstract && x.IsPublic && x.IsClass && typeof(BaseType).IsAssignableFrom(x));

        foreach (Type type in types)
            builder.Entity(type);
    }
}
