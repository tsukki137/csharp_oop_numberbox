using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace CSharpOopNumberBox
{
 
    class NumberBox
    {
        private int[] numbers; 
 
 
        public NumberBox(int n)
        {
            numbers = new int[n];
            Random rnd = new Random();
 
            for (int i = 0; i < n; i++)
            {
                int square = (i + 1) * (i + 1);
                if (rnd.Next(2) == 0)         
                    square = -square;
                numbers[i] = square;
            }
        }
 
 
        public int PositiveCount
        {
            get
            {
                int count = 0;
                foreach (int num in numbers)
                    if (num > 0) count++;
                return count;
            }
        }
 
        public void ShowNumbers()
        {
            Console.Write("Массив: ");
            foreach (int num in numbers)
                Console.Write(num + " ");
            Console.WriteLine();
        }
 
 
        public int SumBetweenNegatives()
        {
            int firstIndex = -1, lastIndex = -1;
 
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] < 0)
                {
                    firstIndex = i;
                    break;
                }
 
            for (int i = numbers.Length - 1; i >= 0; i--)
                if (numbers[i] < 0)
                {
                    lastIndex = i;
                    break;
                }
 
            if (firstIndex == -1 || lastIndex == -1 || firstIndex == lastIndex)
                return 0;
 
            int sum = 0;
            for (int i = firstIndex + 1; i < lastIndex; i++)
                sum += numbers[i];
 
            return sum;
        }
    }
 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация класса NumberBox ===\n");
 
            Console.WriteLine("Пример 1: Создаем массив из 8 элементов");
            NumberBox box1 = new NumberBox(8);
            box1.ShowNumbers();
            Console.WriteLine($"Количество положительных: {box1.PositiveCount}");
            Console.WriteLine($"Сумма между отрицательными: {box1.SumBetweenNegatives()}");
 
            Console.WriteLine("\n" + new string('-', 50) + "\n");
 
            Console.WriteLine("Пример 2: Создаем массив из 5 элементов");
            NumberBox box2 = new NumberBox(5);
            box2.ShowNumbers();
            Console.WriteLine($"Количество положительных: {box2.PositiveCount}");
            Console.WriteLine($"Сумма между отрицательными: {box2.SumBetweenNegatives()}");
 
            Console.WriteLine("\n" + new string('-', 50) + "\n");
 
            Console.WriteLine("Пример 3: Массив из 3 элементов");
            NumberBox box3 = new NumberBox(3);
            box3.ShowNumbers();
            Console.WriteLine($"Количество положительных: {box3.PositiveCount}");
            Console.WriteLine($"Сумма между отрицательными: {box3.SumBetweenNegatives()}");
 
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}