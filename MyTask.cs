public class MyTask
{
    public string ProcessData(string dataName)
    {
        //Thread.Sleep(3000); 
        Task.Delay(3000).Wait();
        string result = $"Обработка {dataName} завершена за 3 секунды";

        return result;
    }
    public async Task<string> ProcessDataAsync(string dataName)
    {
        await Task.Delay(3000);
        string result = $"Обработка {dataName} завершена за 3 секунды";

        return result;
    }
}
