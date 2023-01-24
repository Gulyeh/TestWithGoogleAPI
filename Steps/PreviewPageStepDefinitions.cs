namespace Task4_0.Steps
{
    [Binding]
    public class PreviewPageStepDefinitions
    {
        private readonly PreviewPage previewPage;

        public PreviewPageStepDefinitions()
        {
            previewPage = new PreviewPage();
        }

        [Then(@"A preview page is opened")]
        public void ThenAPreviewPageIsOpened()
        {
            Assert.IsTrue(previewPage.WaitForOpened(), "Preview is not opened");
        }

        [When(@"I follow link to unsubscribe from newsletter")]
        public void WhenIFollowLinkToUnsubscribeFromNewsletter()
        {
            var link = previewPage.GetUnsubscribeLink();
            AqualityServices.Browser.GoTo(link);
        }
    }
}