namespace Avalon.Console;

class ConsoleIon : Ine
{
    internal virtual ConsoleIntern Intern { get; set; }

    public override string Read()
    {
        return this.Intern.Read();
    }
}