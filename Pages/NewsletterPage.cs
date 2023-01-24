namespace Task4_0.Pages
{
    public class NewsletterPage : Form
    {
        public NewsletterPage() : base(By.XPath("//section[contains(@id, 'cpt-newletters-archive')]"), "Newsletter")
        {

        }

        private ITextBox newsletterFormTextBox = ElementFactory.Get<ITextBox>(By.XPath("//input[@type='email']"), "Newsletter Form Email");
        private IButton submitNewsletterButton = ElementFactory.Get<IButton>(By.XPath("//input[@data-event='NL_submit']"), "Submit Newsletter");
        private IButton closeFormButton = ElementFactory.Get<IButton>(By.XPath("//a[@class='close-modal ']"), "Close Form");
        private By newsletterLocator = By.XPath("//div[@class='p-8']");
        private By selectThisNewsletterButtonLocator = By.XPath(".//label[contains(@class, 'unchecked-label')]");
        private By seePreviewButtonLocator = By.XPath(".//a[contains(@href, 'previews')]");
        //forms and other different elements are as labels since IElement itself throws an error that its not supported, I couldn't find any other way but it works
        private ILabel newsletterForm = ElementFactory.Get<ILabel>(By.XPath("//section[contains(@class, 'newletters-archive') and contains(@class, 'sticky bottom')]"), "Newsletter form");
        private ILabel? randomNewsletter;



        public void WaitForSubscriptionForm() => ConditionalWait.WaitFor(x => closeFormButton.State.IsClickable);

        public void ClickSelectThisNewsletterButton() => LocateAndClickButtonOnSelectedNewsletter(selectThisNewsletterButtonLocator);

        public void ClickSeePreviewButtonOnNewsletter() => LocateAndClickButtonOnSelectedNewsletter(seePreviewButtonLocator);

        public void ChooseRandomNewsletter()
        {
            var elements = ElementFactory.FindElements<ILabel>(newsletterLocator);
            randomNewsletter = RandomUtils.GetRandomObject(elements);
        }

        public bool IsNewsletterFormDisplayed()
        {
            ConditionalWait.WaitFor(x => newsletterForm.State.IsDisplayed);
            return newsletterForm.State.IsDisplayed;
        }

        public void WaitAndInputEmailToNewsletterFormTextBox(string email)
        {
            ConditionalWait.WaitFor(x => newsletterFormTextBox.State.IsDisplayed);
            newsletterFormTextBox.ClearAndType(email);
        }

        public void WaitAndClickSubmitNewsletterButton()
        {
            ConditionalWait.WaitFor(x => submitNewsletterButton.State.IsDisplayed);
            submitNewsletterButton.Click();
        }


        private void LocateAndClickButtonOnSelectedNewsletter(By locator)
        {
            var button = randomNewsletter?.FindChildElements<IButton>(locator);
            button?.First()!.Click();
        }
    }
}