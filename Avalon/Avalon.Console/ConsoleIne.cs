namespace Avalon.Console;

class ConsoleIne : Ine
{
    internal virtual ConsoleIntern Intern { get; set; }

    public override string Read()
    {
        return this.Intern.Read();
    }
}