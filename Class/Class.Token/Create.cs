namespace Class.Token;

public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.CountOperate = new CountCreateOperate();
        this.CountOperate.Create = this;
        this.CountOperate.Init();
        this.SetOperate = new SetCreateOperate();
        this.SetOperate.Create = this;
        this.SetOperate.Init();


        this.Range = new Range();
        this.Range.Init();
        return true;
    }

    public virtual Array Source { get; set; }
    public virtual Result Result { get; set; }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountCreateOperate CountOperate { get; set; }
    protected virtual SetCreateOperate SetOperate { get; set; }
    protected virtual CreateOperate Operate { get; set; }
    protected virtual Array CodeArray { get; set; }

    public virtual Code Code { get; set; }
    public virtual Source SourceItem { get; set; }
    public virtual int Row { get; set; }
    public virtual Range Range { get; set; }
    public virtual int TokenIndex { get; set; }
    public virtual Array TokenArray { get; set; }
    public virtual int InfoIndex { get; set; }
    public virtual Array InfoArray { get; set; }
    public virtual Data CodeCountData { get; set; }

    public override bool Execute()
    {
        this.Result = new Result();
        this.Result.Init();

        this.CodeArray = this.CodeArrayCreate();

        this.Result.Code = this.CodeArray;
        this.Result.Error = this.ListInfra.ArrayCreate(0);

        this.CodeCountData = new Data();
        this.CodeCountData.Count = this.CodeArray.Count * 2 * sizeof(uint);
        this.CodeCountData.Init();

        this.Operate = this.CountOperate;

        this.TokenIndex = 0;
        this.InfoIndex = 0;

        this.ExecuteStage();

        this.TokenArray = this.ListInfra.ArrayCreate(this.TokenIndex);
        this.InfoArray = this.ListInfra.ArrayCreate(this.InfoIndex);

        this.ExecuteTokenCreate();
        this.ExecuteInfoCreate();
        this.ExecuteCodeArraySet();

        this.Operate = this.SetOperate;

        this.TokenIndex = 0;
        this.InfoIndex = 0;
        
        this.ExecuteStage();

        this.TokenArray = null;
        this.InfoArray = null;
        this.CodeCountData = null;
        return true;
    }

    protected virtual bool ExecuteStage()
    {
        int count;
        count = this.CodeArray.Count;

        int i;
        i = 0;
        while (i < count)
        {
            Code code;
            code = (Code)this.CodeArray.Get(i);

            this.SourceItem = (Source)this.Source.Get(i);

            this.Operate.ExecuteCodeStart(i);

            this.ExecuteCode(code);

            this.Operate.ExecuteCodeEnd(i);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteCode(Code code)
    {
        this.Code = code;

        this.Reset();

        TextInfra textInfra;
        textInfra = this.TextInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Array sourceText;
        sourceText = this.SourceItem.Text;

        Range range;
        range = this.Range;

        int row;
        row = 0;
        int col;
        col = 0;

        int count;
        count = sourceText.Count;
        while (row < count)
        {
            Text line;
            line = (Text)sourceText.Get(row);
            Data data;
            data = line.Data;

            Range ke;
            ke = line.Range;
            
            int start;
            start = ke.Index;

            int colCount;
            colCount = ke.Count;

            col = 0;

            while (col < colCount)
            {
                bool isValid;
                isValid = false;

                char c;
                c = textInfra.DataCharGet(data, start + col);
                if (c == '#')
                {
                    this.EndToken(col);
                    this.Row = row;
                    range.Index = col;
                    range.Count = classInfra.Count(col, colCount);
                    this.AddComment();

                    col = colCount;
                    this.Reset();

                    isValid = true;
                }

                if (c == ' ')
                {
                    this.EndToken(col);

                    col = col + 1;

                    this.Reset();

                    isValid = true;
                }

                if (c == '\"')
                {
                    this.EndToken(col);
                    this.Row = row;
                    range.Index = col;

                    int cc;
                    cc = col + 1;
                    bool b;
                    b = false;
                    int uu;
                    while (!b & cc < colCount)
                    {
                        char oc;
                        oc = textInfra.DataCharGet(data, start + cc);
                        bool ba;
                        ba = (oc == '\"');
                        if (ba)
                        {
                            b = true;
                        }

                        if (!b)
                        {
                            bool bb;
                            bb = (oc == '\\');
                            if (bb)
                            {
                                uu = cc + 1;
                                if (uu < colCount)
                                {
                                    cc = cc + 1;
                                }
                            }
                        }
                        cc = cc + 1;
                    }
                    range.Count = classInfra.Count(col, cc);
                    this.AddToken();

                    col = cc;

                    this.Reset();

                    isValid = true;
                }

                if (textInfra.IsLetter(c, false) | textInfra.IsLetter(c, true) | textInfra.IsDigit(c) | c == '_')
                {
                    if (this.NullRange())
                    {
                        this.Row = row;
                        range.Index = col;
                    }

                    col = col + 1;

                    isValid = true;
                }

                if (!isValid)
                {
                    this.EndToken(col);

                    this.Row = row;
                    range.Index = col;
                    range.Count = 1;
                    
                    this.AddToken();

                    col = col + 1;

                    this.Reset();
                }
            }

            this.EndToken(col);

            this.Reset();

            row = row + 1;
        }
        
        return true;
    }

    protected virtual Array CodeArrayCreate()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.Source.Count);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Code code;
            code = new Code();
            code.Init();

            array.Set(i, code);

            i = i + 1;
        }

        return array;
    }

    protected virtual bool ExecuteTokenCreate()
    {
        Array array;
        array = this.TokenArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Token a;
            a = new Token();
            a.Init();
            a.Range = new Range();
            a.Range.Init();
            array.Set(i, a);
            
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteInfoCreate()
    {
        Array array;
        array = this.InfoArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Info a;
            a = new Info();
            a.Init();
            a.Range = new Range();
            a.Range.Init();
            array.Set(i, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCodeArraySet()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        ListInfra listInfra;
        listInfra = this.ListInfra;
        Array codeArray;
        codeArray = this.CodeArray;
        Data codeCountData;
        codeCountData = this.CodeCountData;

        int oa;
        oa = sizeof(uint);

        int totalToken;
        int totalInfo;
        totalToken = 0;
        totalInfo = 0;

        int count;
        count = codeArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Code code;
            code = (Code)codeArray.Get(i);

            long ob;
            ob = i;
            ob = ob * 2;
            long oe;
            oe = ob * oa;
            long of;
            of = (ob + 1) * oa;
            int tokenCount;
            int infoCount;
            tokenCount = (int)infraInfra.DataMidGet(codeCountData, oe);
            infoCount = (int)infraInfra.DataMidGet(codeCountData, of);

            code.Token = listInfra.ArrayCreate(tokenCount);
            code.Comment = listInfra.ArrayCreate(infoCount);

            listInfra.ArrayCopy(code.Token, 0, this.TokenArray, totalToken, tokenCount);
            listInfra.ArrayCopy(code.Comment, 0, this.InfoArray, totalInfo, infoCount);

            totalToken = totalToken + tokenCount;
            totalInfo = totalInfo + infoCount;

            i = i + 1;
        }

        return true;
    }

    protected virtual bool AddToken()
    {
        this.Operate.ExecuteToken();
        return true;
    }

    protected virtual bool AddComment()
    {
        this.Operate.ExecuteComment();
        return true;
    }

    protected virtual bool EndToken(int col)
    {
        if (!this.NullRange())
        {
            int count;
            count = this.ClassInfra.Count(this.Range.Index, col);
            this.Range.Count = count;
            this.AddToken();
        }
        return true;
    }

    protected virtual bool NullRange()
    {
        return this.Row == -1;
    }

    protected virtual bool Reset()
    {
        this.Row = -1;
        return true;
    }
}