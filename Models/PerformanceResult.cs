namespace PerformanceAnalyzerApi.Models
{
    public class PerformanceResult
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public double LoadTime { get; set; } // Seconds
        public int ResourceCount { get; set; }
        public long TotalSize { get; set; } // Bytes
        public DateTime AnalyzedAt { get; set; } = DateTime.UtcNow;
    }
}