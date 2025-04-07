namespace Saber.Infra;

public class NameValid : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ClassInfra = Infra.This;

        this.IndexList = IndexList.This;
        return true;
    }

    protected virtual Infra ClassInfra { get; set; }
    protected virtual IndexList IndexList { get; set; }

    public virtual bool Name(Text text)
    {
        if (this.Index(text))
        {
            return false;
        }

        return this.NamePart(text);
    }

    public virtual bool NamePart(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        TextForm textForm;
        textForm = this.TForm;

        if (text.Range.Count == 0)
        {
            return false;
        }

        Data data;
        data = text.Data;
        long start;
        start = text.Range.Index;

        long index;
        index = start;
        long n;
        n = textInfra.DataCharGet(data, index);

        n = textForm.Execute(n);

        if (!(textInfra.Alpha(n, true) | textInfra.Alpha(n, false)))
        {
            return false;
        }

        long charLine;
        charLine = this.Char(this.ClassInfra.TextLine);

        bool b;
        b = false;

        long count;
        count = text.Range.Count;
        count = count - 1;

        start = start + 1;

        long i;
        i = 0;
        while (!b & i < count)
        {
            index = start + i;

            n = textInfra.DataCharGet(data, index);

            n = textForm.Execute(n);

            bool ba;
            ba = textInfra.Alpha(n, true) | textInfra.Alpha(n, false) | textInfra.Digit(n) | n == charLine;

            if (!ba)
            {
                b = true;
            }
            i = i + 1;
        }

        bool a;
        a = !b;
        return a;
    }

    public virtual bool ModuleName(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Less less;
        less = this.TLess;

        Text dot;
        dot = this.TA(this.ClassInfra.TextDot);

        InfraRange range;
        range = text.Range;

        long ka;
        long kb;
        ka = range.Index;
        kb = range.Count;
        long kc;
        kc = ka + kb;

        bool b;
        b = false;

        long kk;
        kk = textInfra.Index(text, dot, less);

        long index;
        long count;
        index = ka;
        count = kb;
        while (!b & !(kk == -1))
        {
            count = kk;
            range.Count = count;

            if (!this.NamePart(text))
            {
                b = true;
            }

            if (!b)
            {
                index = index + kk + 1;
                count = kc - index;

                range.Index = index;
                range.Count = count;

                kk = textInfra.Index(text, dot, less);
            }
        }

        bool ba;
        ba = false;

        if (!ba)
        {
            if (b)
            {
                ba = true;
            }
        }
        if (!ba)
        {
            count = kc - index;
            range.Count = count;

            if (!this.NamePart(text))
            {
                ba = true;
            }
        }

        range.Index = ka;
        range.Count = kb;

        bool a;
        a = !ba;

        this.ClearData();
        return a;
    }

    public virtual bool Index(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        IndexList indexList;
        indexList = this.IndexList;

        TextLess less;
        less = this.TLess;

        bool b;
        b = false;

        long count;
        count = indexList.Count;
        long i;
        i = 0;
        while (!b & i < count)
        {
            Index ka;
            ka = indexList.Get(i);
            String kb;
            kb = ka.Text;

            if (textInfra.Same(text, this.TA(kb), less))
            {
                b = true;
            }
            i = i + 1;
        }

        bool a;
        a = b;

        this.ClearData();
        return a;
    }
}