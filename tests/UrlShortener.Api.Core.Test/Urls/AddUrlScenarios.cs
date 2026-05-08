using Microsoft.Extensions.Time.Testing;
using UrlShortener.Api.Core.Test.TestDoubles;
using UrlShortener.Core;
using UrlShortener.Core.Urls.Add;

namespace UrlShortener.Api.Core.Test.Urls
{
    public class AddUrlScenarios
    {
        private readonly AddUrlHandler handler;
        private readonly InMemoryUrlDataStore urlDataStore;
        private readonly TimeProvider timeProvider;

        public AddUrlScenarios()
        {
            urlDataStore = new InMemoryUrlDataStore();
            var tokenProvider = new TokenProvider();
            tokenProvider.AssignRange(1, 5);
            var shortUrlGenerator = new ShortUrlGenerator(tokenProvider);
            timeProvider = new FakeTimeProvider();
            handler = new AddUrlHandler(shortUrlGenerator, urlDataStore, timeProvider);
        }

        [Fact]
        public async Task Should_return_shortened_url()
        {
            var request = CreateAddUrlRequest();
            var response = await handler.HandleAsync(request, default);
            response.Value.ShortUrl.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Should_save_short_url()
        {
            var request = CreateAddUrlRequest();
            var response = await handler.HandleAsync(request, default);
            urlDataStore.Should().ContainKey(response.Value.ShortUrl);
        }

        [Fact]
        public async Task Should_save_short_url_with_created_by_and_on()
        {
            var request = CreateAddUrlRequest();
            var response = await handler.HandleAsync(request, default);
            
            response.Succeeded.Should().BeTrue();
            urlDataStore.Should().ContainKey(response.Value.ShortUrl);
            urlDataStore[response.Value.ShortUrl].CreatedBy.Should().Be(request.CreatedBy);
            urlDataStore[response.Value.ShortUrl].CreatedOn.Should().Be(timeProvider.GetUtcNow());
        }

        [Fact]
        public async Task Should_return_error_if_created_by_is_empty()
        {
            var request = CreateAddUrlRequest(createdBy: string.Empty);
            var response = await handler.HandleAsync(request, default);

            response.Succeeded.Should().BeFalse();
            response.Error.Code.Should().Be("Missing_value");
        }

        private static AddUrlRequest CreateAddUrlRequest(string createdBy = "khinikadzegiga@gmail.com")
        {
            return new AddUrlRequest(new Uri("https://youtube.com"),
                createdBy);
        }
    }

}
