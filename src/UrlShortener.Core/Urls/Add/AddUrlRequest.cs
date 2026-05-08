namespace UrlShortener.Core.Urls.Add
{
    public record AddUrlRequest(Uri longUrl, string CreatedBy);
}
