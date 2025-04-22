namespace ZooManagement
{
    // ZooStatistics - класс для статистики.
    public class ZooStatistics
    {
        public int TotalAnimals { get; set; }
        public int TotalEnclosures { get; set; }
        public int FreeEnclosures { get; set; }
        public Dictionary<string, int>? AnimalsByType { get; set; }
    }
}
