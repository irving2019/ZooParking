/*
 * Добавление новых животных (Имя, уровень энергии, Способность издавать звук, играть и есть)
 * Кормление выбранного животного (отображение списка всех животных с номерами, обращение по номеру) 
 * Просмотр списка всех животных 
 * Выход из приложения 
 * 
 * Реализовать Интерфейс IAnimal
 * Создать базовый класс Animal
 * Реализовать наследование для конкретных видов животных
 * Хранить животных в List<IAnimal>
 * 
 * Проверять корректность ввода пользователя
 * Обрабатывать случай пустого зоопарка
 * Проверять границы при выборе номера животного
 */

using System;
using System.Collections.Generic;

namespace ZooPark
{

    public interface IAnimal
    {

        string Name { get; }

        int Energy { get; set; }

        void MakeSound();

        void Eat();

        void Gaming(); 

    }

    public abstract class Animal : IAnimal
    {
        public string Name { get; private set; }

        public int Energy { get; set; }

        protected Animal(string name, int energy)
        {
            Name = name;
            Energy = energy;
        }

        public abstract void MakeSound();

        public abstract void Eat();

        public abstract void Gaming();

    }

    public class Predator : Animal
    {
        public Predator(string name) : base(name, 100) { }

        public override void MakeSound()
        {
            Console.WriteLine("Ррррррр!!!");
        }

        public override void Eat()
        {
            Energy += 20;
            Console.WriteLine($"{Name} поел и восстановил 20 энергии!");

        }

        public override void Gaming()
        {
            Energy -= 20;
            Console.WriteLine($"{Name} поиграл и устал на 20 энергии!");
        }
    }

    public class Herbivore : Animal
    {
        public Herbivore(string name) : base(name, 100) { }

        public override void MakeSound()
        {
            Console.WriteLine("*Мычит что-то*");
        }

        public override void Eat()
        {
            Energy += 15;
            Console.WriteLine($"{Name} поел и восстановил 15 энергии!");
        }

        public override void Gaming()
        {
            Energy -= 20;
            Console.WriteLine($"{Name} поиграл и устал на 20 энергии!");
        }
    }

    class Park
    {
        static List<IAnimal> animals = new List<IAnimal>();


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие: \n");
                Console.WriteLine("1. Добавить новое животное");
                Console.WriteLine("2. Кормить животное");
                Console.WriteLine("3. Просмотреть список животных");
                Console.WriteLine("4. Поиграть с животным");
                Console.WriteLine("5. Закрыть программу\n");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAnimal();
                        break;

                    case "2":
                        FeedAnimal();
                        break;

                    case "3":
                        ViewAnimals();
                        break;

                    case "4":
                        Gaming();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Не корректный ввод, попробуйте снова\n");
                        break;
                }


            }
        }

        static void AddAnimal()
        {
            Console.WriteLine("Введите имя животного: ");
            string name = Console.ReadLine();
            Console.WriteLine("Выберите тип животного (1 - Хищник, 2 - Травоядное):\n");
            string type = Console.ReadLine();

            IAnimal animal = type switch
            {
                "1" => new Predator(name + " Хищник"),
                "2" => new Herbivore(name + " Травоядное"),
                _ => null
            };


            if (animal != null)
            {
                animals.Add(animal);
                Console.WriteLine($"{animal.Name}  добавлен в зоопарк!\n");
            }
            else
            {
                Console.WriteLine("Некорректный ввод типа животного\n");
            }
        }

        static void FeedAnimal()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("Зоопарк пуст! Добавьте животных!\n");
                return;
            }
            ViewAnimals();

            Console.WriteLine("Введите номер животного, которое хотите покормить:\n");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= animals.Count)
            {
                animals[index - 1].Eat();
            }
            else
            {
                Console.WriteLine("Не корректный номер животного!\n");
            }
        }

        static void ViewAnimals()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("Зоопарк пуст!\n");
                return;
            }

            Console.WriteLine("Список животных в зоопарке: \n");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{animals[i].Name} (Энергия: {animals[i].Energy})\n");
            }
        }

        static void Gaming()
        {
            if(animals.Count == 0)
            {
                Console.WriteLine("Зоопарк пуст!\n");
                return;
            }

            Console.WriteLine("Выберите животное с которым хотите поиграть: \n");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{animals[i].Name} (Энергия: {animals[i].Energy})\n");
            }
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= animals.Count)
            {
                animals[index - 1].Gaming();
            }
            else
            {
                Console.WriteLine("Не корректный номер животного!\n");
            }

        }
    }



}