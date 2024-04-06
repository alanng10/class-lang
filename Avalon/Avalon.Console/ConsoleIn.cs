namespace Avalon.Console;

class ConsoleIn : Ion
{
    internal virtual ConsoleIntern Intern { get; set; }

    public override string Read()
    {
        return this.Intern.Read();
    }
}