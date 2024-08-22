namespace Class.Infra;

public class StoragePathCheck : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.StorageInfra = StorageInfra.This;

        LessMid charLess;
        charLess = new LessMid();
        charLess.Init();
        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();
        this.TextLess = new TextLess();
        this.TextLess.CharLess = charLess;
        this.TextLess.LeftCharForm = charForm;
        this.TextLess.RightCharForm = charForm;
        this.TextLess.Init();

        this.Combine = this.TextInfra.TextCreateStringData(this.InfraInfra.PathCombine, null);
        this.BackSlash = this.TextInfra.TextCreateStringData("\\", null);
        this.SlashSlash = this.TextInfra.TextCreateStringData("//", null);
        this.Dot = this.TextInfra.TextCreateStringData(".", null);
        this.DotDot = this.TextInfra.TextCreateStringData("..", null);
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual TextLess TextLess { get; set; }
    protected virtual Text Combine { get; set; }
    protected virtual Text BackSlash { get; set; }
    protected virtual Text SlashSlash { get; set; }
    protected virtual Text Dot { get; set; }
    protected virtual Text DotDot { get; set; }

    public virtual bool IsValidSourcePath(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        
        int k;
        k = textInfra.Index(text, this.BackSlash, this.TextLess);

        if (!(k == -1))
        {
            return false;
        }

        k = textInfra.Index(text, this.SlashSlash, this.TextLess);

        if (!(k == -1))
        {
            return false;
        }

        return true;
    }

    public virtual bool IsValidDestPath(Text text)
    {
        if (!this.IsValidSourcePath(text))
        {
            return false;
        }

        Less less;
        less = this.TextLess;

        if (!this.StorageInfra.IsRelativePath(text, less))
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
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Less less;
        less = this.TextLess;

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
        kk = textInfra.Index(text, combine, less);
        while (!b & !(kk == -1))
        {
            int e;
            e = textRange.Count;

            textRange.Count = kk;

            if (!b)
            {
                if (textInfra.Equal(text, dot, less))
                {
                    b = true;
                }
            }

            if (!b)
            {
                if (textInfra.Equal(text, dotDot, less))
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

                kk = textInfra.Index(text, combine, less);
            }
        }

        if (!b)
        {
            if (textInfra.Equal(text, dot, less))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (textInfra.Equal(text, dotDot, less))
            {
                b = true;
            }
        }

        textRange.Index = kaa;
        textRange.Count = kab;

        if (b)
        {
            return true;
        }

        return false;
    }
}