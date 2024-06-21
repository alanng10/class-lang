namespace Class.Infra;

public class StoragePathCheck : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;

        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();
        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = charCompare;
        this.TextCompare.Init();

        this.Combine = this.TextInfra.TextCreateStringData(this.InfraInfra.PathCombine, null);
        this.BackSlash = this.TextInfra.TextCreateStringData("\\", null);
        this.Dot = this.TextInfra.TextCreateStringData(".", null);
        this.DotDot = this.TextInfra.TextCreateStringData("..", null);
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual Text Combine { get; set; }
    protected virtual Text BackSlash { get; set; }
    protected virtual Text Dot { get; set; }
    protected virtual Text DotDot { get; set; }


    public virtual bool IsValidSourcePath(Text text)
    {
        int k;
        k = this.TextInfra.Index(text, this.BackSlash, this.TextCompare);

        if (!(k == -1))
        {
            return false;
        }

        return true;
    }

    public virtual bool IsValidDestPath(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        if (!this.IsValidSourcePath(text))
        {
            return false;
        }

        Compare compare;
        compare = this.TextCompare;
        Text combine;
        combine = this.Combine;
        Text dot;
        dot = this.Dot;
        Text dotDot;
        dotDot = this.DotDot;

        int combineCount;
        combineCount = combine.Range.Count;

        InfraRange textRange;
        textRange = text.Range;

        int kaa;
        int kab;
        kaa = textRange.Index;
        kab = textRange.Count;

        bool b;
        b = false;

        int kk;
        kk = textInfra.Index(text, combine, compare);
        while (!b & !(kk == -1))
        {
            int e;
            e = textRange.Count;

            textRange.Count = kk;

            if (!b)
            {
                if (textInfra.Equal(text, dot, compare))
                {
                    b = true;
                }
            }

            if (!b)
            {
                if (textInfra.Equal(text, dotDot, compare))
                {
                    b = true;
                }
            }

            if (!b)
            {
                textRange.Count = e;

                int ka;
                ka = kk + combineCount;

                textRange.Index = textRange.Index + ka;
                textRange.Count = textRange.Count - ka;

                kk = textInfra.Index(text, combine, compare);
            }
        }

        if (!b)
        {
            if (textInfra.Equal(text, dot, compare))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (textInfra.Equal(text, dotDot, compare))
            {
                b = true;
            }
        }

        textRange.Index = kaa;
        textRange.Count = kab;

        if (b)
        {
            return false;
        }

        return true;
    }
}