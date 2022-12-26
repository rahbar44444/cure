using Newtonsoft.Json;

namespace Cure.Authentication.Models
{
    public class TokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

    }
}
