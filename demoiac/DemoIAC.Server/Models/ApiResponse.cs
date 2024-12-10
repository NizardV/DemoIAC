using System.Text.Json.Serialization;

namespace DemoIAC.Server.Models
{
    public class ApiResponse
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("questions")]
        public List<Question>? Questions { get; set; }
    }


}
