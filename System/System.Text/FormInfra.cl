class FormInfra : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.StringComp : share StringComp;
        return true;
    }

    field prusate StringComp StringComp { get { return data; } set { data : value; } }

    maide prusate Bool Digit(var Int n)
    {
        var Int ka;
        var Int kb;
        ka : this.Char("0");
        kb : this.Char("9");

        return this.Range(ka, kb, n);
    }

    maide prusate Bool HexAlpha(var Int n, var Bool nite)
    {
        var Int start;
        var Int end;

        inf (nite)
        {
            start : this.Char("A");
            end : this.Char("F");
        }
        inf (~nite)
        {
            start : this.Char("a");
            end : this.Char("f");
        }
        return this.Range(start, end, n);
    }

    maide prusate Bool Alpha(var Int n, var Bool nite)
    {
        var Int start;
        var Int end;

        inf (nite)
        {
            start : this.Char("A");
            end : this.Char("Z");
        }
        inf (~nite)
        {
            start : this.Char("a");
            end : this.Char("z");
        }
        return this.Range(start, end, n);
    }

    maide prusate Bool Range(var Int start, var Int end, var Int n)
    {
        inf (end < start)
        {
            return false;
        }
        return ~((n < start) | (end < n));
    }

    maide prusate Int Char(var String k)
    {
        return this.StringComp.Char(k, 0);
    }
}