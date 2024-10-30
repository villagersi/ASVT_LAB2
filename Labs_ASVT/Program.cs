using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_ASVT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем массив с 1 миллионом элементов
            int[] numbers = Enumerable.Range(1, 1000000).ToArray();

            // Определяем количество задач (потоков)
            int numberOfTasks = Environment.ProcessorCount; // Количество логических процессоров
            int chunkSize = numbers.Length / numberOfTasks;

            // Массив для хранения результатов
            long[] results = new long[numberOfTasks];

            // Создаем задачи для параллельного выполнения
            Task[] tasks = new Task[numberOfTasks];

            for (int i = 0; i < numberOfTasks; i++)
            {
                int taskIndex = i; // Локальная переменная для замыкания
                tasks[i] = Task.Run(() =>
                {
                    // Вычисляем сумму для текущего блока
                    int start = taskIndex * chunkSize;
                    int end = (taskIndex == numberOfTasks - 1) ? numbers.Length : start + chunkSize;
                    results[taskIndex] = Sum(numbers, start, end);
                });
            }

            // Ждем завершения всех задач
            Task.WaitAll(tasks);

            // Суммируем результаты из всех задач
            long totalSum = results.Sum();

            Console.WriteLine($"Сумма элементов массива: {totalSum}");
        }

        // Метод для вычисления суммы подмассива
        static long Sum(int[] array, int start, int end)
        {
            long sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
