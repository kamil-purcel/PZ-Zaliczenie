using System.ComponentModel;

namespace WarehouseMVC.Web.Models;

public class Item
{
    [DisplayName("Sequence Number")] public int Id { get; set; }

    public string Name { get; set; }
    public string TypeName { get; set; }
}