using System;

namespace PlantExample
{
    public class Plant
    {
        protected string Name { get; set; }
        protected string Type { get; set; }
        protected int Size { get; set; }
        protected Plant(string name, string type, int size)
        {
            Name = name;
            Type = type;
            Size = size;
        }

        public virtual void Bloom()
        {
            Console.WriteLine("Растение цветёт");
        }

        public void IncreaseSize(int size)
        {
            Size += size;
            Console.WriteLine($"Растение выросло на {size}. Итоговая высота растения: {Size}");
        }
    }

    public class Flower : Plant
    {
        private string Color { get; set; }
        private int CountOfPetals { get; set; }

        public Flower(string name, string type, int size, string color, int countOfPetals)
            : base(name, type, size)
        {
            Color = color;
            CountOfPetals = countOfPetals;
        }

        public override void Bloom()
        {
            Console.WriteLine($"Цветок {Name} распустил лепестки");
        }

        public void Withering()
        {
            Console.WriteLine("Цветок увядает");
        }
    }

    public class Tree : Plant
    {
        private int Age { get; set; }
        private string LeafType { get; set; }

        public Tree(string name, string type, int size, string leafType, int age)
            : base(name, type, size)
        {
            Age = age;
            LeafType = leafType;
        }

        public override void Bloom()
        {
            Console.WriteLine($"Дерево {Name} Цветет");
        }

        public void Grow(int age)
        {
            Age += age;
            Console.WriteLine($"Дерево постарело, его возраст сейчас: {Age}");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            // Демонстрация использования
            Flower flower = new Flower("Орхидея", "Лепестковые", 23, "розовый", 5);
            flower.Bloom();
            flower.Withering();
            flower.IncreaseSize(2);

            Console.WriteLine();

            Tree tree = new Tree("Береза", "деревообразные", 710, "Черешковые", 12);
            tree.Bloom();
            tree.Grow(1);
            tree.IncreaseSize(21);
        }
    }
}
//Цветок Орхидея распустил лепестки
//Цветок увядает
//Растение выросло на 2. Итоговая высота растения: 25

//Дерево Береза Цветет
//Дерево постарело, его возраст сейчас: 13
//Растение выросло на 21. Итоговая высота растения: 731