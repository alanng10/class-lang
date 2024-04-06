namespace Avalon.Console;

class ConsoleIon : Ion
{
    internal virtual ConsoleIntern Intern { get; set; }

    public override string Read()
    {
        return this.Intern.Read();
    }
}