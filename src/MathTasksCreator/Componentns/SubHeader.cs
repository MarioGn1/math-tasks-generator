using MathTasksCreator.IO;
using MathTasksCreator.IO.Contracts;

namespace MathTasksCreator.Componentns;

public static class SubHeader
{
    private static readonly IWriter _writer = new CustomWriter();

    public static async Task Render()
    {
        await _writer.WriteLine("Въведете количеството задачи които искате да бъдат подготвени");
        await _writer.WriteLine();
    }
}
