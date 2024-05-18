namespace Class.Infra;

public class StringValueWrite : Any
{
    public override bool Init()
    {
        base.Init();
        
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = Infra.This;

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
    public virtual CountWriteOperate CountWriteOperate { get; set; }
    public virtual AddWriteOperate AddWriteOperate { get; set; }

    public virtual WriteOperate WriteOperate { get; set; }

    public virtual Data Data { get; set; }
    public virtual int Index { get; set; }

    public virtual string Value(Text text)
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

        int count;
        count = this.Index;
        this.Data = new Data();
        this.Data.Count = count * sizeof(short);
        this.Data.Init();

        this.WriteOperate = this.AddWriteOperate;
        this.Index = 0;
        this.ExecuteValueString(text);

        Text oa;
        oa = new Text();
        oa.Init();
        oa.Range = new InfraRange();
        oa.Range.Init();
        oa.Data = this.Data;
        oa.Range.Index = 0;
        oa.Range.Count = count;
        
        string a;
        a = this.TextInfra.StringCreate(oa);

        this.Data = null;
        this.WriteOperate = null;
        return a;
    }

    public virtual bool CheckValueString(Text text)
    {
        InfraRange range;
        range = text.Range;
        int kk;
        kk = range.Count;
        if (kk < 2)
        {
            return false;
        }

        Data data;
        data = text.Data;
        int rangeStart;
        rangeStart = range.Index;
        int rangeEnd;
        rangeEnd = range.Index + range.Count;

        char quote;
        quote = this.ClassInfra.Quote[0];

        TextInfra textInfra;
        textInfra = this.TextInfra;

        char oc;
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

        char backSlash;
        backSlash = this.ClassInfra.BackSlash[0];
        char tab;
        tab = this.ClassInfra.Tab[0];
        char newLine;
        newLine = this.ClassInfra.NewLine[0];

        int countA;
        countA = 4;

        int count;
        count = kk - 2;
        int start;
        start = rangeStart + 1;
        int index;
        int indexA;
        char c;
        bool b;
        bool bb;
        bool bba;
        int j;
        char u;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + i;

            c = textInfra.DataCharGet(data, index);

            b = (c == backSlash);
            if (b)
            {
                j = i + 1;
                bb = (j < count);
                if (!bb)
                {
                    return false;
                }
                indexA = start + j;

                u = textInfra.DataCharGet(data, indexA);

                bba = false;                
                if (u == quote)
                {
                    bba = true;
                }
                if (u == 't')
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
                    int k;
                    k = j + countA;
                    if (!(k < count))
                    {
                        return false;
                    }
                    int indexAa;
                    indexAa = start + j + 1;
                    int iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        int oa;
                        oa = indexAa + iA;
                        char ua;
                        ua = textInfra.DataCharGet(data, oa);

                        if (!(textInfra.IsDigit(ua) | textInfra.IsHexLetter(ua)))
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
                bb = (c == quote);
                if (bb)
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
        Data data;
        data = text.Data;
        InfraRange range;
        range = text.Range;
        int kk;
        kk = range.Count;

        TextInfra textInfra;
        textInfra = this.TextInfra;
        Infra classInfra;
        classInfra = this.ClassInfra;

        char backSlash;
        backSlash = classInfra.BackSlash[0];
        char quote;
        quote = classInfra.Quote[0];
        char tab;
        tab = classInfra.Tab[0];
        char newLine;
        newLine = classInfra.NewLine[0];
        char uuu;
        uuu = (char)0;
        int count;
        count = kk - 2;
        int start;
        start = range.Index + 1;
        int index;
        int indexA;
        char c;
        bool b;
        bool bb;
        int j;
        char u;
        char escapeValue;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + i;

            c = textInfra.DataCharGet(data, index);

            b = (c == backSlash);
            if (b)
            {
                j = i + 1;

                bb = (j < count);
                if (bb)
                {
                    indexA = start + j;
                    u = textInfra.DataCharGet(data, indexA);

                    escapeValue = uuu;                    
                    if (u == quote)
                    {
                        escapeValue = u;
                    }
                    if (u == 't')
                    {
                        escapeValue = tab;
                    }
                    if (u == 'n')
                    {
                        escapeValue = newLine;
                    }
                    if (u == backSlash)
                    {
                        escapeValue = u;
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

    protected virtual bool ExecuteValueChar(char oc)
    {
        this.WriteOperate.ExecuteChar(oc);
        return true;
    }

    public virtual string EscapeString(string a)
    {
        string k;
        k = a;
        k = k.Replace("\\", "\\\\");
        k = k.Replace("\"", "\\\"");
        k = k.Replace("\t", "\\t");
        k = k.Replace("\n", "\\n");
        string ret;
        ret = k;
        return ret;
    }
}