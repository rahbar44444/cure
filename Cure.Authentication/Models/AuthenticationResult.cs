namespace Cure.Authentication.Models
{
    public class AuthenticationResult : TokenModel
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
