using System.Reflection;
using AutoMapper;
using YourProject.Server.Features.Cats.Models;

namespace YourProject.Server.MappingUtilities;

public static class AutoMapperConfig
{
    private static bool _initialized;

    private static IMapper? _mapper;

    public static IMapper MapperInstance
    {
        get
        {
            if (_mapper is null)
            {
                RegisterMappings();
            }

            return _mapper!;
        }
    }

    public static void RegisterMappings()
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;

        var config = new MapperConfigurationExpression();
        config.CreateProfile(
            "ReflectionProfile",
            configuration =>
            {
                configuration
                    .RegisterCatMapping();
            });
        _mapper = new Mapper(new MapperConfiguration(config));
    }

    private static IProfileExpression RegisterCatMapping(this IProfileExpression configuration)
    {
        configuration.CreateMap<Cat, Animal>();
        
        return configuration;
    }
} 