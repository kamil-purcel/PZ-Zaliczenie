namespace WarehouseMVC.Domain.Model;

public class CustomerContactInformation
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }

    public int CustomerRef { get; set; }

    public virtual Customer Customer { get; set; }
}