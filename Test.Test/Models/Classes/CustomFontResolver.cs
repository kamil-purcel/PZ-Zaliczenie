using PdfSharpCore.Fonts;

namespace DatePrinter.Web.Models.Classes;

public class CustomFontResolver : IFontResolver
{
    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        throw new NotImplementedException();
    }

    public byte[] GetFont(string faceName)
    {
        throw new NotImplementedException();
    }

    public string DefaultFontName { get; }
}