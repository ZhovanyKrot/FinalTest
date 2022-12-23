
using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;

class Program
{
    static object loker = new object();
    static object loker1 = new object();
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
        Thread.Sleep(85000);
        Console.WriteLine("Завдання 2");
        for (int i = 1; i < 4; i++)
        {
            Thread SumTh = new Thread(FileReader);
            SumTh.Name = $"Potok {i}";
            SumTh.Start();
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

    static void FileReader()
    {

        int sum = 0;
        string fileIn_1 = @"D:\Git_Hub\FinalTest\in_1.txt";
        string[] f1arr = File.ReadAllText(fileIn_1).Split(" ");
        sum += Callculator(f1arr);
        Console.WriteLine($"{Thread.CurrentThread.Name} " + "Sum out = " + sum);
        string fileIn_2 = @"D:\Git_Hub\FinalTest\in_2.txt";
        string[] f2arr = File.ReadAllText(fileIn_2).Split(" ");
        sum += Callculator(f2arr);
        Console.WriteLine($"{Thread.CurrentThread.Name} " + "Sum out = " + sum);
        string fileIn_3 = @"D:\Git_Hub\FinalTest\in_3.txt";
        string[] f3arr = File.ReadAllText(fileIn_3).Split(" ");
        sum += Callculator(f3arr);
        Console.WriteLine($"{Thread.CurrentThread.Name} " + "Sum out = " + sum);
        string fileIn_4 = @"D:\Git_Hub\FinalTest\in_4.txt";
        string[] f4arr = File.ReadAllText(fileIn_4).Split(" ");
        sum += Callculator(f4arr);
        Console.WriteLine($"{Thread.CurrentThread.Name} " + "Sum out = " + sum);
        WhileText(sum);
    }
    static void WhileText(int sum)
    {
        lock (loker1)
        {
            string path = @"D:\Git_Hub\FinalTest\out.txt";
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                string text = sum.ToString();
                byte[] input = Encoding.Default.GetBytes(text);
                fstream.Write(input, 0, input.Length);
                Console.WriteLine($"{Thread.CurrentThread.Name} " + "Текст записан в файл out.txt");
            }
        }
    }
    static int Callculator(string[] farr)
    {
        lock (loker)
        {
            int sumcall = 0;
            int arg1 = Int32.Parse(farr[1]);
            int arg2 = Int32.Parse(farr[2]);
            if ("+" == farr[0])
            {
                sumcall += arg1 + arg2;
                Console.WriteLine($"{Thread.CurrentThread.Name} " + "Operator = + " + "Sum = " + sumcall);
            }
            else if ("-" == farr[0])
            {
                sumcall += arg1 - arg2;
                Console.WriteLine($"{Thread.CurrentThread.Name} " + "Operator = - " + "Sum = " + sumcall);
            }
            else if ("*" == farr[0])
            {
                sumcall += arg1 * arg2;
                Console.WriteLine($"{Thread.CurrentThread.Name} " + "Operator = * " + "Sum = " + sumcall);
            }
            else if ("/" == farr[0])
            {
                sumcall += arg1 / arg2;
                Console.WriteLine($"{Thread.CurrentThread.Name} " + "Operator = / " + "Sum = " + sumcall);
            }
            return sumcall;
        }
    }
}