namespace ApiGateway.Infrastructure
{
  // DTO-models.
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
}