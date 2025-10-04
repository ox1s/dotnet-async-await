using System.Diagnostics;

var operationsSimulator = new OperationSimulator();
var stopwatch = new Stopwatch();

Console.WriteLine("Запускаем синхронные методы: ");
stopwatch.Start();

Console.WriteLine(operationsSimulator.ProcessData("Файл 1"));
Console.WriteLine(operationsSimulator.ProcessData("Файл 2"));
Console.WriteLine(operationsSimulator.ProcessData("Файл 3"));

stopwatch.Stop();
Console.WriteLine($"Прошло: {stopwatch.ElapsedMilliseconds} мс\n");

Console.WriteLine("Запускаем асинхронные методы: ");
stopwatch.Restart();
// Типо получаем данные, которые нужны для последующей обработки
Console.WriteLine(await operationsSimulator.ProcessDataAsync("данные для подфайлов"));

var operationsSimulators = new List<Task<string>> {
    operationsSimulator.ProcessDataAsync("Файл 1.1"),
    operationsSimulator.ProcessDataAsync("Файл 1.2"),
    operationsSimulator.ProcessDataAsync("Файл 1.3"),
};

string[] results = await Task.WhenAll(operationsSimulators);
stopwatch.Stop();

foreach (string result in results)
    Console.WriteLine(result);
Console.WriteLine($"Прошло: {stopwatch.ElapsedMilliseconds} мс\n");

Console.WriteLine("Все файлы обработаны");

