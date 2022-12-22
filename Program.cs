using System;
using System.Threading.Tasks;

class Program
{
    static public bool pc1 = true, pc2 = true, pc3 = true;
    static void Main(string[] args)
    {
        Console.WriteLine("Завдання 1");
        for (int i = 1; i < 5; i++)
        {
            Thread Car = new Thread(Parking);
            Car.Name = $"Car {i}";
            Car.Start();
        }
        Console.ReadKey();
    }
    static void Parking()
    {

        int k = 0;
        while (true)
        {
            Console.WriteLine("> Заїхала" + $" {Thread.CurrentThread.Name}");
            if (k == 5)
            {
                Console.WriteLine("Програма закiнчила роботу");
                break;
            }
            else if (pc1 == true)
            {
                pc1 = false;
                parkingSpace1();
            }
            else if (pc2 == true)
            {
                pc2 = false;
                parkingSpace2();
            }
            else if (pc3 == true)
            {
                pc3 = false;
                parkingSpace3();
            }
            else
            {
                Console.WriteLine("// Стоянка повна" + $" {Thread.CurrentThread.Name}" + " виїхала");
                Thread.Sleep(15000);
            }
            k++;
        }
    }

    static void parkingSpace1()
    {
        Console.WriteLine(">= 1 мiсце зайнятто" + $" {Thread.CurrentThread.Name}");
        Thread.Sleep(10000);
        Console.WriteLine("<= 1 мiсце вiльне" + $" {Thread.CurrentThread.Name}");
        pc1 = true;
        Console.WriteLine("< Виїхала" + $" {Thread.CurrentThread.Name}");
        Thread.Sleep(2000);
    }
    static void parkingSpace2()
    {
        Console.WriteLine(">= 2 мiсце зайнятто" + $" {Thread.CurrentThread.Name}");
        Thread.Sleep(10000);
        Console.WriteLine("<= 2 мiсце вiльне" + $" {Thread.CurrentThread.Name}");
        pc2 = true;
        Console.WriteLine("< Виїхала" + $" {Thread.CurrentThread.Name}");
        Thread.Sleep(2000);
    }
    static void parkingSpace3()
    {
        Console.WriteLine(">= 3 мiсце зайнятто" + $" {Thread.CurrentThread.Name}");
        Thread.Sleep(10000);
        Console.WriteLine("<= 3 мiсце вiльне" + $" {Thread.CurrentThread.Name}");
        pc3 = true;
        Console.WriteLine("< Виїхала" + $" {Thread.CurrentThread.Name}");
        Thread.Sleep(2000);
    }
}