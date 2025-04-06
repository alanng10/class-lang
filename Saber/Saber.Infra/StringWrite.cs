namespace Saber.Infra;

public class StringWrite : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ClassInfra = Infra.This;
 
        this.Arg = this.CreateArg();
        this.CountOperate = this.CreateCountOperate();
        this.SetOperate = this.CreateSetOperate();
        return true;
    }

    protected virtual StringWriteArg CreateArg()
    {
        StringWriteArg a;
        a = new StringWriteArg();
        a.Init();
        return a;
    }

    protected virtual StringCountWriteOperate CreateCountOperate()
    {
        StringCountWriteOperate a;
        a = new StringCountWriteOperate();
        a.Write = this;
        a.Init();
        return a;
    }

    protected virtual StringSetWriteOperate CreateSetOperate()
    {
        StringSetWriteOperate a;
        a = new StringSetWriteOperate();
        a.Write = this;
        a.Init();
        return a;
    }

    public virtual Text Text { get; set; }
    public virtual StringCountWriteOperate CountOperate { get; set; }
    public virtual StringSetWriteOperate SetOperate { get; set; }
    public virtual StringWriteOperate Operate { get; set; }
    public virtual StringWriteArg Arg { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra ClassInfra { get; set; }

    public virtual String Execute()
    {
        bool b;
        b = this.ValidValue(this.Text);
        if (!b)
        {
            return null;
        }

        this.Arg = new StringWriteArg();
        this.Arg.Init();

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        long count;
        count = this.Index;

        long k;
        k = count;
        k = k * sizeof(uint);

        this.Arg.Data = new Data();
        this.Arg.Data.Count = k;
        this.Arg.Data.Init();

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        String a;
        a = this.StringComp.CreateData(this.Arg.Data, null);

        this.Operate = null;
        this.Arg = null;
        return a;
    }

    public virtual bool ValidValue(Text text)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;
        Infra classInfra;
        classInfra = this.ClassInfra;
        StringComp stringComp;
        stringComp = this.StringComp;

        InfraRange range;
        range = text.Range;
        long kk;
        kk = range.Count;
        if (kk < 2)
        {
            return false;
        }

        Data data;
        data = text.Data;
        long rangeStart;
        long rangeEnd;
        rangeStart = range.Index;
        rangeEnd = rangeStart + range.Count;

        long quote;
        quote = textInfra.Char(classInfra.TextQuote);

        long na;
        na = textInfra.DataCharGet(data, rangeStart);
        if (!(na == quote))
        {
            return false;
        }
        na = textInfra.DataCharGet(data, rangeEnd - 1);
        if (!(na == quote))
        {
            return false;
        }

        long next;
        next = textInfra.Char(classInfra.TextNext);
        long newLine;
        newLine = textInfra.Char(classInfra.TextNewLine);

        long countA;
        countA = 8;

        long count;
        count = kk - 2;
        long start;
        start = rangeStart + 1;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = start + i;

            long n;
            n = textInfra.DataCharGet(data, index);

            bool b;
            b = (n == next);
            if (b)
            {
                long j;
                j = i + 1;
                if (!(j < count))
                {
                    return false;
                }
                long indexA;
                indexA = start + j;

                long nc;
                nc = textInfra.DataCharGet(data, indexA);

                bool bba;
                bba = false;
                if (nc == quote)
                {
                    bba = true;
                }
                if (nc == 'n')
                {
                    bba = true;
                }
                if (nc == next)
                {
                    bba = true;
                }
                if (nc == 'u')
                {
                    long ja;
                    ja = j + 1;
                    if (!infraInfra.ValidRange(count, ja, countA))
                    {
                        return false;
                    }
                    long indexAa;
                    indexAa = start + ja;
                    long iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        long ka;
                        ka = indexAa + iA;
                        long nd;
                        nd = textInfra.DataCharGet(data, ka);

                        if (!(textInfra.Digit(nd) | textInfra.HexAlpha(nd, false)))
                        {
                            return false;
                        }

                        iA = iA + 1;
                    }

                    i = i + countA;
                    bba = true;
                }
                if (!bba)
                {
                    return false;
                }
                i = i + 1;
            }
            if (!b)
            {
                if (n == quote)
                {
                    return false;
                }
            }
            i = i + 1;
        }
        return true;
    }

    public virtual bool ResetStage()
    {
        this.Arg.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        Infra classInfra;
        classInfra = this.ClassInfra;
        StringComp stringComp;
        stringComp = this.StringComp;

        Data data;
        data = this.Text.Data;
        InfraRange range;
        range = this.Text.Range;
        long kk;
        kk = range.Count;

        long quote;
        quote = textInfra.Char(classInfra.TextQuote);
        long next;
        next = textInfra.Char(classInfra.TextNext);
        long newLine;
        newLine = textInfra.Char(classInfra.TextNewLine);

        long countA;
        countA = 8;
        long count;
        count = kk - 2;
        long start;
        start = range.Index + 1;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = start + i;

            long n;
            n = textInfra.DataCharGet(data, index);

            bool b;
            b = (n == next);
            if (b)
            {
                long j;
                j = i + 1;

                long indexA;
                indexA = start + j;
                long nc;
                nc = textInfra.DataCharGet(data, indexA);

                long escapeValue;
                escapeValue = 0;
                if (nc == next)
                {
                    escapeValue = nc;
                }
                if (nc == quote)
                {
                    escapeValue = nc;
                }
                if (nc == 'n')
                {
                    escapeValue = newLine;
                }
                if (nc == 'u')
                {
                    long ka;
                    ka = 0;
                    long indexAa;
                    indexAa = start + j + 1;
                    long iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        long kb;
                        kb = indexAa + iA;
                        long nd;
                        nd = textInfra.DataCharGet(data, kb);

                        long kc;
                        kc = textInfra.DigitValue(nd, 16);

                        long na;
                        na = countA - 1 - iA;

                        int shiftCount;
                        shiftCount = (int)(na * 4);

                        long nn;
                        nn = kc << shiftCount;

                        ka = ka | nn;

                        iA = iA + 1;
                    }

                    escapeValue = ka;

                    i = i + countA;
                }

                this.ExecuteChar(escapeValue);

                i = i + 1;
            }

            if (!b)
            {
                this.ExecuteChar(n);
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteChar(long n)
    {
        this.WriteOperate.ExecuteChar(n);
        return true;
    }
}