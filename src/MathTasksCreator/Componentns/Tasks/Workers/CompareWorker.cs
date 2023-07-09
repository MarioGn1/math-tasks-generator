using MathTasksCreator.Componentns.Tasks.Contracts;
using MathTasksCreator.IO.Contracts;
using System.Text;

namespace MathTasksCreator.Componentns.Tasks.Workers;

public sealed class CompareWorker : IMathTaskWorker
{
    private const string InformationTemplate = "Вие избрахте да генерирате {0} задачи, всяка с {1} броя числа за сравнение, в диапазона {2} - {3}.";
    private const string OptionTemplate = "Натиснете 'Enter' за да генерирате задачите, или въведете '1' и после 'Enter' за да промените заданието...";

    private readonly IWriter _writer;
    private readonly IConsoleReader _reader;

    public CompareWorker(IConsoleReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public async Task Generate(ClassLevel classLevel, TaskType taskTypes)
    {
        if (!taskTypes.HasFlag(TaskType.Compare)) return;

        switch (classLevel)
        {
            case ClassLevel.FirstClass:
                await FirstClassTasks();
                break;
            default: throw new InvalidOperationException("No Class level selected");
        }
    }

    private async Task FirstClassTasks()
    {
        int taskQty;
        int taskNumberQty;
        int minNumber;
        int maxNumber;

        do
        {
            await _writer.Clear();
            await Header.Render();
            await _writer.WriteLine();
            await SubHeader.Render();

            await _writer.Write("Изберете брой задачи от тип сравнение на числа: ");
            if (!TryParse(await _reader.ReadLine(), out taskQty))
            {
                taskQty = 0;
            }

            await _writer.Write("Изберете броя числа в изразите: ");
            if (!TryParse(await _reader.ReadLine(), out taskNumberQty))
            {
                taskNumberQty = 0;
            }

            await _writer.Write("Изберете минимално число за сравнение: ");
            if (!TryParse(await _reader.ReadLine(), out minNumber))
            {
                minNumber = 0;
            }

            await _writer.Write("Изберете максималнo число за сравнение: ");
            if (!TryParse(await _reader.ReadLine(), out maxNumber))
            {
                maxNumber = 0;
            }

            await _writer.WriteLine();
            await _writer.WriteLine(string.Format(InformationTemplate, taskQty, taskNumberQty, minNumber, maxNumber));
            await _writer.WriteLine();
            await _writer.Write(OptionTemplate);
            await _writer.WriteLine();

        } while (TryParse(await _reader.ReadLine(), out var result) && result == 1);

        var sb = new StringBuilder();

        for (int i = 0; i < taskQty; i++)
        {
            var firstNum = new Random().Next(0, maxNumber);

            sb.Append($"{firstNum}");

            var numCount = 1;

            while (numCount < taskNumberQty)
            {
                var nextNum = new Random().Next(0, maxNumber);

                if (nextNum < minNumber || nextNum > maxNumber) continue;

                sb.Append($" [ ] {nextNum}");
                numCount++;
                continue;
            }

            sb.Append(";");
        }

        await _writer.Clear();
        await _writer.WriteLine(sb.ToString().Replace(";", Environment.NewLine));

        await _writer.WriteLine("Натиснете 'Enter' за да се върнете обратно в менюто...");
        await _reader.ReadLine();
    }
}
