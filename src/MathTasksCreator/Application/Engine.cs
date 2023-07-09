using MathTasksCreator.Componentns;
using MathTasksCreator.Componentns.Contracts;
using MathTasksCreator.Componentns.Menu;
using MathTasksCreator.IO.Contracts;

namespace MathTasksCreator.Application;

internal class Engine
{
    private readonly ICustomComponent<MainMenu, bool> _mainMenu;

    public Engine(ICustomComponent<MainMenu, bool> mainMenu)
    {
        _mainMenu = mainMenu;
    }

    public async Task Run()
    {
        var running = true;

        while (running)
        {
            running = await _mainMenu.Render();
        }
    }
}
