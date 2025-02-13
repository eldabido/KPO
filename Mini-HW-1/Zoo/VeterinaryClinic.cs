namespace Zoo
{
    // Класс VeterinaryClinic - класс, описывающий ветеринарную клинику, наследуется
    // от интерфейса IVeterinaryClinic, содержит метод проверки здоровья.
    public class VeterinaryClinic: IVeterinaryClinic
    {
        // Метод проверки здоровья.
        public bool CheckHealth(Animal animal)
        {
            // Так как в задании не указан конкретный метод проверки,
            // воспользуемся просто рандомом.
            var rand = new Random();
            if (rand.Next() % 2 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
