using System.Text.Json.Serialization;

namespace Tgs.GameInterface.AwcService.Repositories.Models
{
    public record GameRecord
    {
        [JsonPropertyName("result")]
        public string[] Result { get; set; } = default!;
        [JsonPropertyName("roundStartTime")]
        public string RoundStartTime { get; set; } = default!;
        [JsonPropertyName("winner")]
        public string Winner { get; set; } = default!;
        [JsonPropertyName("ip")]
        public string Ip { get; set; } = default!;
        [JsonPropertyName("odds")]
        public decimal Odds { get; set; } = default!;
        [JsonPropertyName("tableId")]
        public int TableId { get; set; } = default!;
        [JsonPropertyName("dealerDomain")]
        public string DealerDomain { get; set; } = default!;
        [JsonPropertyName("winLoss")]
        public decimal WinLoss { get; set; } = default!;
        [JsonPropertyName("status")]
        public string Status { get; set; } = default!;
    }
}
