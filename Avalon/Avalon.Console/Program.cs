namespace Avalon.Console;

public class Program : Any
{
    public override bool Init()
    {
        base.Init();
        this.StringValue = StringValue.This;
        return true;
    }

    public virtual bool Final()
    {
        return true;
    }

    public virtual String Name { get; set; }
    public virtual ListList Argue { get; set; }
    public virtual String WorkFold { get; set; }
    public virtual Table Environ { get; set; }

    public virtual long Status
    {
        get
        {
            int k;
            try
            {
                k = this.Intern.ExitCode;
            }
            catch
            {
                return -1;
            }

            long a;
            a = k;
            return a;
        }
        set
        {
        }
    }

    protected virtual StringValue StringValue { get; set; }
    private SystemProgram Intern { get; set; }

    public virtual bool Wait()
    {
        try
        {
            this.Intern.WaitForExit();
        }
        catch
        {
            return false;
        }
        return true;
    }

    public virtual bool Exit()
    {
        try
        {
            this.Intern.Kill(true);
        }
        catch
        {
            return false;
        }
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

        ulong environU;
        environU = 0;
        bool bb;
        bb = !(this.Environ == null);
        if (bb)
        {
            environU = this.InternStringEntryListCreate(this.Environ);
        }

        Extern.Program_NameSet(this.Intern, nameU);
        Extern.Program_ArgueSet(this.Intern, argueU);
        Extern.Program_WorkFoldSet(this.Intern, workFoldU);
        Extern.Program_EnvironSet(this.Intern, environU);

        Extern.Program_Execute(this.Intern);

        Extern.Program_EnvironSet(this.Intern, 0);
        Extern.Program_WorkFoldSet(this.Intern, 0);
        Extern.Program_ArgueSet(this.Intern, 0);
        Extern.Program_NameSet(this.Intern, 0);

        if (bb)
        {
            this.InternStringEntryListDelete(environU);
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
        long count;
        count = stringList.Count;
        ulong countU;
        countU = (ulong)count;

        ulong a;
        a = Extern.Array_New();
        Extern.Array_CountSet(a, countU);
        Extern.Array_Init(a);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            String ka;
            ka = iter.Value as String;

            ulong k;
            k = this.InternInfra.StringCreate(ka);

            ulong oa;
            oa = (ulong)i;
            Extern.Array_ItemSet(a, oa, k);

            i = i + 1;
        }
        return a;
    }

    private bool InternStringListDelete(ulong a)
    {
        ulong countU;
        countU = Extern.Array_CountGet(a);
        long count;
        count = (long)countU;

        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = count - 1 - i;

            ulong oa;
            oa = (ulong)index;

            ulong k;
            k = Extern.Array_ItemGet(a, oa);

            this.InternInfra.StringDelete(k);

            i = i + 1;
        }

        Extern.Array_Final(a);
        Extern.Array_Delete(a);
        return true;
    }

    private ulong InternStringEntryListCreate(Table stringTable)
    {
        Iter iter;
        iter = stringTable.IterCreate();
        stringTable.IterSet(iter);

        long count;
        count = stringTable.Count;
        ulong countU;
        countU = (ulong)count;

        ulong a;
        a = Extern.Array_New();
        Extern.Array_CountSet(a, countU);
        Extern.Array_Init(a);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            String index;
            String value;
            index = iter.Index as String;
            value = iter.Value as String;
            ulong ka;
            ka = this.InternInfra.StringCreate(index);
            ulong kb;
            kb = this.InternInfra.StringCreate(value);

            ulong k;
            k = Extern.Entry_New();
            Extern.Entry_Init(k);
            Extern.Entry_IndexSet(k, ka);
            Extern.Entry_ValueSet(k, kb);

            ulong oa;
            oa = (ulong)i;
            Extern.Array_ItemSet(a, oa, k);

            i = i + 1;
        }
        return a;
    }

    private bool InternStringEntryListDelete(ulong a)
    {
        ulong countU;
        countU = Extern.Array_CountGet(a);

        long count;
        count = (long)countU;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = count - 1 - i;

            ulong oa;
            oa = (ulong)index;

            ulong k;
            k = Extern.Array_ItemGet(a, oa);
            ulong ka;
            ka = Extern.Entry_IndexGet(k);
            ulong kb;
            kb = Extern.Entry_ValueGet(k);

            Extern.Entry_Final(k);
            Extern.Entry_Delete(k);

            this.InternInfra.StringDelete(kb);
            this.InternInfra.StringDelete(ka);

            i = i + 1;
        }

        Extern.Array_Final(a);
        Extern.Array_Delete(a);
        return true;
    }
}