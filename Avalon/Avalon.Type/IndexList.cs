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
        
        this.AlphaA = this.AddAlphaIndex();
        this.AlphaB = this.AddAlphaIndex();
        this.AlphaC = this.AddAlphaIndex();
        this.AlphaD = this.AddAlphaIndex();
        this.AlphaE = this.AddAlphaIndex();
        this.AlphaF = this.AddAlphaIndex();
        this.AlphaG = this.AddAlphaIndex();
        this.AlphaH = this.AddAlphaIndex();
        this.AlphaI = this.AddAlphaIndex();
        this.AlphaJ = this.AddAlphaIndex();
        this.AlphaK = this.AddAlphaIndex();
        this.AlphaL = this.AddAlphaIndex();
        this.AlphaM = this.AddAlphaIndex();
        this.AlphaN = this.AddAlphaIndex();
        this.AlphaO = this.AddAlphaIndex();
        this.AlphaP = this.AddAlphaIndex();
        this.AlphaQ = this.AddAlphaIndex();
        this.AlphaR = this.AddAlphaIndex();
        this.AlphaS = this.AddAlphaIndex();
        this.AlphaT = this.AddAlphaIndex();
        this.AlphaU = this.AddAlphaIndex();
        this.AlphaV = this.AddAlphaIndex();
        this.AlphaW = this.AddAlphaIndex();
        this.AlphaX = this.AddAlphaIndex();
        this.AlphaY = this.AddAlphaIndex();
        this.AlphaZ = this.AddAlphaIndex();

        this.Digit0 = this.AddDigitIndex();
        this.Digit1 = this.AddDigitIndex();
        this.Digit2 = this.AddDigitIndex();
        this.Digit3 = this.AddDigitIndex();
        this.Digit4 = this.AddDigitIndex();
        this.Digit5 = this.AddDigitIndex();
        this.Digit6 = this.AddDigitIndex();
        this.Digit7 = this.AddDigitIndex();
        this.Digit8 = this.AddDigitIndex();
        this.Digit9 = this.AddDigitIndex();
        
        this.SignSpace = this.AddSignIndex(' ');
        //this.SignBackTick = this.AddSignButton('`');
        this.SignTilde = this.AddSignIndex('~');
        this.SignNot = this.AddSignIndex('!');
        //this.SignAt = this.AddSignButton('@');
        this.SignHash = this.AddSignIndex('#');
        //this.SignDollar = this.AddSignButton('$');
        this.SignPercent = this.AddSignIndex('%');
        this.SignExpo = this.AddSignIndex('^');
        this.SignAnd = this.AddSignIndex('&');
        this.SignMul = this.AddSignIndex('*');
        this.SignSub = this.AddSignIndex('-');
        this.SignLine = this.AddSignIndex('_');
        this.SignSame = this.AddSignIndex('=');
        this.SignAdd = this.AddSignIndex('+');
        this.SignBraceLite = this.AddSignIndex('{');
        this.SignBraceRite = this.AddSignIndex('}');
        this.SignBraceRoundLite = this.AddSignIndex('(');
        this.SignBraceRoundRite = this.AddSignIndex(')');
        this.SignBraceSquareLite = this.AddSignIndex('[');
        this.SignBraceSquareRite = this.AddSignIndex(']');
        this.SignExecute = this.AddSignIndex(';');
        this.SignAre = this.AddSignIndex(':');
        this.SignTail = this.AddSignIndex('\'');
        this.SignQuote = this.AddSignIndex('"');
        this.SignPause = this.AddSignIndex(',');
        this.SignLessNite = this.AddSignIndex('<');
        this.SignLessSite = this.AddSignIndex('>');
        this.SignStop = this.AddSignIndex('.');
        this.SignDiv = this.AddSignIndex('/');
        this.SignQuest = this.AddSignIndex('?');
        this.SignBackSlash = this.AddSignIndex('\\');
        this.SignOrn = this.AddSignIndex('|');

        //this.ControlEscape = this.AddControlButton();
        this.InnTab = this.AddInnIndex();
        this.InnIndex = 0x03;
        this.InnBackSpace = this.AddInnIndex();
        this.InnEnter = this.AddInnIndex();
        this.InnIndex = 0x06;
        //this.ControlInsert = this.AddControlButton();
        //this.ControlDelete = this.AddControlButton();
        //this.ControlPause = this.AddControlButton();
        //this.ControlPrint = this.AddControlButton();
        this.InnIndex = 0x10;
        //this.ControlHome = this.AddControlButton();
        //this.ControlEnd = this.AddControlButton();
        //this.ControlLeft = this.AddControlButton();
        //this.ControlUp = this.AddControlButton();
        //this.ControlRight = this.AddControlButton();
        //this.ControlDown = this.AddControlButton();
        //this.ControlPageUp = this.AddControlButton();
        //this.ControlPageDown = this.AddControlButton();

        this.InnIndex = 0x20;
        this.InnShift = this.AddInnIndex();
        this.ControlControl = this.AddInnIndex();
        this.InnIndex = 0x23;
        //this.ControlAlt = this.AddControlButton();
        //this.ControlCapsLock = this.AddControlButton();
        //this.ControlNumLock = this.AddControlButton();
        //this.ControlScrollLock = this.AddControlButton();

        this.InnIndex = 0x30;
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
    public virtual Index InnTab { get; set; }
    public virtual Index InnBackSpace { get; set; }
    public virtual Index InnEnter { get; set; }
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
    public virtual Index InnShift { get; set; }
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

    protected virtual Index AddAlphaIndex()
    {
        long index;
        index = this.AlphaIndex + 'A';

        Index a;
        a = this.AddIndex(index, index);

        this.AlphaIndex = this.AlphaIndex + 1;
        return a;
    }

    protected virtual Index AddDigitIndex()
    {
        long index;
        index = this.DigitIndex + '0';

        Index a;
        a = this.AddIndex(index, index);

        this.DigitIndex = this.DigitIndex + 1;
        return a;
    }

    protected virtual Index AddSignIndex(long varChar)
    {
        long index;
        index = varChar;
        Index a;
        a = this.AddIndex(index, varChar);
        return a;
    }

    protected virtual Index AddInnIndex()
    {
        long index;
        index = this.InnIndex + this.ControlStart;
        long oc;
        oc = 0;
        Index a;
        a = this.AddIndex(index, oc);
        this.InnIndex = this.InnIndex + 1;
        return a;
    }

    protected virtual Index AddIndex(long index, long varChar)
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

    public virtual bool IsAlphaIndex(long index)
    {
        return this.TextInfra.Alpha(index, true);
    }

    public virtual bool IsDigitIndex(long index)
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
    protected virtual long InnIndex { get; set; }

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