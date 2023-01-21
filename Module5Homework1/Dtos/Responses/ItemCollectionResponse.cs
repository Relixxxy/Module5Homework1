using Newtonsoft.Json;

namespace Module5Homework1.Dtos.Responses
{
    public class ItemCollectionResponse<TItem>
        where TItem : class
    {
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("data")]
        public IEnumerable<TItem> Items { get; set; } = null!;
        public SupportInfo Support { get; set; } = null!;
    }
}
