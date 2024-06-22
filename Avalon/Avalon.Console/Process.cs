namespace Avalon.Console;

public class Program : Any
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
        oa = this.ConsoleInfra.ProcessStartMaideAddress;
        MaideAddress ob;
        ob = this.ConsoleInfra.ProcessFinishMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();

        this.InternStartState = this.InternInfra.StateCreate(oa, arg);
        this.InternFinishState = this.InternInfra.StateCreate(ob, arg);

        this.Intern = Extern.Process_New();
        Extern.Process_Init(this.Intern);
        Extern.Process_StartStateSet(this.Intern, this.InternStartState);
        Extern.Process_FinishStateSet(this.Intern, this.InternFinishState);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Process_FinishStateSet(this.Intern, 0);
        Extern.Process_StartStateSet(this.Intern, 0);
        
        Extern.Process_Final(this.Intern);
        Extern.Process_Delete(this.Intern);

        this.InternInfra.StateDelete(this.InternFinishState);
        this.InternInfra.StateDelete(this.InternStartState);

        this.InternHandle.Final();
        return true;
    }

    public virtual string Name { get; set; }
    public virtual ListList Argue { get; set; }
    public virtual string WorkFold { get; set; }
    public virtual Table Environment { get; set; }

    public virtual State StartState { get; set; }
    public virtual State FinishState { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra ConsoleInfra { get ;set; }
    private ulong Intern { get; set; }
    private ulong InternFinishState { get; set; }
    private ulong InternStartState { get; set; }
    private Handle InternHandle { get; set; }

    internal static ulong InternStart(ulong process, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Program a;
        a = (Program)ao;
        a.ExecuteStartState();

        return 1;
    }

    internal static ulong InternFinish(ulong process, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Program a;
        a = (Program)ao;
        a.ExecuteFinishState();

        return 1;
    }

    protected virtual bool ExecuteStartState()
    {
        if (!(this.StartState == null))
        {
            this.StartState.Execute();
        }
        return true;
    }

    protected virtual bool ExecuteFinishState()
    {
        if (!(this.FinishState == null))
        {
            this.FinishState.Execute();
        }
        return true;
    }

    public virtual int Ident
    {
        get
        {
            ulong u;
            u = Extern.Process_IdentGet(this.Intern);
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
            u = Extern.Process_StatusGet(this.Intern);
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
            u = Extern.Process_ExitKindGet(this.Intern);
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
        ulong nameU;
        nameU = this.InternInfra.StringCreate(this.Name);
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

        Extern.Process_ProgramSet(this.Intern, nameU);
        Extern.Process_ArgueSet(this.Intern, argueU);
        Extern.Process_WorkFoldSet(this.Intern, workFoldU);
        Extern.Process_EnvironmentSet(this.Intern, environmentU);

        Extern.Process_Execute(this.Intern);

        Extern.Process_EnvironmentSet(this.Intern, 0);
        Extern.Process_WorkFoldSet(this.Intern, 0);
        Extern.Process_ArgueSet(this.Intern, 0);
        Extern.Process_ProgramSet(this.Intern, 0);

        if (bb)
        {
            this.InternStringEntryListDelete(environmentU);
        }
        if (ba)
        {
            this.InternInfra.StringDelete(workFoldU);
        }
        
        this.InternStringListDelete(argueU);

        this.InternInfra.StringDelete(nameU);
        return true;
    }

    private ulong InternStringListCreate(ListList stringList)
    {
        Iter iter;
        iter = stringList.IterCreate();
        stringList.IterSet(iter);
        int count;
        count = stringList.Count;
        ulong countU;
        countU = (ulong)count;

        ulong a;
        a = Extern.Array_New();
        Extern.Array_CountSet(a, countU);
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
            Extern.Array_ItemSet(a, oa, u);

            i = i + 1;
        }
        return a;
    }

    private bool InternStringListDelete(ulong o)
    {
        ulong countU;
        countU = Extern.Array_CountGet(o);
        int count;
        count = (int)countU;

        int i;
        i = 0;
        while (i < count)
        {
            int index;
            index = count - 1 - i;

            ulong oa;
            oa = (ulong)index;

            ulong u;
            u = Extern.Array_ItemGet(o, oa);

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
        iter = stringTable.IterCreate();
        stringTable.IterSet(iter);

        int count;
        count = stringTable.Count;
        ulong countU;
        countU = (ulong)count;

        ulong a;
        a = Extern.Array_New();
        Extern.Array_CountSet(a, countU);
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
            Extern.Entry_IndexSet(entryU, indexU);
            Extern.Entry_ValueSet(entryU, valueU);

            ulong oa;
            oa = (ulong)i;
            Extern.Array_ItemSet(a, oa, entryU);

            i = i + 1;
        }
        return a;
    }

    private bool InternStringEntryListDelete(ulong o)
    {
        ulong countU;
        countU = Extern.Array_CountGet(o);

        int count;
        count = (int)countU;
        int i;
        i = 0;
        while (i < count)
        {
            int index;
            index = count - 1 - i;

            ulong oa;
            oa = (ulong)index;
            
            ulong entryU;
            entryU = Extern.Array_ItemGet(o, oa);
            ulong indexU;
            indexU = Extern.Entry_IndexGet(entryU);
            ulong valueU;
            valueU = Extern.Entry_ValueGet(entryU);

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