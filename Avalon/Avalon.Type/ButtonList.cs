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
        




        this.LetterA = this.AddLetterKey();

        this.LetterB = this.AddLetterKey();

        this.LetterC = this.AddLetterKey();

        this.LetterD = this.AddLetterKey();

        this.LetterE = this.AddLetterKey();

        this.LetterF = this.AddLetterKey();

        this.LetterG = this.AddLetterKey();

        this.LetterH = this.AddLetterKey();

        this.LetterI = this.AddLetterKey();

        this.LetterJ = this.AddLetterKey();

        this.LetterK = this.AddLetterKey();

        this.LetterL = this.AddLetterKey();

        this.LetterM = this.AddLetterKey();

        this.LetterN = this.AddLetterKey();

        this.LetterO = this.AddLetterKey();

        this.LetterP = this.AddLetterKey();

        this.LetterQ = this.AddLetterKey();

        this.LetterR = this.AddLetterKey();

        this.LetterS = this.AddLetterKey();

        this.LetterT = this.AddLetterKey();

        this.LetterU = this.AddLetterKey();

        this.LetterV = this.AddLetterKey();

        this.LetterW = this.AddLetterKey();

        this.LetterX = this.AddLetterKey();

        this.LetterY = this.AddLetterKey();

        this.LetterZ = this.AddLetterKey();



        


        this.Digit0 = this.AddDigitKey(')');

        this.Digit1 = this.AddDigitKey('!');

        this.Digit2 = this.AddDigitKey('@');

        this.Digit3 = this.AddDigitKey('#');

        this.Digit4 = this.AddDigitKey('$');

        this.Digit5 = this.AddDigitKey('%');

        this.Digit6 = this.AddDigitKey('^');

        this.Digit7 = this.AddDigitKey('&');

        this.Digit8 = this.AddDigitKey('*');

        this.Digit9 = this.AddDigitKey('(');
        




        this.Space = this.AddSignKey(' ', ' ');


        this.BackTick = this.AddSignKey('`', '~');


        this.Dash = this.AddSignKey('-', '_');


        this.EqualSign = this.AddSignKey('=', '+');


        this.LeftSquare = this.AddSignKey('[', '{');


        this.RightSquare = this.AddSignKey(']', '}');


        this.SemiColon = this.AddSignKey(';', ':');


        this.SingleQuote = this.AddSignKey('\'', '"');


        this.Comma = this.AddSignKey(',', '<');


        this.Dot = this.AddSignKey('.', '>');


        this.Slash = this.AddSignKey('/', '?');


        this.BackSlash = this.AddSignKey('\\', '|');






        this.Escape = this.AddControlKey();

        this.Tab = this.AddControlKey();



        this.ControlIndex = 0x03;


        this.BackSpace = this.AddControlKey();

        this.Enter = this.AddControlKey();


        this.ControlIndex = 0x06;


        this.Insert = this.AddControlKey();

        this.Delete = this.AddControlKey();

        this.Pause = this.AddControlKey();

        this.Print = this.AddControlKey();



        this.ControlIndex = 0x0a;


        this.SysReq = this.AddControlKey();

        this.Clear = this.AddControlKey();



        this.ControlIndex = 0x10;


        this.Home = this.AddControlKey();

        this.End = this.AddControlKey();

        this.Left = this.AddControlKey();

        this.Up = this.AddControlKey();

        this.Right = this.AddControlKey();

        this.Down = this.AddControlKey();

        this.PageUp = this.AddControlKey();

        this.PageDown = this.AddControlKey();



        this.ControlIndex = 0x20;


        this.Shift = this.AddControlKey();

        this.Control = this.AddControlKey();

        this.Meta = this.AddControlKey();

        this.Alt = this.AddControlKey();

        this.CapsLock = this.AddControlKey();

        this.NumLock = this.AddControlKey();

        this.ScrollLock = this.AddControlKey();



        this.ControlIndex = 0x30;


        this.F1 = this.AddControlKey();

        this.F2 = this.AddControlKey();

        this.F3 = this.AddControlKey();

        this.F4 = this.AddControlKey();

        this.F5 = this.AddControlKey();

        this.F6 = this.AddControlKey();

        this.F7 = this.AddControlKey();

        this.F8 = this.AddControlKey();

        this.F9 = this.AddControlKey();

        this.F10 = this.AddControlKey();

        this.F11 = this.AddControlKey();

        this.F12 = this.AddControlKey();




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




    public virtual Button Space { get; set; }


    public virtual Button BackTick { get; set; }


    public virtual Button Dash { get; set; }


    public virtual Button EqualSign { get; set; }


    public virtual Button LeftSquare { get; set; }


    public virtual Button RightSquare { get; set; }


    public virtual Button SemiColon { get; set; }


    public virtual Button SingleQuote { get; set; }


    public virtual Button Comma { get; set; }


    public virtual Button Dot { get; set; }


    public virtual Button Slash { get; set; }


    public virtual Button BackSlash { get; set; }



    
    public virtual Button Escape { get; set; }


    public virtual Button Tab { get; set; }


    public virtual Button BackSpace { get; set; }


    public virtual Button Enter { get; set; }


    public virtual Button Insert { get; set; }


    public virtual Button Delete { get; set; }


    public virtual Button Pause { get; set; }


    public virtual Button Print { get; set; }


    public virtual Button SysReq { get; set; }


    public virtual Button Clear { get; set; }


    public virtual Button Home { get; set; }


    public virtual Button End { get; set; }


    public virtual Button Left { get; set; }


    public virtual Button Up { get; set; }


    public virtual Button Right { get; set; }


    public virtual Button Down { get; set; }


    public virtual Button PageUp { get; set; }


    public virtual Button PageDown { get; set; }


    public virtual Button Shift { get; set; }


    public virtual Button Control { get; set; }


    public virtual Button Meta { get; set; }


    public virtual Button Alt { get; set; }


    public virtual Button CapsLock { get; set; }


    public virtual Button NumLock { get; set; }


    public virtual Button ScrollLock { get; set; }


    public virtual Button F1 { get; set; }


    public virtual Button F2 { get; set; }


    public virtual Button F3 { get; set; }


    public virtual Button F4 { get; set; }


    public virtual Button F5 { get; set; }


    public virtual Button F6 { get; set; }


    public virtual Button F7 { get; set; }


    public virtual Button F8 { get; set; }


    public virtual Button F9 { get; set; }


    public virtual Button F10 { get; set; }


    public virtual Button F11 { get; set; }


    public virtual Button F12 { get; set; }





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






    protected virtual Button AddLetterKey()
    {
        int index;

        index = this.LetterIndex + 'A';




        Button key;

        key = this.AddKey(index);



        ButtonChar oo;

        oo = new ButtonChar();

        oo.Init();




        int ub;

        ub = this.LetterIndex + 'a';



        char defaultChar;

        defaultChar = (char)ub;



        char shiftChar;

        shiftChar = (char)index;



        oo.Default = defaultChar;

        oo.Shift = shiftChar;



        key.Char = oo;



        this.LetterIndex = this.LetterIndex + 1;




        return key;
    }





    protected virtual Button AddDigitKey(char shiftChar)
    {
        int index;

        index = this.DigitIndex + '0';


        
        Button key;

        key = this.AddKey(index);



        ButtonChar oo;

        oo = new ButtonChar();

        oo.Init();




        char defaultChar;

        defaultChar = (char)index;



        oo.Default = defaultChar;

        oo.Shift = shiftChar;




        key.Char = oo;




        this.DigitIndex = this.DigitIndex + 1;




        return key;
    }






    protected virtual Button AddSignKey(char defaultChar, char shiftChar)
    {
        int index;

        index = defaultChar;



        Button key;

        key = this.AddKey(index);



        ButtonChar oo;

        oo = new ButtonChar();

        oo.Init();



        oo.Default = defaultChar;

        oo.Shift = shiftChar;




        key.Char = oo;




        return key;
    }







    protected virtual Button AddControlKey()
    {
        int index;

        index = this.ControlIndex + this.ControlStart;


        Button key;

        key = this.AddKey(index);



        this.ControlIndex = this.ControlIndex + 1;



        return key;
    }





    protected virtual Button AddKey(int index)
    {
        Button key;

        key = new Button();

        key.Init();

        key.Index = index;




        this.Array.Set(key.Index, key);
        


    
    
        Button ret;

        ret = key;

        return ret;
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