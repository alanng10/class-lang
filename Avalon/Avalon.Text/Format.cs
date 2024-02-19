namespace Avalon.Text;





public class Format : Any
{
    public override bool Init()
    {
        base.Init();


        this.InternIntern = InternIntern.This;

        this.InternInfra = InternInfra.This;

        this.InfraInfra = InfraInfra.This;


        this.InternResult = Extern.String_New();

        Extern.String_Init(this.InternResult);


        this.Intern = Extern.Format_New();

        Extern.Format_Init(this.Intern);

        return true;
    }





    public virtual bool Final()
    {
        Extern.Format_Final(this.Intern);
        Extern.Format_Delete(this.Intern);

        Extern.String_Final(this.InternResult);
        Extern.String_Delete(this.InternResult);

        if (!(this.InternBase == 0))
        {
            this.InternInfra.StringDelete(this.InternBase);
        }

        return true;
    }




    public virtual Span Base { get; set; }


    public virtual FormatArgList ArgList { get; set; }



    private InternIntern InternIntern { get; set; }

    private InternInfra InternInfra { get; set; }

    private InfraInfra InfraInfra { get; set; }


    private ulong Intern { get; set; }

    private ulong InternResult { get; set; }

    private ulong InternBase { get; set; }

    

    public virtual bool SetBase()
    {
        if (!(this.InternBase == 0))
        {
            this.InternInfra.StringDelete(this.InternBase);
        }


        this.InternBase = 0;


        if (!(this.Base == null))
        {
            InfraRange range;
            range = this.Base.Range;

            int count;
            count = this.InfraInfra.Count(range);

            this.InternBase = this.InternInfra.StringCreateText(this.Base.Data, range.Start, count);

        }


        Extern.Format_SetBase(this.Intern, this.InternBase);

        return true;
    }


    public virtual bool SetArgList()
    {
        ulong u;

        u = 0;

        if (!(this.ArgList == null))
        {
            u = this.ArgList.Intern;
        }

        Extern.Format_SetArgList(this.Intern, u);

        return true;
    }


    public virtual int ExecuteCount()
    {
        ulong u;

        u = Extern.Format_ExecuteCount(this.Intern);

        int a;
        
        a = (int)u;

        return a;
    }


    public virtual bool ExecuteResult(Span result)
    {
        InfraRange range;
        range = result.Range;

        int index;
        index = range.Start;

        int count;
        count = this.InfraInfra.Count(range);

        ulong indexU;
        indexU = (ulong)index;

        ulong countU;
        countU = (ulong)count;


        this.InternIntern.FormatResult(this.Intern, result.Data, indexU, countU, this.InternResult);

        return true;
    }


    public virtual int ExecuteArgCount(FormatArg arg)
    {
        ulong u;
        u = Extern.Format_ExecuteArgCount(this.Intern, arg.Intern);

        int a;
        a = (int)u;

        return a;
    }


    public virtual bool ExecuteArgResult(FormatArg arg, Span result)
    {
        InfraRange range;
        range = result.Range;

        int index;
        index = range.Start;

        int count;
        count = this.InfraInfra.Count(range);

        ulong indexU;
        indexU = (ulong)index;

        ulong countU;
        countU = (ulong)count;


        this.InternIntern.FormatArgResult(this.Intern, arg.Intern, result.Data, indexU, countU, this.InternResult);

        return true;
    }
}