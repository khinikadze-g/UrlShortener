

using Microsoft.AspNetCore.Mvc.Testing;
using UrlShortener.Api;

namespace UrlShortener.tests
{
    public class ApiFixture : WebApplicationFactory<IApiAssemblyMarker>
    {
    }
}
