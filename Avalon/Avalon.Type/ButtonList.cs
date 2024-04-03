namespace Avalon.Type;

public class ButtonList : Any
{
    public static ButtonList This { get; } = ShareCreate();

    private static ButtonList ShareCreate()
    {
        ButtonList share;
        share = new ButtonList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.Array = new Array();
        this.Array.Count = this.Count;
        this.Array.Init();
        
        this.LetterA = this.AddLetterButton();
        this.LetterB = this.AddLetterButton();
        this.LetterC = this.AddLetterButton();
        this.LetterD = this.AddLetterButton();
        this.LetterE = this.AddLetterButton();
        this.LetterF = this.AddLetterButton();
        this.LetterG = this.AddLetterButton();
        this.LetterH = this.AddLetterButton();
        this.LetterI = this.AddLetterButton();
        this.LetterJ = this.AddLetterButton();
        this.LetterK = this.AddLetterButton();
        this.LetterL = this.AddLetterButton();
        this.LetterM = this.AddLetterButton();
        this.LetterN = this.AddLetterButton();
        this.LetterO = this.AddLetterButton();
        this.LetterP = this.AddLetterButton();
        this.LetterQ = this.AddLetterButton();
        this.LetterR = this.AddLetterButton();
        this.LetterS = this.AddLetterButton();
        this.LetterT = this.AddLetterButton();
        this.LetterU = this.AddLetterButton();
        this.LetterV = this.AddLetterButton();
        this.LetterW = this.AddLetterButton();
        this.LetterX = this.AddLetterButton();
        this.LetterY = this.AddLetterButton();
        this.LetterZ = this.AddLetterButton();

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
        this.SignBackTick = this.AddSignButton('`');
        this.SignTilde = this.AddSignButton('~');
        this.SignExclamate = this.AddSignButton('!');
        this.SignAt = this.AddSignButton('@');
        this.SignHash = this.AddSignButton('#');
        this.SignDollar = this.AddSignButton('$');
        this.SignPercent = this.AddSignButton('%');
        this.SignCaret = this.AddSignButton('^');
        this.SignAmpersand = this.AddSignButton('&');
        this.SignAsterisk = this.AddSignButton('*');
        this.SignLeftBracket = this.AddSignButton('(');
        this.SignRightBracket = this.AddSignButton(')');
        this.SignDash = this.AddSignButton('-');
        this.SignUnderscore = this.AddSignButton('_');
        this.SignEqual = this.AddSignButton('=');
        this.SignPlus = this.AddSignButton('+');
        this.SignLeftSquare = this.AddSignButton('[');
        this.SignLeftBrace = this.AddSignButton('{');
        this.SignRightSquare = this.AddSignButton(']');
        this.SignRightBrace = this.AddSignButton('}');
        this.SignSemiColon = this.AddSignButton(';');
        this.SignColon = this.AddSignButton(':');
        this.SignSingleQuote = this.AddSignButton('\'');
        this.SignDoubleQuote = this.AddSignButton('"');
        this.SignComma = this.AddSignButton(',');
        this.SignLessThan = this.AddSignButton('<');
        this.SignDot = this.AddSignButton('.');
        this.SignMoreThan = this.AddSignButton('>');
        this.SignSlash = this.AddSignButton('/');
        this.SignQuestion = this.AddSignButton('?');
        this.SignBackSlash = this.AddSignButton('\\');
        this.SignVerticalBar = this.AddSignButton('|');

        this.ControlEscape = this.AddControlButton();
        this.ControlTab = this.AddControlButton();
        this.ControlIndex = 0x03;
        this.ControlBackSpace = this.AddControlButton();
        this.ControlEnter = this.AddControlButton();
        this.ControlIndex = 0x06;
        this.ControlInsert = this.AddControlButton();
        this.ControlDelete = this.AddControlButton();
        this.ControlPause = this.AddControlButton();
        this.ControlPrint = this.AddControlButton();
        this.ControlIndex = 0x10;
        this.ControlHome = this.AddControlButton();
        this.ControlEnd = this.AddControlButton();
        this.ControlLeft = this.AddControlButton();
        this.ControlUp = this.AddControlButton();
        this.ControlRight = this.AddControlButton();
        this.ControlDown = this.AddControlButton();
        this.ControlPageUp = this.AddControlButton();
        this.ControlPageDown = this.AddControlButton();

        this.ControlIndex = 0x20;
        this.ControlShift = this.AddControlButton();
        this.ControlControl = this.AddControlButton();
        this.ControlIndex = 0x23;
        this.ControlAlt = this.AddControlButton();
        this.ControlCapsLock = this.AddControlButton();
        this.ControlNumLock = this.AddControlButton();
        this.ControlScrollLock = this.AddControlButton();

        this.ControlIndex = 0x30;
        this.ControlF1 = this.AddControlButton();
        this.ControlF2 = this.AddControlButton();
        this.ControlF3 = this.AddControlButton();
        this.ControlF4 = this.AddControlButton();
        this.ControlF5 = this.AddControlButton();
        this.ControlF6 = this.AddControlButton();
        this.ControlF7 = this.AddControlButton();
        this.ControlF8 = this.AddControlButton();
        this.ControlF9 = this.AddControlButton();
        this.ControlF10 = this.AddControlButton();
        this.ControlF11 = this.AddControlButton();
        this.ControlF12 = this.AddControlButton();
        return true;
    }

    public virtual Button LetterA { get; set; }
    public virtual Button LetterB { get; set; }
    public virtual Button LetterC { get; set; }
    public virtual Button LetterD { get; set; }
    public virtual Button LetterE { get; set; }
    public virtual Button LetterF { get; set; }
    public virtual Button LetterG { get; set; }
    public virtual Button LetterH { get; set; }
    public virtual Button LetterI { get; set; }
    public virtual Button LetterJ { get; set; }
    public virtual Button LetterK { get; set; }
    public virtual Button LetterL { get; set; }
    public virtual Button LetterM { get; set; }
    public virtual Button LetterN { get; set; }
    public virtual Button LetterO { get; set; }
    public virtual Button LetterP { get; set; }
    public virtual Button LetterQ { get; set; }
    public virtual Button LetterR { get; set; }
    public virtual Button LetterS { get; set; }
    public virtual Button LetterT { get; set; }
    public virtual Button LetterU { get; set; }
    public virtual Button LetterV { get; set; }
    public virtual Button LetterW { get; set; }
    public virtual Button LetterX { get; set; }
    public virtual Button LetterY { get; set; }
    public virtual Button LetterZ { get; set; }

    public virtual Button Digit0 { get; set; }
    public virtual Button Digit1 { get; set; }
    public virtual Button Digit2 { get; set; }
    public virtual Button Digit3 { get; set; }
    public virtual Button Digit4 { get; set; }
    public virtual Button Digit5 { get; set; }
    public virtual Button Digit6 { get; set; }
    public virtual Button Digit7 { get; set; }
    public virtual Button Digit8 { get; set; }
    public virtual Button Digit9 { get; set; }

    public virtual Button SignSpace { get; set; }
    public virtual Button SignBackTick { get; set; }
    public virtual Button SignTilde { get; set; }
    public virtual Button SignExclamate { get; set; }
    public virtual Button SignAt { get; set; }
    public virtual Button SignHash { get; set; }
    public virtual Button SignDollar { get; set; }
    public virtual Button SignPercent { get; set; }
    public virtual Button SignCaret { get; set; }
    public virtual Button SignAmpersand { get; set; }
    public virtual Button SignAsterisk { get; set; }
    public virtual Button SignLeftBracket { get; set; }
    public virtual Button SignRightBracket { get; set; }
    public virtual Button SignDash { get; set; }
    public virtual Button SignUnderscore { get; set; }
    public virtual Button SignEqual { get; set; }
    public virtual Button SignPlus { get; set; }
    public virtual Button SignLeftSquare { get; set; }
    public virtual Button SignLeftBrace { get; set; }
    public virtual Button SignRightSquare { get; set; }
    public virtual Button SignRightBrace { get; set; }
    public virtual Button SignSemiColon { get; set; }
    public virtual Button SignColon { get; set; }
    public virtual Button SignSingleQuote { get; set; }
    public virtual Button SignDoubleQuote { get; set; }
    public virtual Button SignComma { get; set; }
    public virtual Button SignLessThan { get; set; }
    public virtual Button SignDot { get; set; }
    public virtual Button SignMoreThan { get; set; }
    public virtual Button SignSlash { get; set; }
    public virtual Button SignQuestion { get; set; }
    public virtual Button SignBackSlash { get; set; }
    public virtual Button SignVerticalBar { get; set; }

    public virtual Button ControlEscape { get; set; }
    public virtual Button ControlTab { get; set; }
    public virtual Button ControlBackSpace { get; set; }
    public virtual Button ControlEnter { get; set; }
    public virtual Button ControlInsert { get; set; }
    public virtual Button ControlDelete { get; set; }
    public virtual Button ControlPause { get; set; }
    public virtual Button ControlPrint { get; set; }
    public virtual Button ControlHome { get; set; }
    public virtual Button ControlEnd { get; set; }
    public virtual Button ControlLeft { get; set; }
    public virtual Button ControlUp { get; set; }
    public virtual Button ControlRight { get; set; }
    public virtual Button ControlDown { get; set; }
    public virtual Button ControlPageUp { get; set; }
    public virtual Button ControlPageDown { get; set; }
    public virtual Button ControlShift { get; set; }
    public virtual Button ControlControl { get; set; }
    public virtual Button ControlAlt { get; set; }
    public virtual Button ControlCapsLock { get; set; }
    public virtual Button ControlNumLock { get; set; }
    public virtual Button ControlScrollLock { get; set; }
    public virtual Button ControlF1 { get; set; }
    public virtual Button ControlF2 { get; set; }
    public virtual Button ControlF3 { get; set; }
    public virtual Button ControlF4 { get; set; }
    public virtual Button ControlF5 { get; set; }
    public virtual Button ControlF6 { get; set; }
    public virtual Button ControlF7 { get; set; }
    public virtual Button ControlF8 { get; set; }
    public virtual Button ControlF9 { get; set; }
    public virtual Button ControlF10 { get; set; }
    public virtual Button ControlF11 { get; set; }
    public virtual Button ControlF12 { get; set; }

    public virtual Button LeftUp
    {
        get
        {
            return this.LetterW;
        }
        set
        {
        }
    }

    public virtual Button LeftDown
    {
        get
        {
            return this.LetterS;
        }
        set
        {
        }
    }

    public virtual Button LeftLeft
    {
        get
        {
            return this.LetterA;
        }
        set
        {
        }
    }

    public virtual Button LeftRight
    {
        get
        {
            return this.LetterD;
        }
        set
        {
        }
    }

    public virtual Button RightUp
    {
        get
        {
            return this.LetterI;
        }
        set
        {
        }
    }

    public virtual Button RightDown
    {
        get
        {
            return this.LetterK;
        }
        set
        {
        }
    }

    public virtual Button RightLeft
    {
        get
        {
            return this.LetterJ;
        }
        set
        {
        }
    }

    public virtual Button RightRight
    {
        get
        {
            return this.LetterL;
        }
        set
        {
        }
    }

    protected virtual Button AddLetterButton()
    {
        int index;
        index = this.LetterIndex + 'A';
        
        char oc;
        oc = (char)index;
        Button a;
        a = this.AddButton(index, oc);

        this.LetterIndex = this.LetterIndex + 1;
        return a;
    }

    protected virtual Button AddDigitButton()
    {
        int index;
        index = this.DigitIndex + '0';

        char oc;
        oc = (char)index;
        Button a;
        a = this.AddButton(index, oc);

        this.DigitIndex = this.DigitIndex + 1;
        return a;
    }

    protected virtual Button AddSignButton(char varChar)
    {
        int index;
        index = varChar;
        Button a;
        a = this.AddButton(index, varChar);
        return a;
    }

    protected virtual Button AddControlButton()
    {
        int index;
        index = this.ControlIndex + this.ControlStart;
        char oc;
        oc = (char)0;
        Button a;
        a = this.AddButton(index, oc);
        this.ControlIndex = this.ControlIndex + 1;
        return a;
    }

    protected virtual Button AddButton(int index, char varChar)
    {
        Button a;
        a = new Button();
        a.Init();
        a.Index = index;
        a.Char = varChar;
        this.Array.Set(a.Index, a);
        return a;
    }

    public virtual Button Get(int index)
    {
        return (Button)this.Array.Get(index);
    }

    public bool IsLetterKey(int index)
    {
        return !(index < 'A') & !('Z' < index);
    }

    public bool IsDigitKey(int index)
    {
        return !(index < '0') & !('9' < index);
    }

    public virtual Button LetterKey(int letterIndex)
    {
        int start;
        start = 'A';
        return this.IndexKey(letterIndex, start);
    }

    public virtual Button DigitKey(int digitIndex)
    {
        int start;
        start = '0';
        return this.IndexKey(digitIndex, start);
    }

    protected virtual Button IndexKey(int index, int start)
    {
        int k;
        k = start + index;
        Button key;
        key = this.Get(k);
        return key;
    }

    public virtual int Count
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
    protected virtual int LetterIndex { get; set; }
    protected virtual int DigitIndex { get; set; }
    protected virtual int ControlIndex { get; set; }

    public virtual int ControlStart
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