namespace Zoo
{
    // Класс ZooPark - содержит все основные методы для работы с системой.
    // Списки, добавление, количества - это сюда.
    public class ZooPark
    {
        // Поля и конструкторы.
        IVeterinaryClinic? _veterinaryClinic;
        List<Animal> _animals = new List<Animal>();
        List<Thing> _things = new List<Thing>();

        public ZooPark(IVeterinaryClinic veterinaryClinic)
        {
            _veterinaryClinic = veterinaryClinic;
        }

        // Метод для добавления животного в зоопарк.
        public void AddAnimal(Animal animal)
        {
            if (_veterinaryClinic!.CheckHealth(animal))
            {
                _animals.Add(animal);
                Console.WriteLine($"{animal.Name} здорово и поступило в зоопарк.");
            }
            else
            {
                Console.WriteLine($"{animal.Name} не здорово, поэтому не принято в зоопарк.");
            }
        }

        // Вывод списка животных и вещей.
        public void ListInventory()
        {
            Console.WriteLine("Список животных:");
            foreach (var animal in _animals)
            {
                Console.WriteLine($"{animal.Name}");
            }

            Console.WriteLine("Список вещей:");
            foreach (var thing in _things)
            {
                Console.WriteLine($"{thing.Name}, номер: {thing.Number}");
            }
        }

        // Метод добавления вещи.
        public void AddThing(Thing thing)
        {
            foreach(var thg in  _things)
            {
                if (thg.Number == thing.Number)
                {
                    Console.WriteLine($"Инвентаризационный номер занят, " +
                        $"поэтому вещь {thing.Name} не добавлена");
                    return;
                }
            }
            _things.Add(thing);
            Console.WriteLine($"Вещь {thing.Name} поступила в зоопарк.");
        }

        // Кол-во еды.
        public void NumberOfFood()
        {
            foreach (var animal in _animals)
            {
                Console.WriteLine($"Животное {animal.Name} потребляет {animal.Food} кг еды.");
            }
            int Food = _animals.Sum(a => a.Food);
            Console.WriteLine($"Суммарное кол-во еды: {Food} кг.");
        }

        // Кол-во животных.
        public void NumberOfAnimals()
        {
            Console.WriteLine($"Кол-во животных: {_animals.Count}.");
        }

        // Метод для вывода кандидатов в контактный зоопарк.
        public void ListContactZooCandidates()
        {
            Console.WriteLine("Животные, которые могут быть помещены в контактный зоопарк:");
            foreach (var animal in _animals)
            {
                if (animal.LevelOfKind > 5)
                Console.WriteLine(animal.Name);
            }
        }
    }
}
