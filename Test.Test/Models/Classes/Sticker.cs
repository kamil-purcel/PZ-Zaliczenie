using PdfSharpCore.Drawing;

namespace DatePrinter.Web.Models.Classes;

public class Sticker
{
    public Sticker(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public double Width { get; set; } // 35
    public double Height { get; set; } // 35

    public double ConvertToPoint(double size)
    {
        return XUnit.FromMillimeter(size);
    }
}