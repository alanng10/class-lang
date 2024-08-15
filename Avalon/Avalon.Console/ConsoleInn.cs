namespace Avalon.Console;

class ConsoleInn : Inn
{
    internal virtual ConsoleIntern Intern { get; set; }

    public override String Read()
    {
        return this.Intern.Read();
    }
}