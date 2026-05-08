using UrlShortener.Core;

namespace UrlShortener.Core.Urls.Add
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
