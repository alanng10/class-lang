namespace Avalon.Console;

class ConsoleOut : Out
{
    internal virtual ConsoleIntern Intern { get; set; }
    internal virtual long Stream { get; set; }

    public override bool Write(String k)
    {
        this.Intern.Write(this.Stream, k);
        return true;
    }
}