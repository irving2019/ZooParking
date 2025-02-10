/*
 * ���������� ����� �������� (���, ������� �������, ����������� �������� ����, ������ � ����)
 * ��������� ���������� ��������� (����������� ������ ���� �������� � ��������, ��������� �� ������) 
 * �������� ������ ���� �������� 
 * ����� �� ���������� 
 * 
 * ����������� ��������� IAnimal
 * ������� ������� ����� Animal
 * ����������� ������������ ��� ���������� ����� ��������
 * ������� �������� � List<IAnimal>
 * 
 * ��������� ������������ ����� ������������
 * ������������ ������ ������� ��������
 * ��������� ������� ��� ������ ������ ���������
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
            Console.WriteLine("�������!!!");
        }

        public override void Eat()
        {
            Energy += 20;
            Console.WriteLine($"{Name} ���� � ����������� 20 �������!");

        }

        public override void Gaming()
        {
            Energy -= 20;
            Console.WriteLine($"{Name} ������� � ����� �� 20 �������!");
        }
    }

    public class Herbivore : Animal
    {
        public Herbivore(string name) : base(name, 100) { }

        public override void MakeSound()
        {
            Console.WriteLine("*����� ���-��*");
        }

        public override void Eat()
        {
            Energy += 15;
            Console.WriteLine($"{Name} ���� � ����������� 15 �������!");
        }

        public override void Gaming()
        {
            Energy -= 20;
            Console.WriteLine($"{Name} ������� � ����� �� 20 �������!");
        }
    }

    class Park
    {
        static List<IAnimal> animals = new List<IAnimal>();


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("�������� ��������: \n");
                Console.WriteLine("1. �������� ����� ��������");
                Console.WriteLine("2. ������� ��������");
                Console.WriteLine("3. ����������� ������ ��������");
                Console.WriteLine("4. �������� � ��������");
                Console.WriteLine("5. ������� ���������\n");

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
                        Console.WriteLine("�� ���������� ����, ���������� �����\n");
                        break;
                }


            }
        }

        static void AddAnimal()
        {
            Console.WriteLine("������� ��� ���������: ");
            string name = Console.ReadLine();
            Console.WriteLine("�������� ��� ��������� (1 - ������, 2 - ����������):\n");
            string type = Console.ReadLine();

            IAnimal animal = type switch
            {
                "1" => new Predator(name + " ������"),
                "2" => new Herbivore(name + " ����������"),
                _ => null
            };


            if (animal != null)
            {
                animals.Add(animal);
                Console.WriteLine($"{animal.Name}  �������� � �������!\n");
            }
            else
            {
                Console.WriteLine("������������ ���� ���� ���������\n");
            }
        }

        static void FeedAnimal()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("������� ����! �������� ��������!\n");
                return;
            }
            ViewAnimals();

            Console.WriteLine("������� ����� ���������, ������� ������ ���������:\n");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= animals.Count)
            {
                animals[index - 1].Eat();
            }
            else
            {
                Console.WriteLine("�� ���������� ����� ���������!\n");
            }
        }

        static void ViewAnimals()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("������� ����!\n");
                return;
            }

            Console.WriteLine("������ �������� � ��������: \n");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{animals[i].Name} (�������: {animals[i].Energy})\n");
            }
        }

        static void Gaming()
        {
            if(animals.Count == 0)
            {
                Console.WriteLine("������� ����!\n");
                return;
            }

            Console.WriteLine("�������� �������� � ������� ������ ��������: \n");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{animals[i].Name} (�������: {animals[i].Energy})\n");
            }
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= animals.Count)
            {
                animals[index - 1].Gaming();
            }
            else
            {
                Console.WriteLine("�� ���������� ����� ���������!\n");
            }

        }
    }



}