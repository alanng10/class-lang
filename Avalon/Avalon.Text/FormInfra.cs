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

    public virtual bool Digit(long n)
    {
        return this.Range('0', '9', n);
    }

    public virtual bool HexAlpha(long o, bool nite)
    {
        uint start;
        uint end;
        start = 0;
        end = 0;
        if (nite)
        {
            start = 'A';
            end = 'F';
        }
        if (!nite)
        {
            start = 'a';
            end = 'f';
        }
        return this.Range(start, end, o);
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

    public virtual bool Range(long start, long end, long o)
    {
        if (end < start)
        {
            return false;
        }
        return !((o < start) | (end < o));
    }
}