namespace Z.Tool.TypeBoardSvg;

public class Gen : ToolBase
{
    public override bool Init()
    {
        base.Init();

        this.OutputFilePath = this.S("TypeBoard.svg");

        this.DigitButtonShiftChar = new Data();
        this.DigitButtonShiftChar.Count = 10 * sizeof(uint);
        this.DigitButtonShiftChar.Init();
        
        this.Index = 0;

        this.AddDigitButtonShiftChar('&');
        this.AddDigitButtonShiftChar('|');
        this.AddDigitButtonShiftChar('~');
        this.AddDigitButtonShiftChar('+');
        this.AddDigitButtonShiftChar('-');
        this.AddDigitButtonShiftChar('*');
        this.AddDigitButtonShiftChar('/');
        this.AddDigitButtonShiftChar('<');
        this.AddDigitButtonShiftChar('>');
        this.AddDigitButtonShiftChar('=');

        return true;
    }

    protected virtual String OutputFilePath { get; set; }

    protected virtual Data DigitButtonShiftChar { get; set; }

    protected virtual long Index { get; set; }

    protected virtual bool AddDigitButtonShiftChar(long n)
    {
        this.TextInfra.DataCharSet(this.DigitButtonShiftChar, this.Index, n);

        this.Index = this.Index + 1;
        return true;
    }

    public virtual long Execute()
    {
        String ua;
        ua = this.ToolInfra.StorageTextRead(this.S("ToolData/Svg.txt"));

        Text text;
        text = this.TextCreate(ua);

        this.AddClear();

        this.AddAlphaButtonList();

        this.AddDigitButtonList();

        this.AddSignButtonList();

        this.AddControlButtonList();

        String aa;
        aa = this.AddResult();

        Text k;
        k = text;
        k = this.Replace(k, "#DrawList#", aa);

        String output;
        output = this.StringCreate(k);

        this.ToolInfra.StorageTextWrite(this.OutputFilePath, output);

        return 0;
    }

    protected virtual bool AddAlphaButtonList()
    {
        long row;

        long startCol;

        long count;

        long letterIndex;
        letterIndex = 0;

        long aaa;
        aaa = 4;

        row = 2;

        startCol = 2;

        count = aaa;

        this.AddAlphaButtonRange(row, startCol, count, letterIndex);

        letterIndex = letterIndex + count;

        long aab;
        aab = 4;

        row = 3;

        startCol = 2;

        count = aab;

        this.AddAlphaButtonRange(row, startCol, count, letterIndex);

        letterIndex = letterIndex + count;

        long aac;
        aac = 5;

        row = 1;

        startCol = 1;

        count = aac;

        this.AddAlphaButtonRange(row, startCol, count, letterIndex);

        letterIndex = letterIndex + count;

        long aad;
        aad = 5;

        row = 1;

        startCol = aac + 1;

        count = aad;

        this.AddAlphaButtonRange(row, startCol, count, letterIndex);

        letterIndex = letterIndex + count;

        long aae;
        aae = 4;

        row = 3;

        startCol = aab + 2;

        count = aae;

        this.AddAlphaButtonRange(row, startCol, count, letterIndex);

        letterIndex = letterIndex + count;

        long aaf;
        aaf = 4;

        count = aaf;

        row = 2;

        startCol = aaa + 2;

        this.AddAlphaButtonRange(row, startCol, count, letterIndex);

        letterIndex = letterIndex + count;

        return true;
    }

    protected virtual bool AddAlphaButtonRange(long row, long startCol, long count, long letterIndex)
    {
        long i;
        i = 0;

        while (i < count)
        {
            long col;
            col = startCol + i;

            long uu;
            uu = 'A' + letterIndex + i;

            this.AddButton(uu, -1, row, col);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool AddDigitButtonList()
    {
        long row;
        row = 0;

        long startCol;
        startCol = 1;

        long count;
        count = 10;

        long i;
        i = 0;

        while (i < count)
        {
            long col;
            col = startCol + i;

            long uu;
            uu = '0' + i;

            uint shiftChar;
            shiftChar = this.TextInfra.DataCharGet(this.DigitButtonShiftChar, i);

            long ua;
            ua = shiftChar;

            this.AddButton(uu, ua, row, col);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool AddSignButtonList()
    {
        this.AddButton('(', '{', 2, 1);

        this.AddButton(')', '}', 2, 10);

        this.AddButton(',', '[', 3, 1);

        this.AddButton('.', ']', 3, 10);

        this.AddButton('#', '^', 0, 0);

        this.AddButton('_', '?', 0, 11);

        this.AddButton(':', '\\', 1, 0);

        this.AddButton(';', '\"', 1, 11);
        return true;
    }

    protected virtual bool AddControlButtonList()
    {
        this.AddControlButton(this.S("Tab"), 2, 0);

        this.AddControlButton(this.S("Shift"), 3, 0);

        this.AddControlButton(this.S("Enter"), 2, 11);

        this.AddControlButton(this.S("Space"), 3, 11);
        return true;
    }

    protected virtual bool AddControlButton(String value, long row, long col)
    {
        long left;
        left = this.GetButtonLeft(col);

        long up;
        up = this.GetButtonUp(row);

        this.AddButtonRect(left, up);

        long l;
        l = left + 8;

        long u;
        u = up + 21;

        this.AddText(l, u, value, '\0', 11);

        this.AddLine();
        return true;
    }

    protected virtual bool AddButton(long defaultChar, long shiftChar, long row, long col)
    {
        long left;
        left = this.GetButtonLeft(col);

        long up;
        up = this.GetButtonUp(row);

        this.AddButtonRect(left, up);

        if (!(defaultChar == -1))
        {
            bool b;
            b = (shiftChar == -1);

            if (b)
            {
                long l;
                l = left + 10;

                long u;
                u = up + 24;

                this.AddText(l, u, null, defaultChar, 22);

                this.AddLine();
            }

            if (!b)
            {
                long l;
                long u;

                l = left + 9;

                u = up + 40;

                this.AddText(l, u, null, defaultChar, 16);

                this.AddLine();

                l = left + 9;

                u = up + 18;

                this.AddText(l, u, null, shiftChar, 16);

                this.AddLine();
            }
        }
        return true;
    }

    protected virtual bool AddButtonRect(long left, long up)
    {
        long width;
        width = this.ButtonWidth;

        long height;
        height = width;

        long horizontalRadius;
        horizontalRadius = this.ButtonCornerRadius;

        long verticalRadius;
        verticalRadius = horizontalRadius;

        this.AddRect(left, up, width, height, horizontalRadius, verticalRadius);

        this.AddLine();
        return true;
    }

    protected virtual long GetButtonLeft(long col)
    {
        return this.BoardLeft + col * (this.ButtonWidth + this.ButtonSpace);
    }

    protected virtual long GetButtonUp(long row)
    {
        return this.BoardUp + row * (this.ButtonWidth + this.ButtonSpace);
    }

    protected virtual long ButtonWidth
    {
        get
        {
            return 50;
        }
        set
        {
        }
    }

    protected virtual long ButtonSpace
    {
        get
        {
            return 8;
        }
        set
        {
        }
    }

    protected virtual long BoardLeft
    {
        get
        {
            return 20;
        }
        set
        {
        }
    }

    protected virtual long BoardUp
    {
        get
        {
            return 20;
        }
        set
        {
        }
    }

    protected virtual long ButtonCornerRadius
    {
        get
        {
            return 5;
        }
        set
        {
        }
    }

    protected virtual int NullInt
    {
        get
        {
            return -1;
        }
        set
        {
        }
    }

    protected virtual bool AddRect(long left, long up, long width, long height, long horizontalRadius, long verticalRadius)
    {
        this.AddIndent(1);
        
        this.AddS("<rect");

        this.AddAttributeInt(this.S("x"), left);

        this.AddAttributeInt(this.S("y"), up);

        this.AddAttributeInt(this.S("width"), width);

        this.AddAttributeInt(this.S("height"), height);

        this.AddAttributeInt(this.S("rx"), horizontalRadius);

        this.AddAttributeInt(this.S("ry"), verticalRadius);

        this.AddAttributeString(this.S("stroke"), this.S("black"));

        this.AddAttributeInt(this.S("stroke-width"), 1);

        this.AddAttributeString(this.S("fill"), this.S("white"));

        this.CloseTag();

        this.AddLine();
        
        return true;
    }

    protected virtual bool AddText(long left, long up, String value, long valueChar, long fontSize)
    {
        this.AddIndent(1);

        this.AddS("<text");

        this.AddAttributeInt(this.S("x"), left);

        this.AddAttributeInt(this.S("y"), up);

        this.AddAttributeInt(this.S("font-size"), fontSize);

        this.AddAttributeString(this.S("text-anchor"), this.S("start"));

        this.AddAttributeString(this.S("fill"), this.S("black"));

        this.AddAttributeString(this.S("font-family"), this.S("Source Code Pro"));

        this.AddS(">");

        bool b;
        b = (value == null);

        if (b)
        {
            String kk;
            kk = this.EscapeChar(valueChar);

            this.Add(kk);
        }

        if (!b)
        {
            this.Add(value);
        }

        this.AddS("</text>");

        this.AddLine();
        return true;
    }

    protected virtual String EscapeChar(long n)
    {
        String k;
        k = null;

        bool b;
        b = false;

        if (!b & (n == '<'))
        {
            k = this.S("&lt;");

            b = true;
        }

        if (!b & (n == '>'))
        {
            k = this.S("&gt;");

            b = true;
        }

        if (!b & (n == '&'))
        {
            k = this.S("&amp;");

            b = true;
        }

        if (!b & (n == '\"'))
        {
            k = this.S("&quot;");

            b = true;
        }

        if (!b)
        {
            uint ka;
            ka = (uint)n;

            k = this.StringComp.CreateChar(ka, 1);
        }

        return k;
    }

    protected virtual bool AddAttributeInt(String name, long value)
    {
        this.AddS(" ").Add(name).AddS("=\"").Add(this.StringInt(value)).AddS("\"");
        return true;
    }

    protected virtual bool AddAttributeChar(String name, long value)
    {
        uint kk;
        kk = (uint)value;

        String ka;
        ka = this.StringComp.CreateChar(kk, 1);

        this.AddS(" ").Add(name).AddS("=\"").Add(ka).AddS("\"");
        return true;
    }

    protected virtual bool AddAttributeString(String name, String value)
    {
        this.AddS(" ").Add(name).AddS("=\"").Add(value).AddS("\"");
        return true;
    }

    protected virtual bool CloseTag()
    {
        this.AddS(" />");
        return true;
    }
}