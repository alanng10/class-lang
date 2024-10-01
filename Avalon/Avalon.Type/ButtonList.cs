namespace Avalon.Type;

public class IndexList : Any
{
    public static IndexList This { get; } = ShareCreate();

    private static IndexList ShareCreate()
    {
        IndexList share;
        share = new IndexList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.Array = new Array();
        this.Array.Count = this.Count;
        this.Array.Init();
        
        this.AlphaA = this.AddAlphaButton();
        this.AlphaB = this.AddAlphaButton();
        this.AlphaC = this.AddAlphaButton();
        this.AlphaD = this.AddAlphaButton();
        this.AlphaE = this.AddAlphaButton();
        this.AlphaF = this.AddAlphaButton();
        this.AlphaG = this.AddAlphaButton();
        this.AlphaH = this.AddAlphaButton();
        this.AlphaI = this.AddAlphaButton();
        this.AlphaJ = this.AddAlphaButton();
        this.AlphaK = this.AddAlphaButton();
        this.AlphaL = this.AddAlphaButton();
        this.AlphaM = this.AddAlphaButton();
        this.AlphaN = this.AddAlphaButton();
        this.AlphaO = this.AddAlphaButton();
        this.AlphaP = this.AddAlphaButton();
        this.AlphaQ = this.AddAlphaButton();
        this.AlphaR = this.AddAlphaButton();
        this.AlphaS = this.AddAlphaButton();
        this.AlphaT = this.AddAlphaButton();
        this.AlphaU = this.AddAlphaButton();
        this.AlphaV = this.AddAlphaButton();
        this.AlphaW = this.AddAlphaButton();
        this.AlphaX = this.AddAlphaButton();
        this.AlphaY = this.AddAlphaButton();
        this.AlphaZ = this.AddAlphaButton();

        this.Digit0 = this.AddDigitButton();
        this.Digit1 = this.AddDigitButton();
        this.Digit2 = this.AddDigitButton();
        this.Digit3 = this.AddDigitButton();
        this.Digit4 = this.AddDigitButton();
        this.Digit5 = this.AddDigitButton();
        this.Digit6 = this.AddDigitButton();
        this.Digit7 = this.AddDigitButton();
        this.Digit8 = this.AddDigitButton();
        this.Digit9 = this.AddDigitButton();
        
        this.SignSpace = this.AddSignButton(' ');
        //this.SignBackTick = this.AddSignButton('`');
        this.SignTilde = this.AddSignButton('~');
        this.SignNot = this.AddSignButton('!');
        //this.SignAt = this.AddSignButton('@');
        this.SignHash = this.AddSignButton('#');
        //this.SignDollar = this.AddSignButton('$');
        this.SignPercent = this.AddSignButton('%');
        this.SignExpo = this.AddSignButton('^');
        this.SignAnd = this.AddSignButton('&');
        this.SignMul = this.AddSignButton('*');
        this.SignSub = this.AddSignButton('-');
        this.SignLine = this.AddSignButton('_');
        this.SignSame = this.AddSignButton('=');
        this.SignAdd = this.AddSignButton('+');
        this.SignBraceLite = this.AddSignButton('{');
        this.SignBraceRite = this.AddSignButton('}');
        this.SignBraceRoundLite = this.AddSignButton('(');
        this.SignBraceRoundRite = this.AddSignButton(')');
        this.SignBraceSquareLite = this.AddSignButton('[');
        this.SignBraceSquareRite = this.AddSignButton(']');
        this.SignExecute = this.AddSignButton(';');
        this.SignAre = this.AddSignButton(':');
        this.SignTail = this.AddSignButton('\'');
        this.SignQuote = this.AddSignButton('"');
        this.SignPause = this.AddSignButton(',');
        this.SignLessNite = this.AddSignButton('<');
        this.SignLessSite = this.AddSignButton('>');
        this.SignStop = this.AddSignButton('.');
        this.SignDiv = this.AddSignButton('/');
        this.SignQuest = this.AddSignButton('?');
        this.SignBackSlash = this.AddSignButton('\\');
        this.SignOrn = this.AddSignButton('|');

        //this.ControlEscape = this.AddControlButton();
        this.ControlTab = this.AddControlButton();
        this.ControlIndex = 0x03;
        this.ControlBackSpace = this.AddControlButton();
        this.ControlEnter = this.AddControlButton();
        this.ControlIndex = 0x06;
        //this.ControlInsert = this.AddControlButton();
        //this.ControlDelete = this.AddControlButton();
        //this.ControlPause = this.AddControlButton();
        //this.ControlPrint = this.AddControlButton();
        this.ControlIndex = 0x10;
        //this.ControlHome = this.AddControlButton();
        //this.ControlEnd = this.AddControlButton();
        //this.ControlLeft = this.AddControlButton();
        //this.ControlUp = this.AddControlButton();
        //this.ControlRight = this.AddControlButton();
        //this.ControlDown = this.AddControlButton();
        //this.ControlPageUp = this.AddControlButton();
        //this.ControlPageDown = this.AddControlButton();

        this.ControlIndex = 0x20;
        this.ControlShift = this.AddControlButton();
        this.ControlControl = this.AddControlButton();
        this.ControlIndex = 0x23;
        //this.ControlAlt = this.AddControlButton();
        //this.ControlCapsLock = this.AddControlButton();
        //this.ControlNumLock = this.AddControlButton();
        //this.ControlScrollLock = this.AddControlButton();

        this.ControlIndex = 0x30;
        // this.ControlF1 = this.AddControlButton();
        // this.ControlF2 = this.AddControlButton();
        // this.ControlF3 = this.AddControlButton();
        // this.ControlF4 = this.AddControlButton();
        // this.ControlF5 = this.AddControlButton();
        // this.ControlF6 = this.AddControlButton();
        // this.ControlF7 = this.AddControlButton();
        // this.ControlF8 = this.AddControlButton();
        // this.ControlF9 = this.AddControlButton();
        // this.ControlF10 = this.AddControlButton();
        // this.ControlF11 = this.AddControlButton();
        // this.ControlF12 = this.AddControlButton();
        return true;
    }

    public virtual Index AlphaA { get; set; }
    public virtual Index AlphaB { get; set; }
    public virtual Index AlphaC { get; set; }
    public virtual Index AlphaD { get; set; }
    public virtual Index AlphaE { get; set; }
    public virtual Index AlphaF { get; set; }
    public virtual Index AlphaG { get; set; }
    public virtual Index AlphaH { get; set; }
    public virtual Index AlphaI { get; set; }
    public virtual Index AlphaJ { get; set; }
    public virtual Index AlphaK { get; set; }
    public virtual Index AlphaL { get; set; }
    public virtual Index AlphaM { get; set; }
    public virtual Index AlphaN { get; set; }
    public virtual Index AlphaO { get; set; }
    public virtual Index AlphaP { get; set; }
    public virtual Index AlphaQ { get; set; }
    public virtual Index AlphaR { get; set; }
    public virtual Index AlphaS { get; set; }
    public virtual Index AlphaT { get; set; }
    public virtual Index AlphaU { get; set; }
    public virtual Index AlphaV { get; set; }
    public virtual Index AlphaW { get; set; }
    public virtual Index AlphaX { get; set; }
    public virtual Index AlphaY { get; set; }
    public virtual Index AlphaZ { get; set; }

    public virtual Index Digit0 { get; set; }
    public virtual Index Digit1 { get; set; }
    public virtual Index Digit2 { get; set; }
    public virtual Index Digit3 { get; set; }
    public virtual Index Digit4 { get; set; }
    public virtual Index Digit5 { get; set; }
    public virtual Index Digit6 { get; set; }
    public virtual Index Digit7 { get; set; }
    public virtual Index Digit8 { get; set; }
    public virtual Index Digit9 { get; set; }

    public virtual Index SignSpace { get; set; }
    // public virtual Button SignBackTick { get; set; }
    public virtual Index SignTilde { get; set; }
    public virtual Index SignNot { get; set; }
    // public virtual Button SignAt { get; set; }
    public virtual Index SignHash { get; set; }
    // public virtual Button SignDollar { get; set; }
    public virtual Index SignPercent { get; set; }
    public virtual Index SignExpo { get; set; }
    public virtual Index SignAnd { get; set; }
    public virtual Index SignMul { get; set; }
    public virtual Index SignBraceRoundLite { get; set; }
    public virtual Index SignBraceRoundRite { get; set; }
    public virtual Index SignSub { get; set; }
    public virtual Index SignLine { get; set; }
    public virtual Index SignSame { get; set; }
    public virtual Index SignAdd { get; set; }
    public virtual Index SignBraceSquareLite { get; set; }
    public virtual Index SignBraceLite { get; set; }
    public virtual Index SignBraceSquareRite { get; set; }
    public virtual Index SignBraceRite { get; set; }
    public virtual Index SignExecute { get; set; }
    public virtual Index SignAre { get; set; }
    public virtual Index SignTail { get; set; }
    public virtual Index SignQuote { get; set; }
    public virtual Index SignPause { get; set; }
    public virtual Index SignLessNite { get; set; }
    public virtual Index SignLessSite { get; set; }
    public virtual Index SignStop { get; set; }
    public virtual Index SignDiv { get; set; }
    public virtual Index SignQuest { get; set; }
    public virtual Index SignBackSlash { get; set; }
    public virtual Index SignOrn { get; set; }

    // public virtual Button ControlEscape { get; set; }
    public virtual Index ControlTab { get; set; }
    public virtual Index ControlBackSpace { get; set; }
    public virtual Index ControlEnter { get; set; }
    // public virtual Button ControlInsert { get; set; }
    // public virtual Button ControlDelete { get; set; }
    // public virtual Button ControlPause { get; set; }
    // public virtual Button ControlPrint { get; set; }
    // public virtual Button ControlHome { get; set; }
    // public virtual Button ControlEnd { get; set; }
    // public virtual Button ControlLeft { get; set; }
    // public virtual Button ControlUp { get; set; }
    // public virtual Button ControlRight { get; set; }
    // public virtual Button ControlDown { get; set; }
    // public virtual Button ControlPageUp { get; set; }
    // public virtual Button ControlPageDown { get; set; }
    public virtual Index ControlShift { get; set; }
    public virtual Index ControlControl { get; set; }
    // public virtual Button ControlAlt { get; set; }
    // public virtual Button ControlCapsLock { get; set; }
    // public virtual Button ControlNumLock { get; set; }
    // public virtual Button ControlScrollLock { get; set; }
    // public virtual Button ControlF1 { get; set; }
    // public virtual Button ControlF2 { get; set; }
    // public virtual Button ControlF3 { get; set; }
    // public virtual Button ControlF4 { get; set; }
    // public virtual Button ControlF5 { get; set; }
    // public virtual Button ControlF6 { get; set; }
    // public virtual Button ControlF7 { get; set; }
    // public virtual Button ControlF8 { get; set; }
    // public virtual Button ControlF9 { get; set; }
    // public virtual Button ControlF10 { get; set; }
    // public virtual Button ControlF11 { get; set; }
    // public virtual Button ControlF12 { get; set; }

    protected virtual TextInfra TextInfra { get; set; }

    protected virtual Index AddAlphaButton()
    {
        long index;
        index = this.AlphaIndex + 'A';

        Index a;
        a = this.AddButton(index, index);

        this.AlphaIndex = this.AlphaIndex + 1;
        return a;
    }

    protected virtual Index AddDigitButton()
    {
        long index;
        index = this.DigitIndex + '0';

        Index a;
        a = this.AddButton(index, index);

        this.DigitIndex = this.DigitIndex + 1;
        return a;
    }

    protected virtual Index AddSignButton(long varChar)
    {
        long index;
        index = varChar;
        Index a;
        a = this.AddButton(index, varChar);
        return a;
    }

    protected virtual Index AddControlButton()
    {
        long index;
        index = this.ControlIndex + this.ControlStart;
        long oc;
        oc = 0;
        Index a;
        a = this.AddButton(index, oc);
        this.ControlIndex = this.ControlIndex + 1;
        return a;
    }

    protected virtual Index AddButton(long index, long varChar)
    {
        varChar = varChar & 0xff;

        Index a;
        a = new Index();
        a.Init();
        a.IndexList = index;
        a.Char = varChar;
        this.Array.SetAt(a.IndexList, a);
        return a;
    }

    public virtual Index Get(long index)
    {
        return (Index)this.Array.GetAt(index);
    }

    public virtual bool IsAlphaButton(long index)
    {
        return this.TextInfra.Alpha(index, true);
    }

    public virtual bool IsDigitButton(long index)
    {
        return this.TextInfra.Digit(index);
    }

    public virtual Index AlphaButton(long letterIndex)
    {
        long start;
        start = 'A';
        return this.IndexButton(letterIndex, start);
    }

    public virtual Index DigitButton(long digitIndex)
    {
        long start;
        start = '0';
        return this.IndexButton(digitIndex, start);
    }

    protected virtual Index IndexButton(long index, long start)
    {
        long k;
        k = start + index;
        Index a;
        a = this.Get(k);
        return a;
    }

    public virtual long Count
    {
        get
        {
            return 0x100;
        }
        set
        {
        }
    }

    protected virtual Array Array { get; set; }
    protected virtual long AlphaIndex { get; set; }
    protected virtual long DigitIndex { get; set; }
    protected virtual long ControlIndex { get; set; }

    public virtual long ControlStart
    {
        get
        {
            return 0x80;
        }
        set
        {
        }
    }
}