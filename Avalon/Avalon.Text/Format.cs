namespace Avalon.Text;





public class Format : Any
{
    public override bool Init()
    {
        base.Init();




        this.InternIntern = InternIntern.This;


        this.InternInfra = InternInfra.This;


        this.InfraInfra = InfraInfra.This;




        this.InternReturn = Extern.Return_New();


        Extern.Return_Init(this.InternReturn);




        this.InternArgString = Extern.String_New();


        Extern.String_Init(this.InternArgString);




        this.InternText = Extern.String_New();


        Extern.String_Init(this.InternText);




        this.Intern = Extern.Format_New();


        Extern.Format_Init(this.Intern);




        return true;
    }





    public virtual bool Final()
    {
        Extern.Format_Final(this.Intern);


        Extern.Format_Delete(this.Intern);



        Extern.String_Final(this.InternText);


        Extern.String_Delete(this.InternText);



        Extern.String_Final(this.InternArgString);


        Extern.String_Delete(this.InternArgString);



        Extern.Return_Final(this.InternReturn);


        Extern.Return_Delete(this.InternReturn);



        return true;
    }




    public virtual Span Base { get; set; }


    public virtual Span Text { get; set; }




    private InternIntern InternIntern { get; set; }


    private InternInfra InternInfra { get; set; }


    private InfraInfra InfraInfra { get; set; }



    private ulong Intern { get; set; }


    private ulong InternText { get; set; }


    private ulong InternBase { get; set; }


    private ulong InternArgString { get; set; }


    private ulong InternReturn { get; set; }


    private ulong InternNumberResult { get; set; }
    



    public virtual bool ExecuteStart()
    {
        InfraRange range;

        range = this.Base.Range;



        int count;

        count = this.InfraInfra.Count(range);


    

        this.InternBase = this.InternInfra.StringCreateText(this.Base.Data, range.Start, count);




        Extern.Format_SetBase(this.Intern, this.InternBase);




        Extern.Format_ExecuteStart(this.Intern);



        return true;
    }






    public virtual int ExecuteCount()
    {
        ulong u;

        u = 0;



        bool b;

        b = (this.InternNumberResult == 0);


        if (b)
        {
            u = Extern.Format_ExecuteEnd(this.Intern);
        }


        if (!b)
        {
            u = this.InternNumberResult;
        }
        



        Extern.Return_SetString(this.InternReturn, u);



        if (!b)
        {
            this.InternNumberResult = 0;
        }

        


        Extern.Return_StringStart(this.InternReturn);




        ulong countU;

        countU = Extern.Return_StringCount(this.InternReturn);



        int a;

        a = (int)countU;



        return a;
    }





    public virtual bool ExecuteResult()
    {
        InfraRange range;

        range = this.Text.Range;



        ulong indexU;

        indexU = (ulong)range.Start;



        int count;

        count = this.InfraInfra.Count(range);



        ulong countU;

        countU = (ulong)count;




        this.InternIntern.ReturnStringResult(this.InternReturn, this.Text.Data, indexU, countU, this.InternText);




        Extern.Return_StringEnd(this.InternReturn);




        Extern.Return_SetString(this.InternReturn, 0);




        return true;
    }






    public virtual bool ExecuteEnd()
    {
        if (!(this.InternBase == 0))
        {
            Extern.Format_SetBase(this.Intern, 0);



            this.InternInfra.StringDelete(this.InternBase);



            this.InternBase = 0;
        }



        return true;
    }





    public virtual bool ExecuteULongStart(ulong integer, int integerBase)
    {
        ulong baseU;

        baseU = (ulong)integerBase;



        ulong u;

        u = Extern.Format_ExecuteInt(this.Intern, integer, baseU);



        this.InternNumberResult = u;



        return true;
    }





    public virtual bool ExecuteLongStart(long integer, int integerBase)
    {
        ulong integerU;

        integerU = (ulong)integer;



        ulong baseU;

        baseU = (ulong)integerBase;




        ulong u;

        u = Extern.Format_ExecuteSInt(this.Intern, integerU, baseU);



        this.InternNumberResult = u;



        return true;
    }





    public virtual bool ExecuteFloatStart(long numberFloat, int floatFormat, int precision)
    {
        ulong floatU;

        floatU = (ulong)numberFloat;


        ulong floatFormatU;

        floatFormatU = (ulong)floatFormat;


        ulong precisionU;
        
        precisionU = (ulong)precision;




        ulong u;

        u = Extern.Format_ExecuteFloat(this.Intern, floatU, floatFormatU, precisionU);



        this.InternNumberResult = u;



        return true;
    }







    public virtual bool ArgString(string value, int fieldWidth, char fillChar)
    {
        int count;

        count = value.Length;


        ulong countU;

        countU = (ulong)count;



        ulong fieldWidthU;

        fieldWidthU = (ulong)fieldWidth;



        ulong fillCharU;

        fillCharU = (ulong)fillChar;




        Extern.String_SetCount(this.InternArgString, countU);



        this.InternIntern.FormatArgString(this.Intern, value, fieldWidthU, fillCharU, this.InternArgString);



        return true;
    }






    public virtual bool ArgChar(char value, int fieldWidth, char fillChar)
    {
        ulong valueU;

        valueU = (ulong)value;



        ulong fieldWidthU;

        fieldWidthU = (ulong)fieldWidth;



        ulong fillCharU;

        fillCharU = (ulong)fillChar;




        Extern.Format_ArgChar(this.Intern, valueU, fieldWidthU, fillCharU);




        return true;
    }






    public virtual bool ArgULong(ulong value, int fieldWidth, int varBase, char fillChar)
    {
        ulong fieldWidthU;

        fieldWidthU = (ulong)fieldWidth;


        ulong baseU;

        baseU = (ulong)varBase;


        ulong fillCharU;

        fillCharU = (ulong)fillChar;



        Extern.Format_ArgInt(this.Intern, value, fieldWidthU, baseU, fillCharU);



        return true;
    }




    public virtual bool ArgLong(long value, int fieldWidth, int varBase, char fillChar)
    {
        ulong valueU;

        valueU = (ulong)value;



        ulong fieldWidthU;

        fieldWidthU = (ulong)fieldWidth;


        ulong baseU;

        baseU = (ulong)varBase;


        ulong fillCharU;

        fillCharU = (ulong)fillChar;



        Extern.Format_ArgSInt(this.Intern, valueU, fieldWidthU, baseU, fillCharU);



        return true;
    }





    public virtual bool ArgFloat(long value, int fieldWidth, int format, int precision, char fillChar)
    {
        ulong valueU;

        valueU = (ulong)value;


        ulong fieldWidthU;

        fieldWidthU = (ulong)fieldWidth;


        ulong formatU;

        formatU = (ulong)format;


        ulong precisionU;

        precisionU = (ulong)precision;


        ulong fillCharU;

        fillCharU = (ulong)fillChar;




        Extern.Format_ArgFloat(this.Intern, valueU, fieldWidthU, formatU, precisionU, fillCharU);




        return true;
    }
}