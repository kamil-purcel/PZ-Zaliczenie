using System.ComponentModel;
using AutoMapper;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModels.Customer;

public class CustomerForListVm : IMapFrom<Domain.Model.Customer>
{
    public int Id { get; set; }
    
    [DisplayName("Company name")]
    public string Name { get; set; }
    public string NIP { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Model.Customer, CustomerForListVm>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.NIP, opt => opt.MapFrom(s => s.NIP));
    }

}