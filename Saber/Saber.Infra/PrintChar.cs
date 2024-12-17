namespace Saber.Infra;

public class PrintChar : Any
{
    public static PrintChar This { get; } = ShareCreate();

    private static PrintChar ShareCreate()
    {
        PrintChar share;
        share = new PrintChar();
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

    public virtual bool Get(long index)
    {
        uint first;
        uint last;
        first = ' ';
        last = '~';

        bool a;
        a = this.TextInfra.Range(first, last, index);

        return a;
    }
}