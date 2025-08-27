class FormInfra : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.StringComp : share StringComp;
        return true;
    }

    field prusate StringComp StringComp { get { return data; } set { data : value; } }

    maide prusate Bool Digit(var Int value)
    {
        var Int ka;
        var Int kb;
        ka : this.Char("0");
        kb : this.Char("9");

        return this.Range(ka, kb, value);
    }

    maide prusate Bool HexAlpha(var Int value, var Bool nite)
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
        return this.Range(start, end, value);
    }

    maide prusate Bool Alpha(var Int value, var Bool nite)
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
        return this.Range(start, end, value);
    }

    maide prusate Bool Range(var Int start, var Int end, var Int value)
    {
        inf (end < start)
        {
            return false;
        }
        return ~((value < start) | (end < value));
    }

    maide prusate Int Char(var String k)
    {
        return this.StringComp.Char(k, 0);
    }
}