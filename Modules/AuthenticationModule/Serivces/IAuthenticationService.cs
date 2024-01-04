using MudBlazorTemplates2.Modules.AuthenticationModule.Models;

namespace MudBlazorTemplates2.Modules.AuthenticationModule.Serivces
{
    public interface IAuthenticationService
    {
        HttpClient Http { get; }

        Task<TokenResponse> Login(string username, string password);
        string test();
    }
}