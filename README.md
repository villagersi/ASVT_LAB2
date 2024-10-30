FirstExample
1. Создание массива: Мы создаем массив numbers, содержащий числа от 1 до 1 миллиона.
2. Определение количества задач: Мы определяем количество задач на основе количества логических процессоров с помощью Environment.ProcessorCount.
3. Создание задач: Мы создаем массив tasks и запускаем задачи с помощью Task.Run(). Каждая задача вычисляет сумму своей части массива.
4. Ожидание завершения задач: Мы используем Task.WaitAll() для ожидания завершения всех задач.
5. Суммирование результатов: После завершения всех задач мы суммируем результаты из массива results и выводим общую сумму.

SecondExample
1. Указание директории: В переменной directoryPath укажите путь к директории, содержащей текстовые файлы.
2. Получение файлов: Мы используем Directory.GetFiles() для получения списка всех текстовых файлов в указанной директории.
3. Создание задач: Мы создаем массив задач tasks, где каждая задача будет подсчитывать количество строк в своем соответствующем файле с помощью метода CountLinesInFile.
4. Запуск задач: Мы запускаем каждую задачу с помощью Task.Run().
5. Ожидание завершения задач: Используя await Task.WhenAll(tasks), мы ожидаем завершения всех задач и получаем массив lineCounts, содержащий количество строк для каждого файла.
6. Вывод результатов: После завершения всех задач мы выводим название файла и количество строк в нем.
Запуск программы
Чтобы запустить этот код, создайте новый проект консольного приложения и вставьте этот код в файл Program.cs. Не забудьте указать правильный путь к директории с текстовыми файлами. После этого запустите программу, и она выведет количество строк для каждого текстового файла в указанной директории.
Этот пример демонстрирует, как можно использовать многопоточность для параллельной обработки файлов, что может значительно ускорить выполнение задач, связанных с чтением и анализом большого количества данных.
