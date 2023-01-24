namespace Task4_0.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            AqualityServices.Browser.Maximize();
            scenarioContext["accessToken"] = "ya29.a0AeTM1ifJXziTKPh3ymPdtlqnfKIkCCrp7zl8UiNsK1RID7vvQjlmfNM7bgfnXWYKq7GggR6A68zXS2F9pmr0-ZE4PkXUOwj_47Z7_r4LoS-2Xl0nGZsCTur2oX3hpihOqQC80bTwyMfGWgc27rt3a3ninofOaCgYKAcgSARISFQHWtWOmnnIuMEjIzOGxJCGyJmtwLg0163"; //provide accessToken here manually in case of problems with google auth
        }

        [AfterScenario]
        public void AfterScenario()
        {
            HttpDriver.Dispose();
            AqualityServices.Browser.Quit();
        }
    }
}