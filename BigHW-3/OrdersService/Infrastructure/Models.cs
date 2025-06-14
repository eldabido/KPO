namespace OrdersService.Infrastructure;
public class OutboxMessage
{
  public Guid Id { get; set; }               // Идентификатор.
  public string? EventType { get; set; }     // Тип события.
  public string? Payload { get; set; }       // Данные.
  public DateTime CreatedAt { get; set; }    // Время создания.
  public DateTime? ProcessedAt { get; set; } // Время обработки.
}

public interface IOutboxStore
{
  void Add(OutboxMessage message);                      // Добавление сообщения.
  IEnumerable<OutboxMessage> GetUnprocessed();          // Получаем необработанные сообщения.
  void MarkAsProcessed(Guid id);                        // Метка, что обработали.
}

// Хранилище.
public class InMemoryOutboxStore : IOutboxStore
{
  private readonly List<OutboxMessage> _messages = new();

  public void Add(OutboxMessage message) => _messages.Add(message);

  public IEnumerable<OutboxMessage> GetUnprocessed() =>
      _messages.Where(m => m.ProcessedAt == null);

  public void MarkAsProcessed(Guid id) =>
      _messages.First(m => m.Id == id).ProcessedAt = DateTime.UtcNow;
}

public class OutboxProcessor : BackgroundService
{
  private readonly IOutboxStore _outbox;
  private readonly IHttpClientFactory _httpClientFactory;
  private readonly ILogger<OutboxProcessor> _logger;

  public OutboxProcessor(
      IOutboxStore outbox,
      IHttpClientFactory httpClientFactory,
      ILogger<OutboxProcessor> logger)
  {
    _outbox = outbox;
    _httpClientFactory = httpClientFactory;
    _logger = logger;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      try
      {
        var client = _httpClientFactory.CreateClient("PaymentsService");

        foreach (var message in _outbox.GetUnprocessed())
        {
          var response = await client.PostAsJsonAsync(
              "api/payments/process-order",
              message.Payload);

          if (response.IsSuccessStatusCode)
          {
            _outbox.MarkAsProcessed(message.Id);
            _logger.LogInformation($"Processed message {message.Id}");
          }
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error processing outbox");
      }

      await Task.Delay(5000, stoppingToken);
    }
  }
}