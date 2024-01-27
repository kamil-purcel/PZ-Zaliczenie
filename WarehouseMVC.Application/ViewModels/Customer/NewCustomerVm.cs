using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using WarehouseMVC.Application.Mapping;

namespace WarehouseMVC.Application.ViewModels.Customer;

public class NewCustomerVm : IMapFrom<Domain.Model.Customer>
{
    [Required] public int Id { get; set; }

    [DisplayName("Company name")]
    [Required] public string Name { get; set; }

    [Required] public string NIP { get; set; }
    
    [StringLength(14, MinimumLength = 9)] public string Regon { get; set; }
    
    [DisplayName("CEO Firstname")]
    public string? CEOName { get; set; }
    
    [DisplayName("CEO Lastname")]
    public string? CEOLastName { get; set; }

    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewCustomerVm, Domain.Model.Customer>().ReverseMap();
    }
}

public class NewCustomerValidation : AbstractValidator<NewCustomerVm>
{
    public NewCustomerValidation()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.NIP).Length(10);
        RuleFor(x => x.Regon).Length(9, 14);
        RuleFor(x => x.Name).MaximumLength(255);
        RuleFor(x => x.CEOName).MaximumLength(255);
        RuleFor(x => x.CEOLastName).MaximumLength(255);
    }
}