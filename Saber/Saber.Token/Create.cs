namespace Saber.Token;

public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
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
    protected virtual CountCreateOperate CountOperate { get; set; }
    protected virtual SetCreateOperate SetOperate { get; set; }
    protected virtual CreateOperate Operate { get; set; }
    protected virtual Array CodeArray { get; set; }
    protected virtual Source SourceItem { get; set; }
    protected virtual long Row { get; set; }

    public override bool Execute()
    {
        this.Result = new Result();
        this.Result.Init();

        this.CodeArray = this.CreateCodeArray();

        this.Result.Code = this.CodeArray;
        this.Result.Error = this.ListInfra.ArrayCreate(0);

        this.Arg = new CreateArg();
        this.Arg.Init();

        CreateArg arg;
        arg = this.Arg;

        arg.CodeCountData = new Data();
        arg.CodeCountData.Count = this.CodeArray.Count * 2 * sizeof(ulong);
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
        codeArray = this.CodeArray;
        Data codeCountData;
        codeCountData = this.Arg.CodeCountData;

        Array tokenArray;
        Array commentArray;
        tokenArray = this.Arg.TokenArray;
        commentArray = this.Arg.CommentArray;

        long oa;
        oa = sizeof(ulong);

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

            long ob;
            ob = i;
            ob = ob * 2;
            long oe;
            oe = ob * oa;
            long of;
            of = (ob + 1) * oa;
            long tokenCount;
            long commentCount;
            tokenCount = infraInfra.DataIntGet(codeCountData, oe);
            commentCount = infraInfra.DataIntGet(codeCountData, of);

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
        count = this.CodeArray.Count;

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
        this.Row = -1;
        this.Range.Index = -1;
        this.Range.Count = -1;
        return true;
    }

    protected virtual bool ExecuteCode()
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        this.Reset();

        TextForm textForm;
        textForm = this.TForm;

        Array sourceText;
        sourceText = this.SourceItem.Text;

        Range range;
        range = this.Range;

        long kaa;
        kaa = '_';

        long row;
        row = 0;
        long col;
        col = 0;

        long count;
        count = sourceText.Count;
        while (row < count)
        {
            Text line;
            line = sourceText.GetAt(row) as Text;
            Data data;
            data = line.Data;

            Range ke;
            ke = line.Range;

            long start;
            start = ke.Index;

            long colCount;
            colCount = ke.Count;

            col = 0;

            while (col < colCount)
            {
                bool valid;
                valid = false;

                long n;
                n = textInfra.DataCharGet(data, start + col);

                n = textForm.Execute(n);

                if (n == '#')
                {
                    this.EndToken(col);
                    this.Row = row;
                    range.Index = col;
                    range.Count = classInfra.Count(col, colCount);
                    this.AddComment();

                    col = colCount;
                    this.Reset();

                    valid = true;
                }

                if (n == ' ')
                {
                    this.EndToken(col);

                    col = col + 1;

                    this.Reset();

                    valid = true;
                }

                if (n == '\"')
                {
                    this.EndToken(col);
                    this.Row = row;
                    range.Index = col;

                    long cc;
                    cc = col + 1;
                    bool b;
                    b = false;
                    while (!b & cc < colCount)
                    {
                        long oc;
                        oc = textInfra.DataCharGet(data, start + cc);

                        oc = textForm.Execute(oc);

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
                                long uu;
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

                    valid = true;
                }

                if (textInfra.Alpha(n, false) | textInfra.Alpha(n, true) | textInfra.Digit(n) | n == kaa)
                {
                    if (this.NullRange())
                    {
                        this.Row = row;
                        range.Index = col;
                    }

                    col = col + 1;

                    valid = true;
                }

                if (!valid)
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