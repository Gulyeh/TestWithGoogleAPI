namespace Task4_0.Utils
{
    public static class BrowserUtils
    {
        public static string GetParamFromUrl(string param)
        {
            var url = AqualityServices.Browser.CurrentUrl;
            Uri uri = new Uri(url);
            var code = HttpUtility.ParseQueryString(uri.Query).Get(param);
            return code is null ? string.Empty : code;
        }

        public static void SwitchToFrame(IWebElement element) => AqualityServices.Browser.Driver.SwitchTo().Frame(element);
        public static void SwitchToDefaultContent() => AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
    }
}