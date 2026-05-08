namespace UrlShortener.Core.Urls.Add
{
    public class AddUrlHandler
    {
        private readonly ShortUrlGenerator shortUrlGenerator;
        private readonly IUrlDataStore urlDataStore;
        private readonly TimeProvider timeProvider;

        public AddUrlHandler(ShortUrlGenerator shortUrlGenerator, IUrlDataStore urlDataStore, TimeProvider timeProvider)
        {
            this.shortUrlGenerator = shortUrlGenerator;
            this.urlDataStore = urlDataStore;
            this.timeProvider = timeProvider;
        }

        public async Task<Result<AddUrlResponse>> HandleAsync(AddUrlRequest request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.CreatedBy))
            {
                return Errors.MissingCreatedBy;
            }
            var shortened = new ShortenedUrl(request.longUrl,
                shortUrlGenerator.GenerateUniqueUrl(), request.CreatedBy, timeProvider.GetUtcNow());
       
            await urlDataStore.AddAsync(shortened, cancellationToken);
            return new AddUrlResponse(request.longUrl, shortened.ShortUrl);
        }
    }
}
