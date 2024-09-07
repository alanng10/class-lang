namespace Avalon.Text;

class CharFormInfra : Any
{
    public static CharFormInfra This { get; } = ShareCreate();

    private static CharFormInfra ShareCreate()
    {
        CharFormInfra share;
        share = new CharFormInfra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public virtual bool Digit(long o)
    {
        return this.IsInRange('0', '9', o);
    }

    public virtual bool IsHexAlpha(long o, bool upperCase)
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
        return this.IsInRange(first, last, o);
    }

    public virtual bool IsLetter(long o, bool upperCase)
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
        return this.IsInRange(first, last, o);
    }

    public virtual bool IsInRange(long first, long last, long o)
    {
        if (last < first)
        {
            return false;
        }
        return !((o < first) | (last < o));
    }
}