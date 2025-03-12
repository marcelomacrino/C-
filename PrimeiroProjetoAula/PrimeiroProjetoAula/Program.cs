using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool casado = true;
            char genero = 'F';
            char letra = '\u0041'; // Unicode
            byte n1 = 126;
            int n2 = 1000;
            int n3 = 2147483647;
            long n4 = 2147483647L;
            float n5 = 4.5f;
            double n6 = 4.5;
            string nome = "Marcelo";
            object obj1 = "Alex Triade";
            object obj2 = 4.5f;
            n1++;

            int n10 = int.MinValue;
            int n11 = int.MaxValue;
            decimal d1 = decimal.MaxValue;

            Console.WriteLine(casado);
            Console.WriteLine(genero);
            Console.WriteLine(letra);
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(n5);
            Console.WriteLine(n6);
            Console.WriteLine(nome);
            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
            Console.WriteLine(n10);
            Console.WriteLine(n11);
            Console.WriteLine(d1);
        }
    }
}