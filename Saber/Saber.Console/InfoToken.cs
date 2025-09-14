namespace Saber.Console;

public class InfoToken : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.PrintChar = this.CreatePrintChar();

        this.SComma = this.S(",");
        this.SBraceCurveLite = this.S("{");
        this.SBraceCurveRite = this.S("}");
        this.SBraceRightLite = this.S("[");
        this.SBraceRightRite = this.S("]");
        this.SSpaceColonSpace = this.S(" : ");
        this.SNull = this.S("null");
        this.SHexPre = this.S("0h");
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
    protected virtual String SBraceCurveLite { get; set; }
    protected virtual String SBraceCurveRite { get; set; }
    protected virtual String SBraceRightLite { get; set; }
    protected virtual String SBraceRightRite { get; set; }
    protected virtual String SSpaceColonSpace { get; set; }
    protected virtual String SNull { get; set; }
    protected virtual String SHexPre { get; set; }

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
}