using Newtonsoft.Json;

namespace Module5Homework1.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = null!;
        [JsonProperty("last_name")]
        public string LastName { get; set; } = null!;
        [JsonProperty("avatar")]
        public string AvatarUrl { get; set; } = null!;
    }
}
