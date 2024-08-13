namespace FrontEndLoginSignUp
{
    public static class TokenStore
    {
        private static readonly Dictionary<string, string> _tokens = new Dictionary<string, string>();

        public static void AddToken(string userId, string token)
        {
            _tokens[userId] = token;
        }

        public static string GetToken(string userId)
        {
            _tokens.TryGetValue(userId, out var token);
            return token;
        }

        public static void RemoveToken(string userId)
        {
            _tokens.Remove(userId);
        }
    }

}
