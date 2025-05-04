namespace Avalon.Console;

class ConsoleInn : Inn
{
    public override bool Init()
    {
        base.Init();
        this.StringValue = StringValue.This;
        return true;
    }

    protected virtual StringValue StringValue { get; set; }

    public override String Read()
    {
        string ka;
        ka = SystemConsole.ReadLine();

        String k;
        k = this.StringValue.Execute(ka);

        return k;
    }
}