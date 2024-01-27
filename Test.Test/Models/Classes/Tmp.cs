namespace DatePrinter.Web.Models.Classes;

public class Tmp
{
    public Tmp(int id, string name, int categoryId, string category)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        Category = category;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public int CategoryId { get; set; }
    public string Category { get; set; }
}