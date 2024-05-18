namespace Class.Infra;

public class PrintableChar : Any
{
    public static PrintableChar This { get; } = ShareCreate();

    private static PrintableChar ShareCreate()
    {
        PrintableChar share;
        share = new PrintableChar();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }

    public virtual bool Get(char index)
    {
        char first;
        char last;
        first = ' ';
        last = '~';

        bool a;
        a = this.TextInfra.IsInRange(first, last, index);

        return a;
    }
}