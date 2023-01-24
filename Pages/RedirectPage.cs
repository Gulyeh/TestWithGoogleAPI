namespace Task4_0.Pages
{
    public class RedirectPage : Form
    {
        //Google does not support UI for getting auth_code anymore so you have to take it from an URL param
        public RedirectPage() : base(By.XPath("//*[text()='localhost']"), "Redirect")
        {

        }

        public string WaitAndGetParamFromUrl(string param)
        {
            ConditionalWait.WaitFor(x => AqualityServices.Browser.CurrentUrl.Contains(param));
            return BrowserUtils.GetParamFromUrl(param);
        }
    }
}