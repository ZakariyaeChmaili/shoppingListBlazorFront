using Blazored.LocalStorage;
using MudBlazorTemplates2.core;
using MudBlazorTemplates2.Modules.AuthenticationModule.Models;
using System.Net.Http.Json;

namespace MudBlazorTemplates2.Modules.AuthenticationModule.Serivces
{
    public class AuthenticationService : IAuthenticationService
    {
        public HttpClient Http { get; }
        public ILocalStorageService LocalStorage { get; }

        public AuthenticationService(HttpClient http, ILocalStorageService localStorage)
        {
            Http = http;
            LocalStorage = localStorage;
        }


        public string test()
        {
            return "hello from authServic";
        }


        public async Task<TokenResponse> Login(string username, string password)
        {
            var loginModel = new
            {
                username = username,
                password = password
            };

            var response = await this.Http.PostAsJsonAsync("/Auth/login", loginModel);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Login failed");

            var token = await response.Content.ReadFromJsonAsync<TokenResponse>();
            //store the token in local storage
            await LocalStorage.SetItemAsStringAsync("AuthToken", token!.Token);
            return token;

        }

    }
}
