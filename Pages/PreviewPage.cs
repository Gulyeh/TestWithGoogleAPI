namespace Task4_0.Pages
{
    //made this class for some cleaner approach
    public class PreviewPage : Form
    {
        public PreviewPage() : base(By.XPath(""), "Preview")
        {
        }

        private By blockerLocator = By.XPath("//div[contains(@class, 'jquery-modal')]");
        private By IframeLocator = By.XPath(".//iframe[@class='iframe-preview']");
        private By linksLocator = By.XPath("//a");
        private IButton closePreviewButton = ElementFactory.Get<IButton>(By.XPath("//a[@href='#close-modal']"), "Close Preview");
        private IWebElement? iframePreview;


        public bool WaitForOpened()
        {
            //since its Iframe not a page so driver does not wait for it to load, I left base locator empty and made this one instead
            //also some forms have errors so tests are randomly failing because there is no iframe content
            closePreviewButton.State.WaitForExist();
            return closePreviewButton.State.IsDisplayed;
        }

        public string? GetUnsubscribeLink()
        {           
            FindPreviewIframe();
            if (iframePreview is null) return string.Empty;

            BrowserUtils.SwitchToFrame(iframePreview);

            var listOfLinks = ElementFactory.FindElements<IButton>(linksLocator);
            if (listOfLinks.Count < 1) return string.Empty;

            var unsubscribeLink = listOfLinks.First(x => x.GetAttribute("href").Contains("unsubscribe"));
            var link = unsubscribeLink?.GetAttribute("href");

            BrowserUtils.SwitchToDefaultContent();

            return link;
        }

        private void FindPreviewIframe()
        {
            //Its based on IWebElement since SwitchToFrame is a Selenium method and requires that to work, couldn't find anything similar to that in the framework
            var blockerElement = AqualityServices.Browser.Driver.FindElements(blockerLocator);
            if (blockerElement.Count() < 1) return;

            var iframeElement = blockerElement.First().FindElements(IframeLocator);
            if (iframeElement.Count() < 1) return;

            iframePreview = iframeElement.First();
        }
    }
}
