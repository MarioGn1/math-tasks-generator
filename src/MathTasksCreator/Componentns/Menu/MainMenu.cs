using MathTasksCreator.Componentns.Contracts;
using MathTasksCreator.IO.Contracts;
using System.Reflection.PortableExecutable;

namespace MathTasksCreator.Componentns.Menu;

public class MainMenu : ICustomComponent<MainMenu, bool>
{
    private readonly IConsoleReader _reader;
    private readonly IWriter _writer;
    private readonly ICustomComponent<FirstClassMenu, bool> _firstClassMenu;

    public MainMenu(IConsoleReader reader, IWriter writer, ICustomComponent<FirstClassMenu, bool> firstClassMenu)
    {
        _reader = reader;
        _writer = writer;
        _firstClassMenu = firstClassMenu;
    }

    public async Task<bool> Render()
    {
        int option;
        do
        {
            await _writer.Clear();
            await Header.Render();
            await _writer.WriteLine();
            await _writer.WriteLine("1. Задачи за 1-ви клас");
            await _writer.WriteLine("2. Задачи за 2-ри клас (в процес на разработка)");
            await _writer.WriteLine("3. Задачи за 3-ти клас (в процес на разработка)");
            await _writer.WriteLine("4. Изход");
            await _writer.WriteLine();
            await _writer.WriteLine("Изберете категория като въведете съответната цифра и натиснете 'Enter'");
            await _writer.Write("Категория: ");

        } while (TryParse(await _reader.ReadLine(), out option) && option < 1 || option > 4);

        await _writer.Clear();

        return await Execute(option);
    }

    private async Task<bool> Execute(int option)
    {
        bool running = true;
        bool tasksMenuRunning = true;

        switch (option)
        {
            case 1:
                while (tasksMenuRunning)
                {
                    tasksMenuRunning = await _firstClassMenu.Render();
                }
                break;
            case 2:
                while (tasksMenuRunning)
                {
                    tasksMenuRunning = false;
                }
                break;
            case 3:
                while (tasksMenuRunning)
                {
                    tasksMenuRunning = false;
                }
                break;
            case 4:
                running = false;
                break;
            default:
                break;
        }

        return running;
    }
}
