namespace MathTasksCreator.IO.Contracts;

public interface IConsoleReader : IReader
{
    Task<(int taskQty, int taskNumberQty)> ReadCustomData();
}