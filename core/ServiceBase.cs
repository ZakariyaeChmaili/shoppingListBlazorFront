namespace MudBlazorTemplates2.core
{
    public class ServiceBase
    {
        public ServiceBase(HttpClient http)
        {
            Http = http;
        }

        public HttpClient Http { get; }
    }
}
