using AutoMapper;

namespace YourProject.Server.Infrastructure.Mapping.Interfaces;

public interface IHaveCustomMappings
{
    void CreateMappings(IProfileExpression configuration);
}