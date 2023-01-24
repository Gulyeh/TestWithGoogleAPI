namespace Task4_0.Utils
{
    public static class ConverterUtils
    {
        public static HtmlDocument Base64ToHTML(string? base64)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            if (base64 is null || base64 == string.Empty) return htmlDoc;

            var validBase = base64.Replace('-', '+').Replace('_', '/');
            byte[] data = Convert.FromBase64String(validBase);
            var htmlText = Encoding.UTF8.GetString(data);

            htmlDoc.LoadHtml(htmlText);
            return htmlDoc;
        }
    }
}