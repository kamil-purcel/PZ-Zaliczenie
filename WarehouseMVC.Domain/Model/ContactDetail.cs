namespace WarehouseMVC.Domain.Model;

public class ContactDetail
{
    public int Id { get; set; }
    public string ContactDetailInformation { get; set; }
    public int ContactDetailTypeId { get; set; }
    public ContactDetailType ContactDetailType { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}