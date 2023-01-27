using Newtonsoft.Json;

namespace Module5Homework1.Dtos.Requests
{
    public class AuthRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; } = null!;
        [JsonProperty("password")]
        public string Password { get; set; } = null!;
    }
}
