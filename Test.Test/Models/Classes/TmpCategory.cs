namespace DatePrinter.Web.Models.Classes;

public class TmpCategory
{
    public TmpCategory(int categoryId, string category)
    {
        CategoryId = categoryId;
        Category = category;
    }

    public int CategoryId { get; set; }
    public string Category { get; set; }
}