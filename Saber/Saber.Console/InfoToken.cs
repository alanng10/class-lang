namespace Saber.Console;

public class InfoToken : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.PrintChar = this.CreatePrintChar();

        this.SComma = this.S(",");
        this.SQuote = this.S("\"");
        this.SBraceCurveLite = this.S("{");
        this.SBraceCurveRite = this.S("}");
        this.SBraceRightLite = this.S("[");
        this.SBraceRightRite = this.S("]");
        this.SSpaceColonSpace = this.S(" : ");
        this.SNextQuote = this.S("\\\"");
        this.SNextN = this.S("\\n");
        this.SNextU = this.S("\\u");
        this.SNull = this.S("null");
        this.SHexPre = this.S("0h");
        this.SCode = this.S("Code");
        this.SToken = this.S("Token");
        this.SComment = this.S("Comment");
        this.SRow = this.S("Row");
        this.SRange = this.S("Range");
        this.SIndex = this.S("Index");
        this.SCount = this.S("Count");
        return true;
    }

    protected virtual PrintChar CreatePrintChar()
    {
        PrintChar a;
        a = new PrintChar();
        a.Init();
        return a;
    }

    protected virtual PrintChar PrintChar { get; set; }
    protected virtual long Space { get; set; }
    protected virtual String SComma { get; set; }
    protected virtual String SQuote { get; set; }
    protected virtual String SBraceCurveLite { get; set; }
    protected virtual String SBraceCurveRite { get; set; }
    protected virtual String SBraceRightLite { get; set; }
    protected virtual String SBraceRightRite { get; set; }
    protected virtual String SSpaceColonSpace { get; set; }
    protected virtual String SNextQuote { get; set; }
    protected virtual String SNextN { get; set; }
    protected virtual String SNextU { get; set; }
    protected virtual String SNull { get; set; }
    protected virtual String SHexPre { get; set; }
    protected virtual String SCode { get; set; }
    protected virtual String SToken { get; set; }
    protected virtual String SComment { get; set; }
    protected virtual String SRow { get; set; }
    protected virtual String SRange { get; set; }
    protected virtual String SIndex { get; set; }
    protected virtual String SCount { get; set; }

    protected virtual bool Start(String name)
    {
        this.Add(name).AddLine();
        this.AddSpace().Add(this.SBraceCurveLite).AddLine();

        this.Space = this.Space + 4;
        return true;
    }

    protected virtual bool End()
    {
        this.Space = this.Space - 4;

        this.AddSpace().Add(this.SBraceCurveRite).Add(this.SComma).AddLine();
        return true;
    }

    protected virtual bool StartArray()
    {
        this.Add(this.SBraceRightLite).AddLine();

        this.Space = this.Space + 4;
        return true;
    }

    protected virtual bool EndArray()
    {
        this.Space = this.Space - 4;

        this.AddSpace().Add(this.SBraceRightRite).Add(this.SComma).AddLine();
        return true;
    }

    protected virtual bool FieldStart(String name)
    {
        this.AddSpace().Add(name).Add(this.SSpaceColonSpace);
        this.Space = this.Space + this.StringCount(name) + 3;
        return true;
    }

    protected virtual bool FieldEnd(String name)
    {
        this.Space = this.Space - (this.StringCount(name) + 3);
        return true;
    }

    protected virtual bool AddBoolValue(bool value)
    {
        this.AddBool(value).Add(this.SComma).AddLine();
        return true;
    }

    protected virtual bool AddIntValue(long value)
    {
        this.Add(this.SHexPre).AddIntHex(value).Add(this.SComma).AddLine();
        return true;
    }

    protected virtual bool AddStringValue(String value)
    {
        this.Add(this.SQuote);

        long count;
        count = this.StringCount(value);

        long i;
        i = 0;
        while (i < count)
        {
            long n;
            n = this.StringComp.Char(value, i);

            bool b;
            b = false;

            if (!b)
            {
                if (n == '\"')
                {
                    this.Add(this.SNextQuote);
                    b = true;
                }
            }
            if (!b)
            {
                if (n == '\n')
                {
                    this.Add(this.SNextN);
                    b = true;
                }
            }
            if (!b)
            {
                if (!this.PrintChar.Get(n))
                {
                    this.Add(this.SNextU);

                    long alphaStart;
                    alphaStart = 'a';

                    long countA;
                    countA = 8;
                    long iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        long shift;
                        shift = (countA - 1) - iA;
                        shift = shift * 4;

                        int shiftK;
                        shiftK = (int)shift;

                        long ka;
                        ka = n >> shiftK;
                        ka = ka & 0xf;

                        long ke;
                        ke = this.TextInfra.DigitChar(ka, alphaStart);
                        
                        this.AddChar(ke);

                        iA = iA + 1;
                    }

                    b = true;
                }
            }
            if (!b)
            {
                this.AddChar(n);
            }

            i = i + 1;
        }

        this.Add(this.SQuote).Add(this.SComma).AddLine();
        return true;
    }

    protected virtual InfoToken AddSpace()
    {
        long count;
        count = this.Space;
        long i;
        i = 0;
        while (i < count)
        {
            this.Add(this.SSpace);

            i = i + 1;
        }

        return this;
    }

    protected virtual bool Null()
    {
        this.Add(this.SNull).Add(this.SComma).AddLine();
        return true;
    }

    public virtual bool ExecuteBool(bool value)
    {
        this.AddBoolValue(value);
        return true;
    }

    public virtual bool ExecuteInt(long value)
    {
        if (value == -1)
        {
            this.Null();
            return true;
        }
        this.AddIntValue(value);
        return true;
    }

    public virtual bool ExecuteString(String value)
    {
        if (value == null)
        {
            this.Null();
            return true;
        }
        this.AddStringValue(value);
        return true;
    }

    public virtual String Execute(Code code)
    {
        this.AddClear();

        this.ExecuteCode(code);

        String a;
        a = this.AddResult();
        return a;
    }

    public virtual bool ExecuteCode(Code code)
    {
        if (code == null)
        {
            this.Null();
            return true;
        }

        this.Start(this.SCode);

        this.FieldStart(this.SToken);

        this.StartArray();

        long count;
        count = code.Token.Count;
        long i;
        i = 0;
        while (i < count)
        {
            TokenToken token;
            token = code.Token.Get(i) as TokenToken;

            this.AddSpace();
            this.ExecuteToken(token);

            i = i + 1;
        }
        this.EndArray();

        this.FieldEnd(this.SToken);

        this.FieldStart(this.SComment);

        this.StartArray();

        count = code.Comment.Count;
        i = 0;
        while (i < count)
        {
            TokenComment comment;
            comment = code.Comment.Get(i) as TokenComment;

            this.AddSpace();
            this.ExecuteComment(comment);

            i = i + 1;
        }
        this.EndArray();

        this.FieldEnd(this.SComment);

        this.End();
        return true;
    }

    public virtual bool ExecuteToken(TokenToken token)
    {
        if (token == null)
        {
            this.Null();
            return true;
        }

        this.Start(this.SToken);

        this.FieldStart(this.SRow);
        this.ExecuteInt(token.Row);
        this.FieldEnd(this.SRow);

        this.FieldStart(this.SRange);
        this.ExecuteRange(token.Range);
        this.FieldEnd(this.SRange);

        this.End();
        return true;
    }

    public virtual bool ExecuteComment(TokenComment comment)
    {
        if (comment == null)
        {
            this.Null();
            return true;
        }

        this.Start(this.SComment);

        this.FieldStart(this.SRow);
        this.ExecuteInt(comment.Row);
        this.FieldEnd(this.SRow);

        this.FieldStart(this.SRange);
        this.ExecuteRange(comment.Range);
        this.FieldEnd(this.SRange);

        this.End();
        return true;
    }
}