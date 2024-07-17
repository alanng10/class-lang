namespace Avalon.Single;

class ConsoleOut : Out
{
    internal virtual ConsoleIntern Intern { get; set; }

    internal virtual int Stream { get; set; }

    public override bool Write(string o)
    {
        this.Intern.Write(this.Stream, o);
        return true;
    }
}