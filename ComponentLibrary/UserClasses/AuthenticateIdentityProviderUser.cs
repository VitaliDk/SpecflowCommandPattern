using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComponentLibrary.UserClasses
{
    public class AuthenticateIdentityProviderUser
    {

        public TokenModel token { get; set; }

        public readonly HttpClient Client = new HttpClient();
        public async Task<TokenModel> AuthAsync()
        {
            Client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            var parameters = new Dictionary<string, string> { { "grant_type", "client_credentials" }, { "client_id", "EMS" }, { "client_secret", "Calamar1" }, { "scope", "IdentityProviderApi.users.write" } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            var response = await Client.PostAsync($"https://dmiqa2.calastonetest.com/login/oauth/connect/token", encodedContent).ConfigureAwait(false);
           //read the body
            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return token = ParseToken(responseBody);
        }

        private TokenModel ParseToken(string response)
        {
            var serializerSettings = new JsonSerializerSettings();
            var tokenModel = JsonConvert.DeserializeObject<TokenModel>(response, serializerSettings);
            return tokenModel;
        }
    }
}
