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

    public override bool Init()
    {
        base.Init();
        this.StringComp = StringComp.This;
        return true;
    }

    protected virtual StringComp StringComp { get; set; }

    public virtual long Char(String k)
    {
        return this.StringComp.Char(k, 0);
    }

    public virtual bool Digit(long n)
    {
        return this.Range('0', '9', n);
    }

    public virtual bool HexAlpha(long n, bool nite)
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
        return this.Range(start, end, n);
    }

    public virtual bool Alpha(long n, bool nite)
    {
        uint start;
        uint end;
        start = 0;
        end = 0;
        if (nite)
        {
            start = 'A';
            end = 'Z';
        }
        if (!nite)
        {
            start = 'a';
            end = 'z';
        }
        return this.Range(start, end, n);
    }

    public virtual bool Range(long start, long end, long n)
    {
        if (end < start)
        {
            return false;
        }
        return !((n < start) | (end < n));
    }
}