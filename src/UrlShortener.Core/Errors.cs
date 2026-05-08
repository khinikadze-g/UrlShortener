

namespace UrlShortener.Core
{
    public class Errors
    {
        public static Error MissingCreatedBy => new("Missing_value", "Created by is required");
    }
}
