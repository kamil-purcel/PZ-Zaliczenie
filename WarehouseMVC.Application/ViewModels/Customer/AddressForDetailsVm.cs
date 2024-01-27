using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModels.Customer;

public class AddressForDetailsVm : IMapFrom<Domain.Model.Address>
{
    [Required] 
    public int Id { get; set; }
    [Required] 
    public string Address { get; set; }
    [Required] 
    public string ZipCode { get; set; }
    [Required] 
    public string City { get; set; }
    [Required] 
    public string Country { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Model.Address, AddressForDetailsVm>()
            .ForMember(d => d.Address, opt
                => opt.MapFrom(s => s.Street + " " + s.BuildingNumber + "/" + s.FlatNumber));
    }
}