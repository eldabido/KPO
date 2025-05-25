using ResultLibrary;
using TextAnalysisService.Services;

var builder = WebApplication.CreateBuilder(args);
// ����������� �������, �������� Swagger
builder.Services.AddScoped<ITextAnalysisService, TextAnalysisService.Services.TextAnalysisService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ������ ������.
app.MapPost("/api/analyze", async (ITextAnalysisService service, IFormFile file) =>
{
  using var reader = new StreamReader(file.OpenReadStream());
  var fileContent = await reader.ReadToEndAsync();
  // ���� ������.
  if (string.IsNullOrWhiteSpace(fileContent))
  {
    return Results.BadRequest("File is empty");
  }

  // ������.
  var result = service.AnalyzeText(fileContent);
  return Results.Ok(result);
}).DisableAntiforgery();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();