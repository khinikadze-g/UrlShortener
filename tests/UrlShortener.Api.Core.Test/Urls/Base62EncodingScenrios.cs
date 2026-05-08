using UrlShortener.Core;

namespace UrlShortener.Api.Core.Test.Urls
{
    public class Base62EncodingScenrios
    {
        [Theory]
        [InlineData(20, "K")]
        [InlineData(1, "1")]
        public void Should_Encode_Number_To_Base62(long number, string expected)
        {
            number.EncodeToBase62().
                Should().
                Be(expected);
        }
    }
}
