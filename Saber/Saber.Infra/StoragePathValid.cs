namespace Saber.Infra;

public class StoragePathValid : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;

        this.SSlash = this.S("/");
        this.SNext = this.S("\\");
        this.SSlashSlash = this.S("//");
        this.SDot = this.S(".");
        this.SDotDot = this.S("..");
        return true;
    }

    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual String SSlash { get; set; }
    protected virtual String SNext { get; set; }
    protected virtual String SSlashSlash { get; set; }
    protected virtual String SDot { get; set; }
    protected virtual String SDotDot { get; set; }

    public virtual bool ValidSourcePath(Text text)
    {
        bool a;
        a = this.PrivateValidSourcePath(text);

        this.ClearData();
        return a;
    }

    private bool PrivateValidSourcePath(Text text)
    {
        if (text.Range.Count == 0)
        {
            return false;
        }

        long ka;
        long kb;
        ka = text.Range.Index;
        kb = text.Range.Count;

        text.Range.Index = ka + kb - 1;
        text.Range.Count = 1;

        bool ba;
        ba = this.TextSame(text, this.TA(this.SSlash));

        text.Range.Index = ka;
        text.Range.Count = kb;

        if (ba)
        {
            return false;
        }

        long kaa;
        kaa = this.TextIndex(text, this.TA(this.SNext));

        if (!(kaa == -1))
        {
            return false;
}

        long kab;
        kab = this.TextIndex(text, this.TA(this.SSlashSlash));

        if (!(kab == -1))
        {
            return false;
        }

        return true;
    }

    public virtual bool ValidDestPath(Text text)
    {
        if (!this.ValidSourcePath(text))
        {
            return false;
        }

        if (!this.StorageInfra.PathRelate(text, this.TLess))
        {
            return false;
        }

        if (this.HasDotOrnDotDot(text))
        {
            return false;
        }

        return true;
    }

    protected virtual bool HasDotOrnDotDot(Text text)
    {
        Text combine;
        Text dot;
        Text dotDot;
        combine = this.TA(this.TextInfra.PathCombine);
        dot = this.TB(this.SDot);
        dotDot = this.TC(this.SDotDot);

        long combineCount;
        combineCount = combine.Range.Count;

        InfraRange range;
        range = text.Range;

        long kaa;
        long kab;
        kaa = range.Index;
        kab = range.Count;

        bool b;
        b = false;

        long kk;
        kk = this.TextIndex(text, combine);
        while (!b & !(kk == -1))
        {
            long ke;
            ke = range.Count;

            range.Count = kk;

            if (!b)
            {
                if (this.TextSame(text, dot))
                {
                    b = true;
                }
            }

            if (!b)
            {
                if (this.TextSame(text, dotDot))
                {
                    b = true;
                }
            }

            if (!b)
            {
                range.Count = ke;

                long ka;
                ka = kk + combineCount;

                range.Index = range.Index + ka;
                range.Count = range.Count - ka;

                kk = this.TextIndex(text, combine);
            }
        }

        if (!b)
        {
            if (this.TextSame(text, dot))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (this.TextSame(text, dotDot))
            {
                b = true;
            }
        }

        range.Index = kaa;
        range.Count = kab;

        bool a;
        a = b;

        this.ClearData();
        return a;
    }
}