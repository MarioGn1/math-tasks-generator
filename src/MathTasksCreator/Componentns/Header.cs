using MathTasksCreator.IO;
using MathTasksCreator.IO.Contracts;

namespace MathTasksCreator.Componentns;

public static class Header
{
    private static readonly IWriter _writer = new CustomWriter();

    public static async Task Render()
    {
        await _writer.WriteLine("/////////////////////////////////////////////");
        await _writer.WriteLine("////// WELCOME TO MY MATH TASK CREATOR //////");
        await _writer.WriteLine("/////////////////////////////////////////////");
    }
}
