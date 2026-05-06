



using UrlShortener.Core;

namespace UrlShortener.Api.Core.Test
{
    public class ShortUrlGenerator
    {
        private readonly TokenProvider tokenProvider;

        public ShortUrlGenerator(TokenProvider tokenProvider)
        {
            this.tokenProvider = tokenProvider;
        }
        public string GenerateUniqueUrl()
        {
            return tokenProvider
                .GetToken()
                .EncodeToBase62();
        }
    }
}
