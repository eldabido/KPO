using ResultLibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ��������� TextAnalysis ��� Http-�������.
builder.Services.AddHttpClient("TextAnalysis", client =>
{
  client.BaseAddress = new Uri(builder.Configuration["TextAnalysisServiceUrl"]!);
  client.Timeout = TimeSpan.FromSeconds(15);
});

var app = builder.Build();

// ������ ������.
app.MapPost("/analyze", async (IHttpClientFactory clientFactory, IFormFile file) =>
{
  // ��������� ���� �� txt-������.
  if (file.ContentType != "text/plain" || Path.GetExtension(file.FileName).ToLower() != ".txt")
  {
    return Results.BadRequest("Only .txt please");
  }
  // ������.
  var textAnalysis = clientFactory.CreateClient("TextAnalysis");
  using var content = new MultipartFormDataContent();
  content.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
  // �������� � ���������.
  var analysisResponse = await textAnalysis.PostAsync("/api/analyze", content);
  return !analysisResponse.IsSuccessStatusCode
      ? Results.Problem("error")
      : Results.Ok(await analysisResponse.Content.ReadFromJsonAsync<AnalysisResult>());
}).DisableAntiforgery();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();