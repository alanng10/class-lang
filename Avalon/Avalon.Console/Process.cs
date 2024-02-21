namespace Avalon.Console;

public class Process : Any
{
    public override bool Init()
    {
        base.Init();





        this.InternIntern = InternIntern.This;


        this.InternInfra = InternInfra.This;


        this.ConsoleInfra = Infra.This;




        this.InternHandle = new Handle();

        this.InternHandle.Any = this;

        this.InternHandle.Init();




        MaideAddress oa;

        oa = this.ConsoleInfra.ProcessStartedMaideAddress;



        MaideAddress ob;

        ob = this.ConsoleInfra.ProcessFinishedMaideAddress;




        ulong arg;


        arg = this.InternHandle.ULong();




        this.InternStartedState = this.InternInfra.StateCreate(oa, arg);


        this.InternFinishedState = this.InternInfra.StateCreate(ob, arg);




        this.Intern = Extern.Process_New();


        Extern.Process_Init(this.Intern);



        Extern.Process_SetStartedState(this.Intern, this.InternStartedState);



        Extern.Process_SetFinishedState(this.Intern, this.InternFinishedState);




        return true;
    }




    public virtual bool Final()
    {
        Extern.Process_Final(this.Intern);


        Extern.Process_Delete(this.Intern);



        this.InternInfra.StateDelete(this.InternFinishedState);


        this.InternInfra.StateDelete(this.InternStartedState);



        this.InternHandle.Final();




        return true;
    }




    public virtual string Program { get; set; }



    public virtual ListList Argue { get; set; }



    public virtual string WorkFold { get; set; }



    public virtual Table Environment { get; set; }




    public virtual State StartedState { get; set; }


    public virtual State FinishedState { get; set; }






    private InternIntern InternIntern { get; set; }



    private InternInfra InternInfra { get; set; }



    private Infra ConsoleInfra { get ;set; }




    private ulong Intern { get; set; }


    private ulong InternFinishedState { get; set; }


    private ulong InternStartedState { get; set; }


    private Handle InternHandle { get; set; }






    internal static ulong InternStarted(ulong process, ulong arg)
    {
        InternIntern internIntern;

        internIntern = InternIntern.This;




        object ao;

        ao = internIntern.HandleTarget(arg);




        Process a;

        a = (Process)ao;



        a.ExecuteStartedState();




        return 1;
    }





    internal static ulong InternFinished(ulong process, ulong arg)
    {
        InternIntern internIntern;

        internIntern = InternIntern.This;




        object ao;

        ao = internIntern.HandleTarget(arg);




        Process a;

        a = (Process)ao;



        a.ExecuteFinishedState();




        return 1;
    }





    private bool ExecuteStartedState()
    {
        if (!(this.StartedState == null))
        {
            this.StartedState.Execute();
        }



        return true;
    }




    private bool ExecuteFinishedState()
    {
        if (!(this.FinishedState == null))
        {
            this.FinishedState.Execute();
        }



        return true;
    }




    public virtual int Ident
    {
        get
        {
            ulong u;

            u = Extern.Process_GetIdent(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }



    public virtual int Status
    {
        get
        {
            ulong u;

            u = Extern.Process_GetStatus(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }





    public virtual int ExitKind
    {
        get
        {
            ulong u;

            u = Extern.Process_GetExitKind(this.Intern);



            int a;

            a = (int)u;


            return a;
        }
        set
        {
        }
    }





    public virtual bool Wait()
    {
        Extern.Process_Wait(this.Intern);



        return true;
    }




    public virtual bool Terminate()
    {
        Extern.Process_Terminate(this.Intern);



        return true;
    }

    




    public virtual bool Execute()
    {
        ulong programU;

        programU = this.InternInfra.StringCreate(this.Program);



        ulong argueU;

        argueU = this.InternStringListCreate(this.Argue);




        ulong workFoldU;

        workFoldU = 0;


        bool ba;

        ba = !(this.WorkFold == null);

        
        if (ba)
        {
            workFoldU = this.InternInfra.StringCreate(this.WorkFold);
        }




        ulong environmentU;

        environmentU = 0;


        bool bb;

        bb = !(this.Environment == null);


        if (bb)
        {
            environmentU = this.InternStringEntryListCreate(this.Environment);
        }




        Extern.Process_SetProgram(this.Intern, programU);



        Extern.Process_SetArgue(this.Intern, argueU);



        Extern.Process_SetWorkFold(this.Intern, workFoldU);



        Extern.Process_SetEnvironment(this.Intern, environmentU);



        Extern.Process_Execute(this.Intern);




        if (bb)
        {
            this.InternStringEntryListDelete(environmentU);
        }



        if (ba)
        {
            this.InternInfra.StringDelete(workFoldU);
        }



        this.InternStringListDelete(argueU);



        this.InternInfra.StringDelete(programU);
        


        return true;
    }





    private ulong InternStringListCreate(ListList stringList)
    {
        Iter iter;


        iter = stringList.CreateIter();



        stringList.SetIter(iter);




        int count;

        count = stringList.Count;



        ulong countU;

        countU = (ulong)count;



        ulong a;


        a = Extern.Array_New();


        Extern.Array_SetCount(a, countU);


        Extern.Array_Init(a);




        int i;

        i = 0;


        while (i < count)
        {
            iter.Next();



            string o;
            

            o = (string)iter.Value;



            ulong u;

            u = this.InternInfra.StringCreate(o);



            ulong oa;

            oa = (ulong)i;



            Extern.Array_SetItem(a, oa, u);



            i = i + 1;
        }




        return a;
    }





    private bool InternStringListDelete(ulong o)
    {
        ulong countU;

        countU = Extern.Array_GetCount(o);



        int count;

        count = (int)countU;


        int i;

        i = 0;


        while (i < count)
        {
            ulong oa;

            oa = (ulong)i;



            ulong u;

            u = Extern.Array_GetItem(o, oa);



            this.InternInfra.StringDelete(u);



            i = i + 1;
        }




        Extern.Array_Final(o);


        Extern.Array_Delete(o);




        return true;
    }








    private ulong InternStringEntryListCreate(Table stringTable)
    {
        Iter iter;


        iter = stringTable.CreateIter();



        stringTable.SetIter(iter);




        int count;

        count = stringTable.Count;



        ulong countU;

        countU = (ulong)count;



        ulong a;


        a = Extern.Array_New();


        Extern.Array_SetCount(a, countU);


        Extern.Array_Init(a);




        int i;

        i = 0;


        while (i < count)
        {
            iter.Next();




            string index;

            string value;


            index = (string)(iter.Index);

            value = (string)(iter.Value);



            ulong indexU;

            indexU = this.InternInfra.StringCreate(index);


            ulong valueU;

            valueU = this.InternInfra.StringCreate(value);



            ulong entryU;

            entryU = Extern.Entry_New();


            Extern.Entry_Init(entryU);


            Extern.Entry_SetIndex(entryU, indexU);


            Extern.Entry_SetValue(entryU, valueU);




            ulong oa;

            oa = (ulong)i;



            Extern.Array_SetItem(a, oa, entryU);



            i = i + 1;
        }




        return a;
    }





    private bool InternStringEntryListDelete(ulong o)
    {
        ulong countU;

        countU = Extern.Array_GetCount(o);



        int count;

        count = (int)countU;


        int i;

        i = 0;


        while (i < count)
        {
            ulong oa;

            oa = (ulong)i;



            ulong entryU;

            entryU = Extern.Array_GetItem(o, oa);



            ulong indexU;

            indexU = Extern.Entry_GetIndex(entryU);


            ulong valueU;

            valueU = Extern.Entry_GetValue(entryU);



            Extern.Entry_Final(entryU);


            Extern.Entry_Delete(entryU);



            this.InternInfra.StringDelete(valueU);


            this.InternInfra.StringDelete(indexU);



            i = i + 1;
        }




        Extern.Array_Final(o);


        Extern.Array_Delete(o);




        return true;
    }
}