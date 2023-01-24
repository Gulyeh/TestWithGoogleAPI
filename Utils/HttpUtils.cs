namespace Task4_0.Utils
{
    public static class HttpUtils
    {
        public static async Task<T?> Get<T>(string url, string? access_token)
        {
            var driver = HttpDriver.GetHttpClient();
            if (driver is null) return default;
            if(access_token is not null && access_token != string.Empty)
                driver.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                
            var response = await driver.GetAsync(url);

            return await ConvertToResponse<T>(response);
        }

        public static async Task<T?> Post<T>(string url)
        {
            var driver = HttpDriver.GetHttpClient();
            if (driver is null) return default;

            var response = await driver.PostAsync(url, null);

            return await ConvertToResponse<T>(response);
        }

        private static async Task<T?> ConvertToResponse<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<T>(content);
            return json;
        }
    }
}