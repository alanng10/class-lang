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
        if (!(this.Intern == null))
        {
            this.Intern.Dispose();
        }
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
        SystemProgramInfo ka;
        ka = new SystemProgramInfo();

        string nameK;
        nameK = this.StringValue.ExecuteIntern(this.Name);

        ka.FileName = nameK;

        Iter iter;
        iter = this.Argue.IterCreate();
        this.Argue.IterSet(iter);
        while (iter.Next())
        {
            String kaa;
            kaa = iter.Value as String;

            string kab;
            kab = this.StringValue.ExecuteIntern(kaa);

            ka.ArgumentList.Add(kab);
        }

        string workFoldK;
        workFoldK = "";
        bool ba;
        ba = !(this.WorkFold == null);
        if (ba)
        {
            workFoldK = this.StringValue.ExecuteIntern(this.WorkFold);
        }

        ka.WorkingDirectory = workFoldK;

        if (!(this.Environ == null))
        {
            
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

    private bool EnvironSet(SystemProgramInfo k)
    {
        Iter iter;
        iter = this.Environ.IterCreate();
        this.Environ.IterSet(iter);
        while (iter.Next())
        {
            String index;
            String value;
            index = iter.Index as String;
            value = iter.Value as String;

            string indexK;
            string valueK;
            indexK = this.StringValue.ExecuteIntern(index);
            valueK = null;

            bool b;
            b = (value == null);

            if (b)
            {
                if (k.Environment.ContainsKey(indexK))
                {
                    k.Environment.Remove(indexK);
                }
            }

            if (!b)
            {
                valueK = this.StringValue.ExecuteIntern(value);

                bool ba;
                ba = k.Environment.ContainsKey(indexK);

                if (ba)
                {
                    k.Environment[indexK] = valueK;
                }

                if (!ba)
                {
                    k.Environment.Add(indexK, valueK);
                }
            }
        }

        return true;
    }
}