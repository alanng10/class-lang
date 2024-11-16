class DeA : Dem
{
    maide prusate Bool Execute()
    {
        base.Execute();

        var Console console;
        console : share Console;
        
        console.Out.Write("Demo ABCD AAAA BBBB\n");

        var String k;
        #k : console.Inn.Read();
        k : "kkk";

        this.TextInfra : share TextInfra;

        var StringAdd h;
        h : new StringAdd;
        h.Init();

        this.TextInfra.AddString(h, "k: \n");
        this.TextInfra.AddString(h, k);
        this.TextInfra.AddString(h, "\n");

        var String a;
        
        a : h.Result();

        console.Out.Write(a);

        #console.Inn.Read();

        #var Data ka;
        #ka : new Data;
        #ka.Count : 10 * 1024 * 1024;
        #ka.Init();

        #console.Inn.Read();

        console.Out.Write("Demo HHHH\n");

        console.Out.Write("Demo 1111\n");

        inf (true)
        {
            console.Out.Write("Demo True\n");
        }

        console.Out.Write("Demo 2222\n");
 
        inf (false)
        {
            console.Out.Write("Demo False\n");
        }

        console.Out.Write("Demo 3333\n");

        inf (null)
        {
            console.Out.Write("Demo Null\n");
        }

        console.Out.Write("Demo 4444\n");

        inf (null & null)
        {
            console.Out.Write("Demo Null and Null\n");
        }

        console.Out.Write("Demo 5555\n");

        inf (~(null | null))
        {
            console.Out.Write("Demo not (Null orn Null)\n");
        }

        console.Out.Write("Demo 6666\n");

        this.StringComp : share StringComp;

        this.IntParse : new IntParse;
        this.IntParse.Init();
        
        var Text text;
        text : this.TextInfra.TextCreateStringData("fffffffffffffff", null);

        var Int nn;
        nn : this.TextInfra.Char("9");

        var Bool ba;
        ba : this.TextInfra.Digit(nn);

        inf (ba)
        {
            console.Out.Write("Demo Digit 1111\n");
        }

        var Int kkk;
        kkk : this.TextInfra.DigitValue(nn, 10);

        inf (kkk = 9)
        {
            console.Out.Write("Demo DigitValue 1111\n");
        }

        #var String kk;
        #kk : this.StringComp.CreateData(text.Data, text.Range);

        #console.Out.Write(kk);

        var Int na;
        na : this.IntParse.Execute(text, 16, null);

        inf (na = 0hfffffffffffffff)
        {
            console.Out.Write("Demo IntParse 1111\n");
        }

        return true;
    }

    maide precate Format CreateFormat()
    {
        var Format a;
        a : new Format;
        a.Init();
        return a;
    }

    maide precate FormatArg CreateFormatArg()
    {
        var FormatArg a;
        a : new FormatArg;
        a.Init();
        return a;
    }

    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field private IntParse IntParse { get { return data; } set { data : value; } }
}