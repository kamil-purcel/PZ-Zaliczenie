using AutoMapper;

namespace WarehouseMVC.Application.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}