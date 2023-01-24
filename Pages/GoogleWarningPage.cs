namespace Task4_0.Pages
{
    public class GoogleWarningPage : Form
    {
        public GoogleWarningPage() : base(By.XPath("//div[@class='ZFr60d CeoRYc']"), "Warning")
        {
        }


        private IButton advancedButton = ElementFactory.Get<IButton>(By.XPath("//a[@jsname='BO4nrb']"), "Advanced");
        private IButton allowDangerousButton = ElementFactory.Get<IButton>(By.XPath("//a[@jsname='ehL7e']"), "Allow Dangerous");


        public void WaitAndClickAdvancedButton() => WaitAndClickButton(advancedButton);

        public void WaitAndClickAllowDangerousButton() => WaitAndClickButton(allowDangerousButton);

        private void WaitAndClickButton(IButton button)
        {
            ConditionalWait.WaitFor(x => button.State.IsDisplayed);
            button.Click();
        }
    }
}