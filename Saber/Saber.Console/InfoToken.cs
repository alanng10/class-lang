namespace Saber.Console;

public class InfoToken : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.PrintChar = this.CreatePrintChar();
        return true;
    }

    protected virtual PrintChar CreatePrintChar()
    {
        PrintChar a;
        a = new PrintChar();
        a.Init();
        return a;
    }

    protected virtual PrintChar PrintChar { get; set; }
    protected virtual long Space { get; set; }
}