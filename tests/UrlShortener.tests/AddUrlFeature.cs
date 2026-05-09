using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UrlShortener.Core.Urls.Add;

namespace UrlShortener.tests
{
    public class AddUrlFeature : IClassFixture<ApiFixture>
    {
        private readonly HttpClient client;
        public AddUrlFeature(ApiFixture fixture)
        {
            client = fixture.CreateClient();
        }
        [Fact]
        public async Task Given_long_url_should_return_short_url()
        {
            var response = await client.PostAsJsonAsync("/api/urls",
                new AddUrlRequest(new Uri("https://youtube.com"), " "));
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var addUrlResponse = await response.Content.ReadFromJsonAsync<AddUrlResponse>();
            addUrlResponse!.Should().NotBeNull();

        }
    }
}