using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceAnalyzerApi.Data;
using PerformanceAnalyzerApi.Models;
using System.Diagnostics;

namespace PerformanceAnalyzerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public PerformanceController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("analyze")]
        public async Task<ActionResult<PerformanceResult>> AnalyzeWebsite([FromBody] string url)
        {
            var client = _httpClientFactory.CreateClient();
            var stopwatch = Stopwatch.StartNew();
            var response = await client.GetAsync(url);
            stopwatch.Stop();

            var result = new PerformanceResult
            {
                Url = url,
                LoadTime = stopwatch.Elapsed.TotalSeconds,
                ResourceCount = 1, // Simplified; expand with real analysis
                TotalSize = response.Content.Headers.ContentLength ?? 0
            };

            _context.PerformanceResults.Add(result);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetResults), new { id = result.Id }, result);
        }

        [HttpGet]
        [ResponseCache(Duration = 300)]
        public async Task<ActionResult<IEnumerable<PerformanceResult>>> GetResults()
        {
            return await _context.PerformanceResults.ToListAsync();
        }
    }
}