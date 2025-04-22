namespace ZooManagement
{
  // Реализация Value Object в виде EnclosureType.
  public record EnclosureType
  {
    public static EnclosureType Predator = new("Predator");
    public static EnclosureType Herbivore = new("Herbivore");
    public static EnclosureType Aquarium = new("Aquarium");

    public string Value { get; set; }

    private EnclosureType(string value)
    {
      Value = value;
    }

    public static EnclosureType FromString(string value)
    {
      return value.ToLower() switch
      {
        "predator" => Predator,
        "herbivore" => Herbivore,
        "aquarium" => Aquarium,
        _ => throw new ArgumentException($"Invalid enclosure type: {value}")
      };
    }
  }
 }
