using MathTasksCreator.Componentns.Contracts;
using MathTasksCreator.Componentns.Tasks;
using MathTasksCreator.Componentns.Tasks.Contracts;
using MathTasksCreator.IO.Contracts;

namespace MathTasksCreator.Componentns.Menu;

public sealed class FirstClassMenu : ICustomComponent<FirstClassMenu, bool>
{
    private readonly IConsoleReader _reader;
    private readonly IWriter _writer;
    private readonly IMathTaskManager _taskCreator;

    public FirstClassMenu(IConsoleReader reader, IWriter writer, IMathTaskManager taskCreator)
    {
        _reader = reader;
        _writer = writer;
        _taskCreator = taskCreator;
    }
    public async Task<bool> Render()
    {
        int option;

        do
        {
            await _writer.Clear();
            await Header.Render();
            await _writer.WriteLine();
            await _writer.WriteLine("1. Събиране (в процес на разработка)");
            await _writer.WriteLine("2. Изваждане (в процес на разработка)");
            await _writer.WriteLine("3. Събиране + Изваждане");
            await _writer.WriteLine("4. Сравнение на числа");
            await _writer.WriteLine("5. Изход");
            await _writer.WriteLine();
            await _writer.WriteLine("Изберете категория като въведете съответната цифра и натиснете 'Enter'");
            await _writer.Write("Категория: ");

        } while (TryParse(await _reader.ReadLine(), out option) && option < 1 || option > 9);

        await _writer.Clear();

        return await Execute(option);
    }

    private async Task<bool> Execute(int option)
    {
        bool running = true;
        TaskType taskTypes = TaskType.None;

        switch (option)
        {
            case 1:
                taskTypes = TaskType.Add;
                break;
            case 2:
                taskTypes = TaskType.Subtract;
                break;
            case 3:
                taskTypes = TaskType.Add | TaskType.Subtract;
                break;
            case 4:
                taskTypes = TaskType.Compare;
                break;
            case 5:
                running = false;
                break;
            default:
                break;
        }

        await _taskCreator.Generate(ClassLevel.FirstClass, taskTypes);

        return running;
    }
}
