using System;
using System.Collections.Generic;

namespace ComputerComponents
{
    public class Component
    {
        protected string Name { get; set; }
        public int Price { get; set; }

        public Component(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public virtual string GetInfo()
        {
            return $"Название: {Name}, Цена: {Price}";
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }

    public interface IInstallable
    {
        void Install();
    }

    public class CPU : Component, IInstallable
    {
        private int Speed { get; set; }
        private int MaxTemp { get; set; }

        public CPU(string name, int maxTemp, int speed, int price) : base(name, price)
        {
            MaxTemp = maxTemp;
            Speed = speed;
        }

        public void Install()
        {
            Console.WriteLine("Способ установки: в материнскую плату, в сокет");
        }

        public override string GetInfo()
        {
            return $"Название: {Name}, Скорость процессора: {Speed} MHz, Максимальная температура: {MaxTemp} C, Цена: {Price}";
        }
        public static bool operator ==(CPU cpu1, CPU cpu2)
        {
            return cpu1.Name == cpu2.Name &&
                   cpu1.Speed == cpu2.Speed &&
                   cpu1.MaxTemp == cpu2.MaxTemp;
        }

        public static bool operator !=(CPU cpu1, CPU cpu2)
        {
            return !(cpu1 == cpu2);
        }
    }

    public class RAM : Component, IInstallable
    {
        private int Speed { get; set; }
        private int Memory { get; set; }

        public RAM(string name, int memory, int speed, int price) : base(name, price)
        {
            Memory = memory;
            Speed = speed;
        }

        public void Install()
        {
            Console.WriteLine("Способ установки: в материнскую плату, разъёмы для оперативной памяти");
        }

        public override string GetInfo()
        {
            return $"Название: {Name}, Скорость оперативной памяти: {Speed} MHz, Объём оперативной памяти: {Memory} GB, Цена: {Price}";
        }
    }

    public class GPU : Component, IInstallable
    {
        private int Speed { get; set; }
        private int Memory { get; set; }

        public GPU(string name, int memory, int speed, int price) : base(name, price)
        {
            Memory = memory;
            Speed = speed;
        }

        public void Install()
        {
            Console.WriteLine("Способ установки: в материнскую плату, необходимый разъём для видеокарты");
        }

        public override string GetInfo()
        {
            return $"Название: {Name}, Скорость графического процессора: {Speed} MHz, Объём памяти графического процессора: {Memory} GB, Цена: {Price}";
        }
    }
    public class HDD : Component, IInstallable
    {
        private int SpeedRead { get; set; }
        private int SpeedWrite { get; set; }
        private int Memory { get; set; }

        public HDD(string name, int memory, int speedRead, int speedWrite, int price) : base(name, price)
        {
            Memory = memory;
            SpeedRead = speedRead;
            SpeedWrite = speedWrite;
        }

        public void Install()
        {
            Console.WriteLine("Способ установки: через провод, в материнскую плату");
        }

        public override string GetInfo()
        {
            return $"Название: {Name}, Объём памяти жёсткого диска: {Memory} GB, Скорость записи: {SpeedWrite} MB/s, Скорость чтения: {SpeedRead} MB/s, Цена: {Price}";
        }
    }

    public class Computer
    {
        List<Component> Components = new List<Component>();
        private int TotalPrice;

        public void AddComponent<T>(T component) where T : Component
        {
            Components.Add(component);
            Console.WriteLine($"Добавлен компонент({component.GetInfo()})");
            TotalPrice += component.Price;
        }

        public void RemoveComponent<T>(T component) where T : Component
        {
            Components.Remove(component);
            Console.WriteLine($"Убран компонент({component.GetInfo()})");
            TotalPrice -= component.Price;
        }

        public void GetTotalPrice()
        {
            Console.WriteLine($"Общая цена компьютера: {TotalPrice}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CPU cpu = new CPU("AMD Ryzen 7 5800X", 90, 3800, 21000);
            CPU cpu1 = new CPU("AMD Ryzen 7 5800X", 90, 3800, 21000);
            Console.WriteLine(cpu==cpu1);
            cpu.Install();
            Console.WriteLine(cpu.GetInfo());

            Console.WriteLine();

            RAM ram = new RAM("Corsair Vengeance LPX", 32, 3600, 8500);
            ram.Install();
            Console.WriteLine(ram.GetInfo());

            Console.WriteLine();

            GPU gpu = new GPU("NVIDIA RTX 4070", 12, 1920, 62000);
            gpu.Install();
            Console.WriteLine(gpu.GetInfo());

            Console.WriteLine();

            HDD hdd = new HDD("Western Digital Black", 2000, 210, 180, 7200);
            hdd.Install();
            Console.WriteLine(hdd.GetInfo());

            Console.WriteLine();

            Computer computer = new Computer();

            computer.AddComponent(cpu);
            computer.AddComponent(ram);
            computer.AddComponent(gpu);
            computer.AddComponent(hdd);

            computer.GetTotalPrice();
        }
    }
}