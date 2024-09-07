namespace Class.Infra;

public class StringValueWrite : Any
{
    public override bool Init()
    {
        base.Init();
        
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = Infra.This;
        this.StringComp = StringComp.This;

        this.CountWriteOperate = new CountWriteOperate();
        this.CountWriteOperate.Write = this;
        this.CountWriteOperate.Init();
        this.AddWriteOperate = new AddWriteOperate();
        this.AddWriteOperate.Write = this;
        this.AddWriteOperate.Init();
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Infra ClassInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    public virtual CountWriteOperate CountWriteOperate { get; set; }
    public virtual AddWriteOperate AddWriteOperate { get; set; }

    public virtual WriteOperate WriteOperate { get; set; }

    public virtual Data Data { get; set; }
    public virtual long Index { get; set; }

    public virtual String Value(Text text)
    {
        bool b;
        b = this.CheckValueString(text);
        if (!b)
        {
            return null;
        }

        this.WriteOperate = this.CountWriteOperate;
        this.Index = 0;
        this.ExecuteValueString(text);

        long count;
        count = this.Index;
        
        long k;
        k = count;
        k = k * sizeof(uint);
        this.Data = new Data();
        this.Data.Count = k;
        this.Data.Init();

        this.WriteOperate = this.AddWriteOperate;
        this.Index = 0;
        this.ExecuteValueString(text);

        String a;
        a = this.StringComp.CreateData(this.Data, null);

        this.Data = null;
        this.WriteOperate = null;
        return a;
    }

    public virtual bool CheckValueString(Text text)
    {
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
        rangeStart = range.Index;
        long rangeEnd;
        rangeEnd = range.Index + range.Count;

        uint quote;
        quote = (uint)stringComp.Char(classInfra.Quote, 0);

        uint oc;
        oc = textInfra.DataCharGet(data, rangeStart);
        if (!(oc == quote))
        {
            return false;
        }
        oc = textInfra.DataCharGet(data, rangeEnd - 1);
        if (!(oc == quote))
        {
            return false;
        }

        uint backSlash;
        backSlash = (uint)stringComp.Char(classInfra.BackSlash, 0);
        uint newLine;
        newLine = (uint)stringComp.Char(classInfra.NewLine, 0);

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

            uint c;
            c = textInfra.DataCharGet(data, index);

            bool b;
            b = (c == backSlash);
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

                uint u;
                u = textInfra.DataCharGet(data, indexA);

                bool bba;
                bba = false;                
                if (u == quote)
                {
                    bba = true;
                }
                if (u == 'n')
                {
                    bba = true;
                }
                if (u == backSlash)
                {
                    bba = true;
                }
                if (u == 'u')
                {
                    long k;
                    k = j + countA;
                    if (!(k < count))
                    {
                        return false;
                    }
                    long indexAa;
                    indexAa = start + j + 1;
                    long iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        long oa;
                        oa = indexAa + iA;
                        uint ua;
                        ua = textInfra.DataCharGet(data, oa);

                        if (!(textInfra.IsDigit(ua) | textInfra.IsHexAlpha(ua, false)))
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
                if (c == quote)
                {
                    return false;
                }                
            }
            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteValueString(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        Infra classInfra;
        classInfra = this.ClassInfra;
        StringComp stringComp;
        stringComp = this.StringComp;

        Data data;
        data = text.Data;
        InfraRange range;
        range = text.Range;
        long kk;
        kk = range.Count;

        uint backSlash;
        backSlash = (uint)stringComp.Char(classInfra.BackSlash, 0);
        uint quote;
        quote = (uint)stringComp.Char(classInfra.Quote, 0);
        uint newLine;
        newLine = (uint)stringComp.Char(classInfra.NewLine, 0);
        
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

            uint c;
            c = textInfra.DataCharGet(data, index);

            bool b;
            b = (c == backSlash);
            if (b)
            {
                long j;
                j = i + 1;

                bool bb;
                bb = (j < count);
                if (bb)
                {
                    long indexA;
                    indexA = start + j;
                    uint u;
                    u = textInfra.DataCharGet(data, indexA);

                    uint escapeValue;
                    escapeValue = 0;
                    if (u == quote)
                    {
                        escapeValue = u;
                    }
                    if (u == 'n')
                    {
                        escapeValue = newLine;
                    }
                    if (u == backSlash)
                    {
                        escapeValue = u;
                    }
                    if (u == 'u')
                    {
                        long ka;
                        ka = 0;
                        long indexAa;
                        indexAa = start + j + 1;
                        long iA;
                        iA = 0;
                        while (iA < countA)
                        {
                            long oa;
                            oa = indexAa + iA;
                            uint ua;
                            ua = textInfra.DataCharGet(data, oa);

                            long od;
                            od = textInfra.DigitValue(ua, 16, false);

                            long na;
                            na = countA - 1 - iA;

                            int shiftCount;
                            shiftCount = (int)(na * 4);

                            long nn;
                            nn = od << shiftCount;

                            ka = ka | nn;

                            iA = iA + 1;
                        }

                        uint uu;
                        uu = (uint)ka;

                        escapeValue = uu;

                        i = i + countA;
                    }

                    this.ExecuteValueChar(escapeValue);

                    i = i + 1;
                }
            }

            if (!b)
            {
                this.ExecuteValueChar(c);
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteValueChar(uint oc)
    {
        this.WriteOperate.ExecuteChar(oc);
        return true;
    }
}