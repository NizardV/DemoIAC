using System.Text.Json.Serialization;


namespace DemoIAC.Server.Models
{
    

    public class Question
    {
        [JsonPropertyName("question")]
        public string? QuestionText { get; set; }

        [JsonPropertyName("answers")]
        public List<string>? Answers { get; set; }

        [JsonPropertyName("correct")]
        public string? CorrectAnswer { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("explanation")]
        public string? Explanation { get; set; }

        [JsonPropertyName("difficulty")]
        public string? Difficulty { get; set; }
    }

}
