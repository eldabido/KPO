using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using OrdersService.Infrastructure;

// Регистрация сервисов.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderContext>(opt =>
    opt.UseInMemoryDatabase("OrdersDB"));

builder.Services.AddHostedService<OutboxProcessor>();
builder.Services.AddSingleton<IOutboxStore, InMemoryOutboxStore>();

builder.Services.AddHttpClient("PaymentsService", client =>
{
  client.BaseAddress = new Uri("http://payments-service/");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Endpoints.

app.MapPost("/api/orders", async (OrderContext db, IOutboxStore outbox, CreateOrderRequest request) =>
{
  var order = new Order
  {
    Id = Guid.NewGuid(),
    UserId = request.UserId,
    Amount = request.Amount,
    Status = "Created"
  };

  db.Orders.Add(order);

  outbox.Add(new OutboxMessage
  {
    Id = Guid.NewGuid(),
    EventType = "OrderCreated",
    Payload = System.Text.Json.JsonSerializer.Serialize(new
    {
      OrderId = order.Id,
      order.UserId,
      order.Amount
    }),
    CreatedAt = DateTime.UtcNow
  });

  await db.SaveChangesAsync();

  return Results.Created($"/api/orders/{order.Id}", order);
});

app.MapGet("/api/orders", async (OrderContext db) =>
    await db.Orders.ToListAsync());

app.MapGet("/api/orders/{id}", async (OrderContext db, Guid id) =>
    await db.Orders.FindAsync(id) is Order order
        ? Results.Ok(order)
        : Results.NotFound());

app.Run();




public record CreateOrderRequest(string UserId, decimal Amount);
public class Order
{
  public Guid Id { get; set; }
  public string? UserId { get; set; }
  public decimal Amount { get; set; }
  public string? Status { get; set; }
}

public class OrderContext : DbContext
{
  public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

  public DbSet<Order> Orders => Set<Order>();
}
