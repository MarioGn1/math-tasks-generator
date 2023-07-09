using MathTasksCreator.Componentns;
using MathTasksCreator.IO.Contracts;

namespace MathTasksCreator.IO;

public sealed class CustomReader : IConsoleReader
{
    public async Task<(int taskQty, int taskNumberQty)> ReadCustomData()
    {
        await SubHeader.Render();
        Console.Write("Изберете брой задачи от тип събиране/изваждане: ");
        if (!TryParse(Console.ReadLine(), out var taskQty))
        {
            taskQty = 0;
        }

        Console.Write("Изберете броя числа в изразите: ");
        if (!TryParse(Console.ReadLine(), out var taskNumberQty))
        {
            taskNumberQty = 0;
        }

        return (taskQty, taskNumberQty);
    }

    public Task<string?> ReadLine()
        => Task.FromResult(Console.ReadLine());
}