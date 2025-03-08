using Microsoft.EntityFrameworkCore;
using PerformanceAnalyzerApi.Models;
namespace PerformanceAnalyzerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PerformanceResult> PerformanceResults { get; set; }
    }
}