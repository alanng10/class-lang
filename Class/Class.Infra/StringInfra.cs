namespace Class.Infra;




public class StringInfra : Any
{
    public static StringInfra This { get; } = CreateGlobal();




    private static StringInfra CreateGlobal()
    {
        StringInfra global;


        global = new StringInfra();



        Any a;


        a = global;


        a.Init();



        return global;
    }





    public override bool Init()
    {
        base.Init();




        RangeInfra rangeInfra;

        rangeInfra = RangeInfra.This;



        this.RangeInfra = rangeInfra;





        TextInfra textInfra;

        textInfra = TextInfra.This;



        this.TextInfra = textInfra;





        Stat stat;

        stat = Stat.This;



        this.Stat = stat;







        this.CountWriteOperate = new CountWriteOperate();


        this.CountWriteOperate.Infra = this;


        this.CountWriteOperate.Init();





        this.AddWriteOperate = new AddWriteOperate();


        this.AddWriteOperate.Infra = this;


        this.AddWriteOperate.Init();




        this.TextPos = new TextPos();


        this.TextPos.Init();




        return true;
    }






    private RangeInfra RangeInfra { get; set; }



    private TextInfra TextInfra { get; set; }



    private Stat Stat { get; set; }




    private TextPos TextPos { get; set; }





    private CountWriteOperate CountWriteOperate { get; set; }



    private AddWriteOperate AddWriteOperate { get; set; }






    public virtual string Value(Text text, TextRange range)
    {
        bool b;


        b = this.CheckValueString(text, range);


        if (!b)
        {
            return null;
        }





        this.WriteOperate = this.CountWriteOperate;



        this.Index = 0;



        this.ExecuteValueString(text, range);




        int count;


        count = this.Index;



        this.Array = new char[count];





        this.WriteOperate = this.AddWriteOperate;



        this.Index = 0;



        this.ExecuteValueString(text, range);




        string k;

        k = new string(this.Array);





        this.Array = null;



        this.WriteOperate = null;





        string ret;

        ret = k;


        return ret;
    }








    private bool CheckValueString(Text text, TextRange range)
    {
        int kk;



        kk = this.RangeInfra.Count(range.Col);




        if (kk < 2)
        {
            return false;
        }




        this.TextPos.Row = range.Row;

        this.TextPos.Col = range.Col.Start;




        char oc;


        oc = this.TextInfra.GetChar(text, this.TextPos);


        if (!(oc == this.Stat.Quote[0]))
        {
            return false;
        }





        this.TextPos.Col = range.Col.End - 1;



        oc = this.TextInfra.GetChar(text, this.TextPos);


        if (!(oc == this.Stat.Quote[0]))
        {
            return false;
        }





        int count;


        count = kk - 2;




        int start;



        start = range.Col.Start + 1;




        int index;




        char c;




        bool b;



        bool bb;




        bool bba;



        int j;




        char u;





        int i;


        i = 0;





        while (i < count)
        {
            index = start + i;



            this.TextPos.Col = index;



            c = this.TextInfra.GetChar(text, this.TextPos);



            b = (c == this.Stat.BackSlash[0]);
            
            

            if (b)
            {
                j = i + 1;



                bb = (j < count);



                if (!bb)
                {
                    return false;
                }


                
                this.TextPos.Col = start + j;




                u = this.TextInfra.GetChar(text, this.TextPos);




                bba = false;

                
                if (u == this.Stat.Quote[0])
                {
                    bba = true;
                }
                
                if (u == 't')
                {
                    bba = true;
                }
                
                if (u == 'n')
                {
                    bba = true;
                }
                
                if (u == this.Stat.BackSlash[0])
                {
                    bba = true;
                }

                

                if (!bba)
                {
                    return false;
                }




                i = i + 1;
            }




            if (!b)
            {
                bb = (c == this.Stat.Quote[0]);



                if (bb)
                {
                    return false;
                }                
            }




            i = i + 1;
        }




        return true;
    }






    private bool ExecuteValueString(Text text, TextRange range)
    {
        int kk;



        kk = this.RangeInfra.Count(range.Col);





        this.TextPos.Row = range.Row;





        int count;


        count = kk - 2;




        int start;



        start = range.Col.Start + 1;




        int index;




        char c;




        bool b;



        bool bb;





        int j;




        char u;




        char escapeValue;




        int i;


        i = 0;





        while (i < count)
        {
            index = start + i;



            this.TextPos.Col = index;




            c = this.TextInfra.GetChar(text, this.TextPos);



            b = (c == this.Stat.BackSlash[0]);
            
            

            if (b)
            {
                j = i + 1;



                bb = (j < count);



                if (bb)
                {
                    this.TextPos.Col = start + j;



                    u = this.TextInfra.GetChar(text, this.TextPos);




                    escapeValue = char.MinValue;

                    
                    if (u == this.Stat.Quote[0])
                    {
                        escapeValue = u;
                    }

                    if (u == 't')
                    {
                        escapeValue = this.Stat.Tab[0];
                    }
                    
                    if (u == 'n')
                    {
                        escapeValue = this.Stat.NewLine[0];
                    }
                    
                    if (u == this.Stat.BackSlash[0])
                    {
                        escapeValue = u;
                    }




                    this.ExecuteValueChar(escapeValue);




                    i = i + 1;
                }
            }




            if (!b)
            {
                this.ExecuteValueChar(c);
            }




            i = i + 1;
        }




        return true;
    }






    private bool ExecuteValueChar(char oc)
    {
        this.WriteOperate.ExecuteChar(oc);



        return true;
    }






    private WriteOperate WriteOperate { get; set; }




    internal virtual char[] Array { get; set; }



    internal virtual int Index { get; set; }






    public virtual string EscapeString(string a)
    {
        string k;
        
        
        k = a;


        k = k.Replace("\\", "\\\\");


        k = k.Replace("\"", "\\\"");


        k = k.Replace("\t", "\\t");


        k = k.Replace("\n", "\\n");


        k = k.Replace("\r", "\\r");



        string ret;

        ret = k;

        return ret;
    }
}