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

    protected virtual StringWriteCountOperate CreateCountOperate()
    {
        StringWriteCountOperate a;
        a = new StringWriteCountOperate();
        a.Write = this;
        a.Init();
        return a;
    }

    protected virtual StringWriteSetOperate CreateSetOperate()
    {
        StringWriteSetOperate a;
        a = new StringWriteSetOperate();
        a.Write = this;
        a.Init();
        return a;
    }

    public virtual Text Text { get; set; }
    public virtual String Result { get; set; }
    public virtual StringWriteArg Arg { get; set; }
    public virtual StringWriteOperate Operate { get; set; }
    public virtual StringWriteCountOperate CountOperate { get; set; }
    public virtual StringWriteSetOperate SetOperate { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra ClassInfra { get; set; }

    public virtual bool Execute()
    {
        this.Result = null;

        bool b;
        b = this.ValidValue(this.Text);
        if (!b)
        {
            return false;
        }

        this.Arg = new StringWriteArg();
        this.Arg.Init();

        StringWriteArg arg;
        arg = this.Arg;

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        long count;
        count = arg.Index;

        long k;
        k = count;
        k = k * sizeof(uint);

        arg.Data = new Data();
        arg.Data.Count = k;
        arg.Data.Init();

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Result = this.StringComp.CreateData(arg.Data, null);

        this.Arg = null;
        this.Operate = null;
        return true;
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

        long charQuote;
        long charNext;
        long charNewLine;
        long charAlphaN;
        long charAlphaU;
        charQuote = this.Char(classInfra.TextQuote);
        charNext = this.Char(classInfra.TextNext);
        charNewLine = this.Char(classInfra.TextNewLine);
        charAlphaN = this.Char(classInfra.TextAlphaN);
        charAlphaU = this.Char(classInfra.TextAlphaU); 

        long na;
        na = textInfra.DataCharGet(data, rangeStart);
        if (!(na == charQuote))
        {
            return false;
        }
        na = textInfra.DataCharGet(data, rangeEnd - 1);
        if (!(na == charQuote))
        {
            return false;
        }

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
            b = (n == charNext);
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
                if (nc == charQuote)
                {
                    bba = true;
                }
                if (nc == charAlphaN)
                {
                    bba = true;
                }
                if (nc == charNext)
                {
                    bba = true;
                }
                if (nc == charAlphaU)
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
                if (n == charQuote)
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

        long charQuote;
        long charNext;
        long charNewLine;
        long charAlphaN;
        long charAlphaU;
        charQuote = this.Char(classInfra.TextQuote);
        charNext = this.Char(classInfra.TextNext);
        charNewLine = this.Char(classInfra.TextNewLine);
        charAlphaN = this.Char(classInfra.TextAlphaN);
        charAlphaU = this.Char(classInfra.TextAlphaU);

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
            b = (n == charNext);
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
                if (nc == charNext)
                {
                    escapeValue = nc;
                }
                if (nc == charQuote)
                {
                    escapeValue = nc;
                }
                if (nc == charAlphaN)
                {
                    escapeValue = charNewLine;
                }
                if (nc == charAlphaU)
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
        this.Operate.ExecuteChar(n);
        return true;
    }
}