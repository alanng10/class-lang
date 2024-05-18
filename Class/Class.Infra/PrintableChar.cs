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

    public virtual bool Get(int index)
    {
        int first;
        int last;
        first = '!';
        last = '~';

        bool a;
        a = !(index < first | last < index);

        return a;
    }
}