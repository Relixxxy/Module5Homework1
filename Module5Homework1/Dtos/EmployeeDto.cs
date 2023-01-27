using Newtonsoft.Json;

namespace Module5Homework1.Dtos
{
    public class EmployeeDto
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Job { get; set; } = null!;
        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public string? UpdatedAt { get; set; }
    }
}
