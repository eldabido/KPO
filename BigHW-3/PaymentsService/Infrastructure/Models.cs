// Аккаунт пользователя.
public class Account
{
  public string? UserId { get; set; }
  public decimal Balance { get; set; }
  public bool HasActiveOrder { get; set; }
}

// Заказ.
public class Order
{
  public string? OrderId { get; set; }
  public string? UserId { get; set; }
  public decimal Amount { get; set; }
  public bool IsPaid { get; set; }
  public bool IsProcessing { get; set; }
}

// DTO-модели.

public class CreateAccountRequest
{
  public string? UserId { get; set; }
}

public class TopUpRequest
{
  public string? UserId { get; set; }
  public decimal Amount { get; set; }
}

public class CreateOrderRequest
{
  public string? UserId { get; set; }
  public decimal Amount { get; set; }
}