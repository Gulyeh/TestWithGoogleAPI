namespace Task4_0.Steps
{
    [Binding]
    public class GoogleLoginPageStepDefinitions
    {
        private readonly GooglePage googlePage;

        public GoogleLoginPageStepDefinitions()
        {
            googlePage = new GooglePage();
        }


        [Given(@"I enter google email address in authorization window")]
        public void GivenIEnterGoogleEmailAddressInAuthorizationWindow()
        {
            var googleEmail = GoogleUtils.GetGoogleSettings().Email;
            googlePage.WaitAndInputEmailToTextBox(googleEmail);
        }

        [Given(@"I click Next button on google login page")]
        public void GivenIClickNextButtonOnGoogleLoginPage()
        {
            googlePage.WaitAndClickLoginNextButton();
        }

        [Given(@"I click Next button on google password page")]
        public void GivenIClickNextButtonOnGooglePasswordPage()
        {
            googlePage.WaitAndClickPasswordNextButton();
        }

        [Given(@"I click Next button on google access page")]
        public void GivenIClickNextButtonOnGoogleAccessPage()
        {
            googlePage.WaitAndClickAccessNextButton();
        }


        [Given(@"I enter google account password in authorization window")]
        public void GivenIEnterGoogleAccountPasswordInAuthorizationWindow()
        {
            var googlePassword = GoogleUtils.GetGoogleSettings().Password;
            googlePage.WaitAndInputPasswordToTextBox(googlePassword);
        }
    }
}