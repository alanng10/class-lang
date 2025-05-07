namespace Saber.Console;

public class ErrorString : TextAdd
{
    public override bool Init()
    {
        base.Init();

        this.StartPos = new Pos();
        this.StartPos.Init();
        this.EndPos = new Pos();
        this.EndPos.Init();

        this.BorderLine = this.StringComp.CreateChar('-', 50);
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

    public virtual bool RangePos { get; set; }
    public virtual Array CodeArray { get; set; }
    protected virtual Pos StartPos { get; set; }
    protected virtual Pos EndPos { get; set; }
    protected virtual String BorderLine { get; set; }
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

        this.AddBorder();

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

        this.AddBorder();

        String a;
        a = this.AddResult();

        return a;
    }

    protected virtual bool AddBorder()
    {
        this.Add(this.BorderLine).AddLine();
        return true;
    }

    protected virtual bool AddField(String word, String value)
    {
        this.Add(word).Add(this.SColon).Add(this.SSpace).Add(value).AddLine();
        return true;
    }

    protected virtual String KindString(Error error)
    {
        ErrorKind errorKind;
        errorKind = error.Kind;
                
        String a;
        a = errorKind.Text;

        return a;
    }

    protected virtual String RangePosString(Error error)
    {
        StringAdd hh;
        hh = this.StringAdd;

        Range range;
        range = error.Range;

        StringAdd h;
        h = new StringAdd();
        h.Init();

        this.StringAdd = h;

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

        this.StringAdd = hh;

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

        bool ba;
        ba = (start == tokenCount);
        if (ba)
        {
            bool baa;
            baa = (tokenCount == 0);
            if (baa)
            {
                startRow = 0;
                startCol = 0;
                endRow = 0;
                endCol = 0;
            }
            if (!baa)
            {
                long previous;
                previous = start - 1;

                token = (TokenToken)tokenArray.GetAt(previous);

                tokenRange = token.Range;

                startRow = token.Row;
                startCol = tokenRange.Index + tokenRange.Count;
                endRow = startRow;
                endCol = startCol;
            }
        }
        if (!ba)
        {
            token = (TokenToken)tokenArray.GetAt(start);

            tokenRange = token.Range;

            startRow = token.Row;
            startCol = tokenRange.Index;

            bool bba;
            bba = (start < end);
            if (bba)
            {
                token = (TokenToken)tokenArray.GetAt(end - 1);

                tokenRange = token.Range;

                endRow = token.Row;
                endCol = tokenRange.Index + tokenRange.Count;
            }
            if (!bba)
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
        Source aa;
        aa = error.Source;

        String a;
        a = aa.Name;
        return a;
    }
}