using System.Collections.Concurrent;

// Интерфейс сервиса оплаты.
public interface IPaymentService
{
  Task<Account> CreateAccount(string userId);
  Task<Account> TopUpAccount(string userId, decimal amount);
  Task<Order> CreateOrder(string userId, decimal amount);
  Task<Account> GetAccount(string userId);

  Task<PaymentResult> ProcessPayment(string orderId, string userId, decimal amount);
}


// Класс содержит информацию о результате оплаты.
public class PaymentResult
{
  public bool Success { get; set; } // Успешность операции.
  public string Message { get; set; } // Сообщение.
  public Account Account { get; set; } // Состояние аккаунта.

  public PaymentResult(bool success, string message, Account account = null)
  {
    Success = success;
    Message = message;
    Account = account;
  }
}
public class PaymentService : IPaymentService
{
  // Аккаунты пользователей.
  private static readonly ConcurrentDictionary<string, Account> _accounts = new();
  // Заказы.
  private static readonly ConcurrentDictionary<string, Order> _orders = new();
  // Для проверки повторных заказов.
  private static readonly ConcurrentDictionary<string, bool> _processedOrders = new();
  // Контролировать доступ. Для атомарности.
  private static readonly SemaphoreSlim _semaphore = new(1, 1);

  public async Task<Account> CreateAccount(string userId)
  {
    if (_accounts.ContainsKey(userId))
    {
      throw new Exception("Account already exists");
    }

    var account = new Account { UserId = userId, Balance = 0 };
    _accounts[userId] = account;
    return account;
  }

  public async Task<Account> TopUpAccount(string userId, decimal amount)
  {
    if (!_accounts.TryGetValue(userId, out var account))
    {
      throw new Exception("Account not found");
    }

    await _semaphore.WaitAsync(); // Для атомарности.
    try
    {
      account.Balance += amount;
      return account;
    }
    finally
    {
      _semaphore.Release();
    }
  }

  public async Task<Order> CreateOrder(string userId, decimal amount)
  {
    if (!_accounts.TryGetValue(userId, out var account))
    {
      throw new Exception("Account not found");
    }

    if (account.HasActiveOrder)
    {
      throw new Exception("User already has an active order");
    }

    var orderId = Guid.NewGuid().ToString();
    var order = new Order
    {
      OrderId = orderId,
      UserId = userId,
      Amount = amount,
      IsPaid = false,
      IsProcessing = true
    };

    _orders[orderId] = order;
    account.HasActiveOrder = true;

    _ = ProcessPaymentAsync(orderId);

    return order;
  }

  public async Task<PaymentResult> ProcessPayment(string orderId, string userId, decimal amount)
  {
    if (_processedOrders.ContainsKey(orderId))
    {
      return new PaymentResult(false, $"Order {orderId} was already processed");
    }

    if (!_accounts.TryGetValue(userId, out var account))
    {
      return new PaymentResult(false, "Account not found");
    }

    await _semaphore.WaitAsync();
    try
    {
      if (account.Balance < amount)
      {
        return new PaymentResult(false, "Insufficient funds", account);
      }

      account.Balance -= amount;
      _processedOrders[orderId] = true;

      return new PaymentResult(true, "Payment processed successfully", account);
    }
    finally
    {
      _semaphore.Release();
    }
  }

  private async Task ProcessPaymentAsync(string orderId)
  {
    await Task.Delay(2000);

    if (_orders.TryGetValue(orderId, out var order) &&
        _accounts.TryGetValue(order.UserId!, out var account))
    {
      var result = await ProcessPayment(orderId, order.UserId!, order.Amount);

      await _semaphore.WaitAsync();
      try
      {
        order.IsPaid = result.Success;
        order.IsProcessing = false;
        account.HasActiveOrder = false;
      }
      finally
      {
        _semaphore.Release();
      }
    }
  }

  public async Task<Account> GetAccount(string userId)
  {
    if (_accounts.TryGetValue(userId, out var account))
    {
      return account;
    }
    throw new Exception("Account not found");
  }
}