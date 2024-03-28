namespace Avalon.Console;

public class ConsoleOut : Out
{
    public override bool Write(string o)
    {
        return true;
    }
}