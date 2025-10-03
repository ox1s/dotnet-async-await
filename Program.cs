using System.Diagnostics;

var task = new MyTask();
var stopwatch = new Stopwatch();

Console.WriteLine("Запускаем синхронные методы: ");
stopwatch.Start();
Console.WriteLine(task.ProcessData("Файл 1"));
Console.WriteLine(task.ProcessData("Файл 2"));
Console.WriteLine(task.ProcessData("Файл 3"));
stopwatch.Stop();
Console.WriteLine($"Прошло: {stopwatch.ElapsedMilliseconds} мс\n");

Console.WriteLine("Запускаем асинхронные методы: ");
stopwatch.Restart();
// Типо получаем данные, которые нужны для последующей обработки
Console.WriteLine(await task.ProcessDataAsync("данные для подфайлов"));

var tasks = new List<Task<string>> {
    task.ProcessDataAsync("Файл 1.1"),
    task.ProcessDataAsync("Файл 1.2"),
    task.ProcessDataAsync("Файл 1.3"),
};

string[] results = await Task.WhenAll(tasks);
stopwatch.Stop();

foreach (string result in results)
    Console.WriteLine(result);
Console.WriteLine($"Прошло: {stopwatch.ElapsedMilliseconds} мс\n");

Console.WriteLine("Все файлы обработаны");

