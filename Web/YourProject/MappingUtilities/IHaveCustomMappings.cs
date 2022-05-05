using AutoMapper;

namespace YourProject.Server.MappingUtilities;

public interface IHaveCustomMappings
{
    void CreateMappings(IProfileExpression configuration);
}