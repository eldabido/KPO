namespace ZooManagement
{
  // Реализация Value Object в виде AnimalType.
  public record AnimalType
  {
    public string Value { get; }

    public AnimalType(string value)
    {
      Value = value;
    }
  }
}
