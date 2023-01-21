using Newtonsoft.Json;

namespace Module5Homework1.Dtos.Responses
{
    public class ItemResponse<TItem>
        where TItem : class
    {
        [JsonProperty("data")]
        public TItem Item { get; set; } = null!;
        public SupportInfo Support { get; set; } = null!;
    }
}
