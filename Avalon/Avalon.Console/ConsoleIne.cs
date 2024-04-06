namespace Avalon.Console;

class ConsoleIne : Inn
{
    internal virtual ConsoleIntern Intern { get; set; }

    public override string Read()
    {
        return this.Intern.Read();
    }
}