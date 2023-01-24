namespace Task4_0.Pages
{
    public class GooglePage : Form
    {
        public GooglePage() : base(By.XPath("//input[@id='identifierId']"), "Google")
        {

        }

        private ITextBox emailTextBox = ElementFactory.Get<ITextBox>(By.XPath("//input[@id='identifierId']"), "Email");
        private IButton loginNextButton = ElementFactory.Get<IButton>(By.XPath("//div[@id='identifierNext']"), "Next");
        private IButton passwordNextButton = ElementFactory.Get<IButton>(By.XPath("//div[@id='passwordNext']"), "Next");
        private IButton accessNextButton = ElementFactory.Get<IButton>(By.XPath("//div[@id='submit_approve_access']"), "Next");
        private ITextBox passwordTextBox = ElementFactory.Get<ITextBox>(By.XPath("//input[@name='password']"), "Password");


        public void WaitAndInputEmailToTextBox(string email) => WaitAndTypeText(emailTextBox, email);

        public void WaitAndInputPasswordToTextBox(string password) => WaitAndTypeText(passwordTextBox, password);

        public void WaitAndClickPasswordNextButton() => WaitAndClickButton(passwordNextButton);

        public void WaitAndClickAccessNextButton() => WaitAndClickButton(accessNextButton);

        public void WaitAndClickLoginNextButton() => WaitAndClickButton(loginNextButton);


        private void WaitAndClickButton(IButton button)
        {
            ConditionalWait.WaitFor(x => button.State.IsDisplayed);
            button.Click();
        }

        private void WaitAndTypeText(ITextBox textBox, string text)
        {
            ConditionalWait.WaitFor(x => textBox.State.IsDisplayed);
            textBox.ClearAndType(text);
        }
    }
}