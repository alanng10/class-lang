namespace Saber.Console;

public class LibraryGen : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;
        this.StorageComp = StorageComp.This;

        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);

        this.SSystemDotInfra = this.S("System.Infra");
        this.SIntern = this.S("Intern");
        this.SExtern = this.S("Extern");
        this.SC = this.S("c");
        this.SPro = this.S("pro");
        this.SModule = this.S("Module");
        return true;
    }

    public virtual ClassModule Module { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual String ModuleRefString { get; set; }
    public virtual long Status { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual ClassGen ClassGen { get; set; }
    protected virtual String GenModuleFoldPath { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual String SSystemDotInfra { get; set; }
    protected virtual String SIntern { get; set; }
    protected virtual String SExtern { get; set; }
    protected virtual String SC { get; set; }
    protected virtual String SPro { get; set; }
    protected virtual String SModule { get; set; }

    public virtual bool Execute()
    {
        String genFoldPath;
        genFoldPath = this.S("Saber.Console.Data/Gen");

        String combine;
        combine = this.TextInfra.PathCombine;

        this.GenModuleFoldPath = this.AddClear().Add(genFoldPath).Add(combine).Add(this.ModuleRefString).AddResult();

        bool bb;
        bb = this.ExecuteGenClassSource();
        if (!bb)
        {
            return false;
        }

        bool bc;
        bc = this.ExecuteGenModuleSource();
        if (!bc)
        {
            return false;
        }

        bool bd;
        bd = this.ExecuteGenProject();
        if (!bd)
        {
            return false;
        }

        bool be;
        be = this.ExecuteGenMake();
        if (!be)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteGenClassSource()
    {
        ClassModule systemInfraModule;
        systemInfraModule = null;

        bool b;
        b = this.TextSame(this.TA(this.Module.Ref.Name), this.TB(this.SSystemDotInfra));

        if (b)
        {
            systemInfraModule = this.Module;
        }

        if (!b)
        {
            this.ModuleRef.Name = this.SSystemDotInfra;
            this.ModuleRef.Ver = 0;

            systemInfraModule = (ClassModule)this.ModuleTable.Get(this.ModuleRef);
        }

        ClassClass internClass;
        ClassClass externClass;
        internClass = (ClassClass)systemInfraModule.Class.Get(this.SIntern);
        externClass = (ClassClass)systemInfraModule.Class.Get(this.SExtern);

        this.ClassGen.InternClass = internClass;
        this.ClassGen.ExternClass = externClass;
        this.ClassGen.System = this.Create.Module.SystemClass;
        this.ClassGen.ImportClass = this.ImportClass;

        this.StorageComp.FoldDelete(this.GenModuleFoldPath);

        bool baa;
        baa = this.StorageComp.FoldCreate(this.GenModuleFoldPath);

        if (!baa)
        {
            this.Status = 5000 + 15;
            return false;
        }

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);

        long count;
        count = this.Module.Class.Count;
        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            this.ClassGen.Class = varClass;

            this.ClassGen.Execute();

            String k;
            k = this.ClassGen.Result;

            this.ClassGen.Result = null;
            this.ClassGen.Class = null;

            String ka;
            ka = this.StringIntHex(i);

            String combine;
            combine = this.TextInfra.PathCombine;

            String fileName;
            fileName = this.AddClear().AddChar('C').Add(ka).Add(this.ClassInfra.Dot).Add(this.SC).AddResult();

            String filePath;
            filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(combine).Add(fileName).AddResult();

            bool bab;
            bab = this.StorageInfra.TextWrite(filePath, k);

            if (!bab)
            {
                this.Status = 5000 + 20;
                return false;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteGenModuleSource()
    {
        this.ModuleGen.Gen = this.ClassGen;
        this.ModuleGen.Module = this.Module;

        this.ModuleGen.Execute();
        String k;
        k = this.ModuleGen.Result;

        this.ModuleGen.Result = null;
        this.ModuleGen.Module = null;
        this.ModuleGen.Gen = null;

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.Dot).Add(this.SC).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, k);

        if (!b)
        {
            this.Status = 5000 + 30;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteGenProject()
    {
        Array moduleRefStringArray;
        moduleRefStringArray = this.ModuleRefStringArray();

        this.ProjectGen.Gen = this.ClassGen;
        this.ProjectGen.ModuleRefString = moduleRefStringArray;

        this.ProjectGen.Execute();

        String import;
        import = this.ProjectGen.Result;

        this.ProjectGen.Result = null;
        this.ProjectGen.ModuleRefString = null;
        this.ProjectGen.Gen = null;

        Text k;
        k = this.TA(this.ModuleProjectText);
        k = this.Place(k, "#Import#", import);

        String ka;
        ka = this.StringCreate(k);

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.Dot).Add(this.SPro).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, ka);

        if (!b)
        {
            this.Status = 5000 + 40;
            return false;
        }

        return true;
    }

    protected virtual Array ModuleRefStringArray()
    {
        long count;
        count = this.ModuleTable.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = this.ModuleTable.IterCreate();
        this.ModuleTable.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ModuleRef k;
            k = (ModuleRef)iter.Index;

            String verString;
            verString = this.ClassInfra.VerString(k.Ver);

            String a;
            a = this.ClassInfra.ModuleRefString(k.Name, verString);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    protected virtual bool ExecuteGenMake()
    {
        List list;
        list = new List();
        list.Init();
        list.Add(this.S("/c"));
        list.Add(this.AddClear().AddS("Make.cmd ").Add(this.ModuleRefString).AddResult());

        Program program;
        program = new Program();
        program.Init();
        program.Name = this.S("cmd.exe");
        program.Argue = list;
        program.WorkFold = this.S("Saber.Console.data");
        program.Environ = null;

        program.Execute();

        program.Wait();

        long k;
        k = program.Status;

        program.Final();

        if (!(k == 0))
        {
            this.Status = 5000 + 50;
            return false;
        }

        return true;
    }
}