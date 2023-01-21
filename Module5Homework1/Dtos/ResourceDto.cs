using Newtonsoft.Json;

namespace Module5Homework1.Dtos
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public string Color { get; set; } = null!;
        [JsonProperty("pantone_value")]
        public string PantoneValue { get; set; } = null!;
    }
}
