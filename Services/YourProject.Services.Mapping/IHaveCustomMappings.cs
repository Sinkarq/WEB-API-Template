using AutoMapper;

namespace YourProject.Services.Mapping;

public interface IHaveCustomMappings
{
    void CreateMappings(IProfileExpression configuration);
}