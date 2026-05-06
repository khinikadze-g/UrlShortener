namespace UrlShortener.Core
{
    public class TokenProvider
    {
        private TokenRange? tokenRange;
        public void AssignRange(int start, int end)
        {
            this.tokenRange = new TokenRange(start, end);
        }
        public void AssignRange(TokenRange tokenRange)
        {
            this.tokenRange = tokenRange;
        }

        public long GetToken()
        {
            return tokenRange.Start;
        }
    }
}
