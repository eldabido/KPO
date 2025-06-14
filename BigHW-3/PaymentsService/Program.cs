using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPaymentService, PaymentService>();

var app = builder.Build();

// Endpoints.
// Создание аккаунта.
app.MapPost("/api/payments/accounts", async (IPaymentService service, [FromBody] CreateAccountRequest request) =>
{
  try
  {
    var account = await service.CreateAccount(request.UserId!);
    return Results.Ok(account);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// Пополнение баланса.
app.MapPost("/api/payments/topup", async (IPaymentService service, [FromBody] TopUpRequest request) =>
{
  try
  {
    var account = await service.TopUpAccount(request.UserId!, request.Amount);
    return Results.Ok(account);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// Создание заказа.
app.MapPost("/api/payments/orders", async (IPaymentService service, [FromBody] CreateOrderRequest request) =>
{
  try
  {
    var order = await service.CreateOrder(request.UserId!, request.Amount);
    return Results.Ok(order);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// Получение данных о пользователе.
app.MapGet("/api/payments/accounts/{userId}", async (IPaymentService service, string userId) =>
{
  try
  {
    var account = await service.GetAccount(userId);
    return Results.Ok(account);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// Обработка платежа по заказу.
app.MapPost("/api/payments/process-order", async (IPaymentService service, [FromBody] ProcessOrderRequest request) =>
{
  try
  {
    var result = await service.ProcessPayment(request.OrderId, request.UserId, request.Amount);
    return Results.Ok(result);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

public record ProcessOrderRequest(string OrderId, string UserId, decimal Amount);