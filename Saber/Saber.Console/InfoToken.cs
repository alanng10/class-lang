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

    protected virtual bool Start(String name)
    {
        this.Add(name).AddLine();
        this.AddSpace().AddS("{").AddLine();

        this.Space = this.Space + 4;
        return true;
    }

    protected virtual bool End()
    {
        this.Space = this.Space - 4;

        this.AddSpace().AddS("}").AddS(",").AddLine();
        return true;
    }

    protected virtual InfoToken AddSpace()
    {
        long count;
        count = this.Space;
        long i;
        i = 0;
        while (i < count)
        {
            this.AddS(" ");

            i = i + 1;
        }

        return this;
    }

    protected virtual bool Null()
    {
        this.AddS("null").AddS(",").AddLine();
        return true;
    }
}