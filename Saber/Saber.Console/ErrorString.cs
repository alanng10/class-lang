namespace Saber.Console;

public class ErrorString : TextAdd
{
    public override bool Init()
    {
        base.Init();

        this.StartPos = this.CreateStartPos();
        this.EndPos = this.CreateEndPos();
        this.Bord = this.CreateBord();

        this.SKind = this.S("Kind");
        this.SName = this.S("Name");
        this.SRange = this.S("Range");
        this.SSource = this.S("Source");
        this.SRow = this.S("Row");
        this.SCol = this.S("Col");
        this.SComma = this.S(",");
        this.SColon = this.S(":");
        this.SHyphen = this.S("-");
        this.SBraceRoundLite = this.S("(");
        this.SBraceRoundRite = this.S(")");
        return true;
    }

    protected virtual Pos CreateStartPos()
    {
        return this.CreatePos();
    }

    protected virtual Pos CreateEndPos()
    {
        return this.CreatePos();
    }

    protected virtual Pos CreatePos()
    {
        Pos a;
        a = new Pos();
        a.Init();
        return a;
    }

    protected virtual String CreateBord()
    {
        return this.StringComp.CreateChar('-', 50);
    }

    public virtual bool RangePos { get; set; }
    public virtual Array CodeArray { get; set; }
    public virtual Array SourceArray { get; set; }
    protected virtual Pos StartPos { get; set; }
    protected virtual Pos EndPos { get; set; }
    protected virtual String Bord { get; set; }
    protected virtual String SKind { get; set; }
    protected virtual String SName { get; set; }
    protected virtual String SRange { get; set; }
    protected virtual String SSource { get; set; }
    protected virtual String SRow { get; set; }
    protected virtual String SCol { get; set; }
    protected virtual String SComma { get; set; }
    protected virtual String SColon { get; set; }
    protected virtual String SHyphen { get; set; }
    protected virtual String SBraceRoundLite { get; set; }
    protected virtual String SBraceRoundRite { get; set; }

    public virtual String Execute(Error error)
    {
        this.AddClear();

        this.AddBord();

        this.AddField(this.SKind, this.KindString(error));

        bool b;
        b = (error.Source == -1);

        if (b)
        {
            String kk;
            kk = error.Name;
            
            if (!(kk == null))
            {
                this.AddField(this.SName, kk);
            }
        }
        if (!b)
        {
            bool ba;
            ba = this.RangePos;

            String kaa;
            kaa = null;
            if (ba)
            {
                kaa = this.RangePosString(error);
            }
            if (!ba)
            {
                kaa = this.RangeString(error);
            }

            this.AddField(this.SRange, kaa);

            this.AddField(this.SSource, this.SourceString(error));
        }

        this.AddBord();

        String a;
        a = this.AddResult();

        return a;
    }

    protected virtual bool AddBord()
    {
        this.Add(this.Bord).AddLine();
        return true;
    }

    protected virtual bool AddField(String index, String value)
    {
        this.Add(index).Add(this.SColon).Add(this.SSpace).Add(value).AddLine();
        return true;
    }

    protected virtual String KindString(Error error)
    {
        String a;
        a = error.Kind.Text;
        return a;
    }

    protected virtual String RangePosString(Error error)
    {
        StringAdd kk;
        kk = this.StringAdd;

        StringAdd k;
        k = new StringAdd();
        k.Init();

        this.StringAdd = k;

        Range range;
        range = error.Range;

        Code code;
        code = this.CodeArray.GetAt(error.Source) as Code;

        Array tokenArray;
        tokenArray = code.Token;

        this.PosRange(this.StartPos, this.EndPos, range, tokenArray);

        this.AddClear();

        this.AddPos(this.StartPos);

        this.Add(this.SSpace);
        this.Add(this.SHyphen);
        this.Add(this.SSpace);

        this.AddPos(this.EndPos);

        String a;
        a = this.AddResult();

        this.StringAdd = kk;

        return a;
    }

    protected virtual bool AddPos(Pos pos)
    {
        String row;
        String col;
        row = this.StringInt(pos.Row + 1);
        col = this.StringInt(pos.Col + 1);

        this.Add(this.SBraceRoundLite);
        this.Add(this.SRow);
        this.Add(this.SSpace);
        this.Add(row);
        this.Add(this.SComma);
        this.Add(this.SSpace);
        this.Add(this.SCol);
        this.Add(this.SSpace);
        this.Add(col);
        this.Add(this.SBraceRoundRite);

        return true;
    }

    public virtual bool PosRange(Pos resultStart, Pos resultEnd, Range range, Array tokenArray)
    {
        long tokenCount;
        tokenCount = tokenArray.Count;

        long start;
        long end;
        start = range.Start;
        end = range.End;

        long startRow;
        long startCol;
        long endRow;
        long endCol;
        startRow = 0;
        startCol = 0;
        endRow = 0;
        endCol = 0;

        TokenToken token;

        InfraRange tokenRange;

        bool b;
        b = (start == tokenCount);
        if (b)
        {
            bool ba;
            ba = (tokenCount == 0);
            if (ba)
            {
                startRow = 0;
                startCol = 0;
                endRow = 0;
                endCol = 0;
            }
            if (!ba)
            {
                long prev;
                prev = start - 1;

                token = tokenArray.GetAt(prev) as TokenToken;

                tokenRange = token.Range;

                startRow = token.Row;
                startCol = tokenRange.Index + tokenRange.Count;
                endRow = startRow;
                endCol = startCol;
            }
        }
        if (!b)
        {
            token = tokenArray.GetAt(start) as TokenToken;

            tokenRange = token.Range;

            startRow = token.Row;
            startCol = tokenRange.Index;

            bool bb;
            bb = (start < end);
            if (bb)
            {
                token = tokenArray.GetAt(end - 1) as TokenToken;

                tokenRange = token.Range;

                endRow = token.Row;
                endCol = tokenRange.Index + tokenRange.Count;
            }
            if (!bb)
            {
                endRow = startRow;
                endCol = startCol;
            }
        }

        resultStart.Row = startRow;
        resultStart.Col = startCol;

        resultEnd.Row = endRow;
        resultEnd.Col = endCol;
        return true;
    }

    protected virtual String RangeString(Error error)
    {
        StringAdd hh;
        hh = this.StringAdd;

        Range range;
        range = error.Range;

        StringAdd h;
        h = new StringAdd();
        h.Init();

        this.StringAdd = h;

        String ka;
        ka = this.StringInt(range.Start);

        String kb;
        kb = this.StringInt(range.End);

        this.AddClear();

        this.Add(this.SBraceRoundLite);
        this.Add(ka);
        this.Add(this.SComma);
        this.Add(this.SSpace);
        this.Add(kb);
        this.Add(this.SBraceRoundRite);

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

        return a;
    }

    protected virtual String SourceString(Error error)
    {
        Source k;
        k = this.SourceArray.GetAt(error.Source) as Source;

        String a;
        a = k.Name;
        return a;
    }
}