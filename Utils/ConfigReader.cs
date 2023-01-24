namespace Task4_0.Utils
{
    public static class ConfigReader
    {
        public static T GetValue<T>(string name)
        {
            var settingsFile = AqualityServices.Get<ISettingsFile>();
            return settingsFile.GetValue<T>(name);
        }
    }
}