namespace Avalon.Intern;



public class KeyCodeList : object
{
    public static KeyCodeList This { get; } = ShareCreate();




    private static KeyCodeList ShareCreate()
    {
        KeyCodeList share;


        share = new KeyCodeList();


        share.Init();



        return share;
    }





    public virtual bool Init()
    {
        this.Array = new int[this.Count];
        




        int count;

        count = this.Count;


        int i;

        i = 0;

        while (i < count)
        {
            this.Array[i] = -1;


            i = i + 1;
        }




        count = 26;
        

        i = 0;

        while (i < count)
        {
            this.AddLetterKey();


            i = i + 1;
        }


        


        this.AddDigitKey(')');

        this.AddDigitKey('!');

        this.AddDigitKey('@');

        this.AddDigitKey('#');

        this.AddDigitKey('$');

        this.AddDigitKey('%');

        this.AddDigitKey('^');

        this.AddDigitKey('&');

        this.AddDigitKey('*');

        this.AddDigitKey('(');
        




        this.AddSignKey(' ', ' ');


        this.AddSignKey('`', '~');


        this.AddSignKey('-', '_');


        this.AddSignKey('=', '+');


        this.AddSignKey('[', '{');


        this.AddSignKey(']', '}');


        this.AddSignKey(';', ':');


        this.AddSignKey('\'', '"');


        this.AddSignKey(',', '<');


        this.AddSignKey('.', '>');


        this.AddSignKey('/', '?');


        this.AddSignKey('\\', '|');






        this.AddControlKey();



        int uu;

        uu = this.ControlStart + this.ControlIndex;



        this.AddControlKey();



        this.Array[uu + 1] = uu;




        this.ControlIndex = 0x03;


        this.AddControlKeyList(2);



        this.ControlIndex = 0x06;


        this.AddControlKeyList(4);



        this.ControlIndex = 0x0a;


        this.AddControlKeyList(2);



        this.ControlIndex = 0x10;


        this.AddControlKeyList(8);



        this.ControlIndex = 0x20;


        this.AddControlKeyList(7);



        this.ControlIndex = 0x30;


        this.AddControlKeyList(12);




        return true;
    }






    protected virtual bool AddLetterKey()
    {
        int u;

        u = this.LetterIndex + 'A';



        this.Array[u] = u;



        this.LetterIndex = this.LetterIndex + 1;




        return true;
    }





    protected virtual bool AddDigitKey(char shiftChar)
    {        
        int ua;

        ua = this.DigitIndex + '0';



        int ub;

        ub = shiftChar;



        this.Array[ua] = ua;


        this.Array[ub] = ua;




        this.DigitIndex = this.DigitIndex + 1;




        return true;
    }






    protected virtual bool AddSignKey(char defaultChar, char shiftChar)
    {
        int ua;

        ua = defaultChar;


        int ub;

        ub = shiftChar;



        this.Array[ua] = ua;


        this.Array[ub] = ua;

        

        return true;
    }







    protected virtual bool AddControlKey()
    {
        int u;

        u = this.ControlIndex + this.ControlStart;



        this.Array[u] = u;



        this.ControlIndex = this.ControlIndex + 1;



        return true;
    }





    protected virtual bool AddControlKeyList(int count)
    {
        int i;

        i = 0;


        while (i < count)
        {
            this.AddControlKey();


            i = i + 1;
        }


        return true;
    }






    public virtual int Get(int index)
    {
        return this.Array[index];
    }





    public virtual int IndexFromInternIndex(int u)
    {
        int a;

        a = u;


        int uu;

        uu = this.InternControlStart;



        if (!(a < uu))
        {
            a = a - uu;

            a = a + this.ControlStart;
        }


        
        return a;
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




    public virtual int InternControlStart
    {
        get
        {
            return 0x01000000;
        }
        set
        {
        }
    }




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
    



    protected virtual int[] Array { get; set; }




    protected virtual int LetterIndex { get; set; }



    protected virtual int DigitIndex { get; set; }



    protected virtual int ControlIndex { get; set; }
}