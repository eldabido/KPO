namespace ZooManagement
{
    // Реализация Value Object в виде FoodType.
    public class FoodType
    {
        public static FoodType Meat = new("Meat");
        public static FoodType Vegetables = new("Vegetables");
        public static FoodType Fish = new("Fish");

        public string Value { get; set; }

        private FoodType(string value) => Value = value;

        public static FoodType FromString(string type)
        {
            return type.ToLower() switch
            {
                "meat" => Meat,
                "vegetables" => Vegetables,
                "fish" => Fish,
                _ => throw new Exception("Invalid food type")
            };
        }

        public static bool IsCompatible(AnimalType animalType, FoodType foodType)
        {
            if (animalType.Value == "Predator" &&  foodType.Value == "Meat") {
              return true;
            } else if (animalType.Value == "Herbivore" && foodType.Value == "Vegetables") {
              return true;
            } else if (animalType.Value == "Aquatic" && foodType.Value == "Fish") {
              return true;
            } else {
              return false;
            }
        }
    }
}
