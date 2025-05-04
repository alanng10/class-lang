namespace Avalon.Console;

class ConsoleOut : Out
{
    public override bool Init()
    {
        base.Init();
        this.StringValue = StringValue.This;
        return true;
    }

    protected virtual StringValue StringValue { get; set; }
    internal virtual long Stream { get; set; }

    public override bool Write(String text)
    {
        string ka;
        ka = this.StringValue.ExecuteIntern(text);

        SystemOut kk;
        kk = null;

        bool b;
        b = (this.Stream == 0);
        
        if (b)
        {
            kk = SystemConsole.Out;
        }

        if (!b)
        {
            kk = SystemConsole.Error;
        }
        
        kk.Write(ka);

        return true;
    }
}