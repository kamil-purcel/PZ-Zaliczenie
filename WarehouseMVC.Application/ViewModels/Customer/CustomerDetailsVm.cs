using AutoMapper;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModels.Customer;

public class CustomerDetailsVm : IMapFrom<Domain.Model.Customer>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NIP { get; set; }
    public string Regon { get; set; }
    public string CEOFullName { get; set; }
    public string FirstLineOfContactInformation { get; set; }
    public List<AddressForDetailsVm> Addresses { get; set; }
    public List<ContactDetailListVm> Emails { get; set; }
    public List<ContactDetailListVm> PhoneNumbers { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Model.Customer, CustomerDetailsVm>()
            .ForMember(d => d.CEOFullName, opt
                => opt.MapFrom(s => s.CEOName + " " + s.CEOLastName))
            .ForMember(d => d.FirstLineOfContactInformation, opt
                => opt.MapFrom(
                    s => s.CustomerContactInformation.FirstName + " " + s.CustomerContactInformation.LastName))
  
            .ForMember(d => d.Addresses, opt => opt.Ignore())
            .ForMember(d => d.Emails, opt => opt.Ignore())
            .ForMember(d => d.PhoneNumbers, opt => opt.Ignore());
    }
}