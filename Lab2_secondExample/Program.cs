using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_secondExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string directoryPath = @"C:YourDirectory"; // Укажите путь к вашей директории

            // Получаем все текстовые файлы в директории
            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            // Создаем массив задач
            Task<int>[] tasks = new Task<int>[files.Length];

            // Запускаем задачи для подсчета строк в каждом файле
            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i]; // Локальная переменная для замыкания
                tasks[i] = Task.Run(() => CountLinesInFile(filePath));
            }

            // Ждем завершения всех задач
            int[] lineCounts = await Task.WhenAll(tasks);

            // Выводим результаты
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"Файл: {Path.GetFileName(files[i])}, Количество строк: {lineCounts[i]}");
            }
        }

        // Метод для подсчета строк в файле
        static int CountLinesInFile(string filePath)
        {
            int lineCount = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            return lineCount;
        }
    }
}
