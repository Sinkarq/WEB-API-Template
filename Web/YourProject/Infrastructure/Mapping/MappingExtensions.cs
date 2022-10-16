using AutoMapper;
using YourProject.Server.Features.Cats.Models;

namespace YourProject.Server.Infrastructure.Mapping;

internal static class MappingExtensions
{
    internal static MapperConfiguration CreateMappingConfiguration()
    {
        var mappingConfiguration = new MapperConfiguration(mc =>
        {
            mc.CreateMap<Cat, Animal>();
        });

        return mappingConfiguration;
    } 
    
    public static void AddMap<TSource, TDestination>(this IMapperConfigurationExpression expression)
        where TSource : class
        where TDestination : class
    {
        expression.CreateMap<TSource, TDestination>();
        expression.CreateMap<IEnumerable<TSource>, IEnumerable<TDestination>>();
    }
}