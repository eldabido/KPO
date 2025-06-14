using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("PaymentsService", client =>
{
  client.BaseAddress = new Uri("http://payments-service/");
  client.Timeout = TimeSpan.FromSeconds(15);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Endpoints.
app.MapPost("/api/accounts", async (IHttpClientFactory clientFactory, [FromBody] CreateAccountRequest request) =>
{
  var client = clientFactory.CreateClient("PaymentsService");
  var response = await client.PostAsJsonAsync("api/payments/accounts", request);
  return await HandleResponse(response);
});

app.MapPost("/api/topup", async (IHttpClientFactory clientFactory, [FromBody] TopUpRequest request) =>
{
  var client = clientFactory.CreateClient("PaymentsService");
  var response = await client.PostAsJsonAsync("api/payments/topup", request);
  return await HandleResponse(response);
});

app.MapPost("/api/orders", async (IHttpClientFactory clientFactory, [FromBody] CreateOrderRequest request) =>
{
  var client = clientFactory.CreateClient("PaymentsService");
  var response = await client.PostAsJsonAsync("api/payments/orders", request);
  return await HandleResponse(response);
});

app.MapGet("/api/accounts/{userId}", async (IHttpClientFactory clientFactory, string userId) =>
{
  var client = clientFactory.CreateClient("PaymentsService");
  var response = await client.GetAsync($"api/payments/accounts/{userId}");
  return await HandleResponse(response);
});

async Task<IResult> HandleResponse(HttpResponseMessage response)
{
  if (response.IsSuccessStatusCode)
  {
    var content = await response.Content.ReadAsStringAsync();
    return Results.Ok(content);
  }
  return Results.StatusCode((int)response.StatusCode);
}

app.Run();

public record CreateAccountRequest(string UserId);
public record TopUpRequest(string UserId, decimal Amount);
public record CreateOrderRequest(string UserId, decimal Amount);