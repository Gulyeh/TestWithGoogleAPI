namespace Task4_0.Pages
{
    public class MainPage : Form
    {
        public MainPage() : base(By.XPath("//main[@id='enw-main-content']"), "Main")
        {
        }

        private IButton newsletterButton = ElementFactory.Get<IButton>(By.XPath("//span[@data-event='newsletter-link-header']"), "Newsletter");
        private IButton acceptCookiesButton = ElementFactory.Get<IButton>(By.XPath("//button[@id='didomi-notice-agree-button']"), "Accept Cookies");


        public void WaitAndClickNewsletterButton() => WaitAndClickButton(newsletterButton);

        public void WaitAndClickAcceptCookiesButton() => WaitAndClickButton(acceptCookiesButton);

        private void WaitAndClickButton(IButton button)
        {
            ConditionalWait.WaitFor(x => button.State.IsDisplayed);
            button.Click();
        }
    }
}