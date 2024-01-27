using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModels.Customer;

public class NewAddressVm : IMapFrom<Domain.Model.Address>
{
    [Required] 
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [DisplayName("Company name")]
    [Required] public string CustomerName { get; set; }
    [Required] 
    public string Street { get; set; }
    [Required] 
    public string BuildingNumber { get; set; }
    [Required] 
    public int FlatNumber { get; set; }
    [Required] 
    public string ZipCode { get; set; }
    [Required] 
    public string City { get; set; }
    [Required] 
    public string Country { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewAddressVm, Domain.Model.Address>().ReverseMap();
    }
}

public class NewAddressValidation : AbstractValidator<NewAddressVm>
{
    public NewAddressValidation()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.CustomerName).NotNull();
        RuleFor(x => x.Street).NotNull();
        RuleFor(x => x.BuildingNumber).NotNull();
        RuleFor(x => x.FlatNumber).NotNull();
        RuleFor(x => x.ZipCode).Length(6);
        RuleFor(x => x.City).NotNull();
        RuleFor(x => x.Country).MaximumLength(255);
    }
}