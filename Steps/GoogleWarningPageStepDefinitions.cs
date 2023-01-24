namespace Task4_0.Steps
{
    [Binding]
    public class GoogleWarningPageStepDefinitions
    {
        private readonly GoogleWarningPage googleWarningPage;

        public GoogleWarningPageStepDefinitions()
        {
            googleWarningPage = new GoogleWarningPage();
        }

        [Given(@"I click Advanced button on warning page")]
        public void GivenIClickAdvancedButtonOnWarningPage()
        {
            googleWarningPage.WaitAndClickAdvancedButton();
        }

        [Given(@"I click Open app button on warning page")]
        public void GivenIClickOpenAppButtonOnWarningPage()
        {
            googleWarningPage.WaitAndClickAllowDangerousButton();
        }
    }
}