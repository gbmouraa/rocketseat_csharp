using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts
{
    //https://chatgpt.com/c/6a56cc09-77a8-83e9-9a0b-3d59752b8d8a explicação
    public class ExpenseReportFontResolver : IFontResolver
    {
        public byte[]? GetFont(string faceName)
        {
            var stream = ReadFontFile(faceName);

            if(stream is null)
                stream = ReadFontFile(FontHelper.DEFAULT_FONT);

            var length = (int)stream!.Length;

            var data =  new byte[length];

            stream.Read(buffer: data, offset: 0, count: length);

            return data;
        }

        public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
        {
            return new FontResolverInfo(familyName);
        }

        private Stream? ReadFontFile(string familyName)
        {
            var assembly = Assembly.GetExecutingAssembly(); // obtem o assembly do projeto atual

            return assembly.GetManifestResourceStream($"CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts.{familyName}.ttf");
        }
    }
}
