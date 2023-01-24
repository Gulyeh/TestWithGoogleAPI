namespace Task4_0.Pages
{
    public class UnsubscribePage : Form
    {
        public UnsubscribePage() : base(By.XPath("//form[contains(@action, 'unsubscribe')]"), "Unsubscribe")
        {
        }

        private ITextBox emailTextBox = ElementFactory.Get<ITextBox>(By.XPath("//input[@id='email']"), "Email");
        private IButton confirmButton = ElementFactory.Get<IButton>(By.XPath("//button[@type='submit']"), "Submit");
        private ILabel unsubscribeLabel = ElementFactory.Get<ILabel>(By.XPath("//strong"), "Unsubscribe");

        public void WaitAndInputEmail(string email)
        {
            ConditionalWait.WaitFor(x => emailTextBox.State.IsDisplayed);
            emailTextBox.ClearAndType(email);
        }

        public bool IsUnsubscribeTextDisplayed()
        {
            ConditionalWait.WaitFor(x => unsubscribeLabel.State.IsDisplayed);
            return unsubscribeLabel.State.IsDisplayed;
        }

        public void WaitAndClickSubmitButton()
        {
            ConditionalWait.WaitFor(x => confirmButton.State.IsDisplayed);
            confirmButton.Click();
        }
    }
}