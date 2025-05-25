using ResultLibrary;
using TextAnalysisService.Services;

var builder = WebApplication.CreateBuilder(args);
// Регистрация сервиса, создание Swagger
builder.Services.AddScoped<ITextAnalysisService, TextAnalysisService.Services.TextAnalysisService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Анализ текста.
app.MapPost("/api/analyze", async (ITextAnalysisService service, IFormFile file) =>
{
  using var reader = new StreamReader(file.OpenReadStream());
  var fileContent = await reader.ReadToEndAsync();
  // Если пустой.
  if (string.IsNullOrWhiteSpace(fileContent))
  {
    return Results.BadRequest("File is empty");
  }

  // Анализ.
  var result = service.AnalyzeText(fileContent);
  return Results.Ok(result);
}).DisableAntiforgery();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();