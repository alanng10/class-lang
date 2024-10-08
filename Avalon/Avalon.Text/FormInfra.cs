namespace Avalon.Text;

class FormInfra : Any
{
    public static FormInfra This { get; } = ShareCreate();

    private static FormInfra ShareCreate()
    {
        FormInfra share;
        share = new FormInfra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public virtual bool Digit(long o)
    {
        return this.Range('0', '9', o);
    }

    public virtual bool HexAlpha(long o, bool upperCase)
    {
        uint first;
        first = 'a';
        uint last;
        last = 'f';
        if (upperCase)
        {
            first = 'A';
            last = 'F';
        }
        return this.Range(first, last, o);
    }

    public virtual bool Alpha(long o, bool upperCase)
    {
        uint first;
        first = 'a';
        uint last;
        last = 'z';
        if (upperCase)
        {
            first = 'A';
            last = 'Z';
        }
        return this.Range(first, last, o);
    }

    public virtual bool Range(long first, long last, long o)
    {
        if (last < first)
        {
            return false;
        }
        return !((o < first) | (last < o));
    }
}