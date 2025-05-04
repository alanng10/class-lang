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
            iter = this.Environ.IterCreate();
            this.Environ.IterSet(iter);
            while (iter.Next())
            {
                String kba;
                String kbb;
                kba = iter.Index as String;
                kbb = iter.Value as String;

                string kca;
                string kcb;
                kca = this.StringValue.ExecuteIntern(kba);
                kcb = null;

                bool bb;
                bb = (kbb == null);

                if (bb)
                {
                    if (ka.Environment.ContainsKey(kca))
                    {
                        ka.Environment.Remove(kca);
                    }
                }

                if (!bb)
                {
                    kcb = this.StringValue.ExecuteIntern(kbb);

                    bool baa;
                    baa = ka.Environment.ContainsKey(kca);

                    if (baa)
                    {
                        ka.Environment[kca] = kcb;
                    }

                    if (!baa)
                    {
                        ka.Environment.Add(kca, kcb);
                    }
                }
            }
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
}