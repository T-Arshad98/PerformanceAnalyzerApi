using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<PerformanceAnalyzerApi.Data.AppDbContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("tm_db_con_str");
    options.UseSqlServer(connString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFirebase", builder => builder.WithOrigins("https://performance-analyzer--performanceanalyzer-be32e.us-central1.hosted.app").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFirebase");
app.UseAuthorization();
app.MapControllers();


app.Run();
