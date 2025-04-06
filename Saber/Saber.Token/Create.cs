namespace Saber.Token;

public class Create : ClassCreate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.CountOperate = this.CreateCountOperate();
        this.SetOperate = this.CreateSetOperate();
        return true;
    }

    protected virtual CountCreateOperate CreateCountOperate()
    {
        CountCreateOperate a;
        a = new CountCreateOperate();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual SetCreateOperate CreateSetOperate()
    {
        SetCreateOperate a;
        a = new SetCreateOperate();
        a.Create = this;
        a.Init();
        return a;
    }

    public virtual Array Source { get; set; }
    public virtual Result Result { get; set; }
    public virtual CreateArg Arg { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountCreateOperate CountOperate { get; set; }
    protected virtual SetCreateOperate SetOperate { get; set; }
    protected virtual CreateOperate Operate { get; set; }
    protected virtual Array Code { get; set; }
    protected virtual Source SourceItem { get; set; }
    protected virtual long Row { get; set; }

    public override bool Execute()
    {
        this.Result = new Result();
        this.Result.Init();

        this.Code = this.CreateCodeArray();

        this.Result.Code = this.Code;
        this.Result.Error = this.ListInfra.ArrayCreate(0);

        this.Arg = new CreateArg();
        this.Arg.Init();

        CreateArg arg;
        arg = this.Arg;

        arg.CodeCountData = new Data();
        arg.CodeCountData.Count = this.Code.Count * sizeof(ulong) * 2;
        arg.CodeCountData.Init();

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        arg.TokenArray = this.ListInfra.ArrayCreate(arg.TokenIndex);
        arg.CommentArray = this.ListInfra.ArrayCreate(arg.CommentIndex);

        this.ExecuteCreateToken();
        this.ExecuteCreateComment();
        this.ExecuteCodeArraySet();

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Arg = null;
        this.Operate = null;
        return true;
    }

    public virtual bool ResetStage()
    {
        this.Arg.TokenIndex = 0;
        this.Arg.CommentIndex = 0;
        return true;
    }

    protected virtual Array CreateCodeArray()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.Source.Count);

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Code a;
            a = new Code();
            a.Init();

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    protected virtual bool ExecuteCreateToken()
    {
        Array array;
        array = this.Arg.TokenArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Token a;
            a = new Token();
            a.Init();
            a.Range = new Range();
            a.Range.Init();

            array.SetAt(i, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateComment()
    {
        Array array;
        array = this.Arg.CommentArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Comment a;
            a = new Comment();
            a.Init();
            a.Range = new Range();
            a.Range.Init();

            array.SetAt(i, a);

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
        codeArray = this.Code;
        Data data;
        data = this.Arg.CodeCountData;

        Array tokenArray;
        Array commentArray;
        tokenArray = this.Arg.TokenArray;
        commentArray = this.Arg.CommentArray;

        long kaa;
        kaa = sizeof(ulong);

        long totalToken;
        long totalComment;
        totalToken = 0;
        totalComment = 0;

        long count;
        count = codeArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Code code;
            code = codeArray.GetAt(i) as Code;

            long kk;
            kk = i;
            kk = kk * 2;
            long ka;
            ka = kk * kaa;
            long kb;
            kb = (kk + 1) * kaa;

            long tokenCount;
            long commentCount;
            tokenCount = infraInfra.DataIntGet(data, ka);
            commentCount = infraInfra.DataIntGet(data, kb);

            code.Token = listInfra.ArrayCreate(tokenCount);
            code.Comment = listInfra.ArrayCreate(commentCount);

            listInfra.ArrayCopy(code.Token, 0, tokenArray, totalToken, tokenCount);
            listInfra.ArrayCopy(code.Comment, 0, commentArray, totalComment, commentCount);

            totalToken = totalToken + tokenCount;
            totalComment = totalComment + commentCount;

            i = i + 1;
        }

        return true;
    }

    public virtual bool ExecuteStage()
    {
        long count;
        count = this.Code.Count;

        long i;
        i = 0;
        while (i < count)
        {
            this.SourceItem = this.Source.GetAt(i) as Source;

            this.Operate.ExecuteCodeStart(i);

            this.ExecuteCode();

            this.Operate.ExecuteCodeEnd(i);

            i = i + 1;
        }

        this.SourceItem = null;
        return true;
    }

    protected virtual bool ExecuteCode()
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        TextForm textForm;
        textForm = this.TForm;

        Array sourceText;
        sourceText = this.SourceItem.Text;

        Range range;
        range = this.Range;

        long charHash;
        long charSpace;
        long charQuote;
        long charNext;
        long charLine;
        charHash = this.Char(this.ClassInfra.TextHash);
        charSpace = this.Char(this.ClassInfra.TextSpace);
        charQuote = this.Char(this.ClassInfra.TextQuote);
        charNext = this.Char(this.ClassInfra.TextNext);
        charLine = this.Char(this.ClassInfra.TextLine);

        this.Reset();

        long count;
        count = sourceText.Count;

        long i;
        i = 0;

        while (i < count)
        {
            Text line;
            line = sourceText.GetAt(i) as Text;

            Data data;
            data = line.Data;

            long start;
            start = line.Range.Index;

            long colCount;
            colCount = line.Range.Count;

            long j;
            j = 0;

            while (j < colCount)
            {
                bool valid;
                valid = false;

                long n;
                n = textInfra.DataCharGet(data, start + j);

                n = textForm.Execute(n);

                if (n == charHash)
                {
                    this.EndToken(j);

                    this.Row = i;
                    range.Index = j;
                    range.Count = classInfra.Count(j, colCount);
                    this.AddComment();

                    j = colCount;

                    this.Reset();

                    valid = true;
                }

                if (n == charSpace)
                {
                    this.EndToken(j);

                    j = j + 1;

                    this.Reset();

                    valid = true;
                }

                if (n == charQuote)
                {
                    this.EndToken(j);

                    this.Row = i;
                    range.Index = j;

                    long ka;
                    ka = j + 1;

                    bool b;
                    b = false;

                    while (!b & ka < colCount)
                    {
                        long na;
                        na = textInfra.DataCharGet(data, start + ka);

                        na = textForm.Execute(na);

                        bool ba;
                        ba = (na == charQuote);
                        if (ba)
                        {
                            b = true;
                        }

                        if (!b)
                        {
                            bool bb;
                            bb = (na == charNext);
                            if (bb)
                            {
                                long kb;
                                kb = ka + 1;
                                if (kb < colCount)
                                {
                                    ka = kb;
                                }
                            }
                        }
                        ka = ka + 1;
                    }
                    range.Count = classInfra.Count(j, ka);
                    this.AddToken();

                    j = ka;

                    this.Reset();

                    valid = true;
                }

                if (textInfra.Alpha(n, false) | textInfra.Alpha(n, true) | textInfra.Digit(n) | n == charLine)
                {
                    if (this.NullRange())
                    {
                        this.Row = i;
                        range.Index = j;
                    }

                    j = j + 1;

                    valid = true;
                }

                if (!valid)
                {
                    this.EndToken(j);

                    this.Row = i;
                    range.Index = j;
                    range.Count = 1;

                    this.AddToken();

                    j = j + 1;

                    this.Reset();
                }
            }

            this.EndToken(j);

            this.Reset();

            i = i + 1;
        }

        return true;
    }

    protected virtual bool AddToken()
    {
        this.Operate.ExecuteToken(this.Row, this.Range);
        return true;
    }

    protected virtual bool AddComment()
    {
        this.Operate.ExecuteComment(this.Row, this.Range);
        return true;
    }

    protected virtual bool EndToken(long col)
    {
        if (!this.NullRange())
        {
            long count;
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