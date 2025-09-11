namespace Saber.Console;

public class LibraryGen : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.StorageComp = StorageComp.This;

        this.ClassInitGen = this.CreateClassInitGen();

        this.ClassBaseGen = this.CreateClassBaseGen();

        this.ClassCompGen = this.CreateClassCompGen();

        this.ClassGen = this.CreateClassGen();

        this.StringTravel = this.CreateStringTravel();

        this.ImportArgGen = this.CreateImportArgGen();

        this.ProjectGen = this.CreateProjectGen();

        this.ModuleRefStringGen = this.CreateModuleRefStringGen();

        this.ModuleRef = this.CreateModuleRef();

        this.SSystemDotInfra = this.S("System.Infra");
        this.SIntern = this.S("Intern");
        this.SExtern = this.S("Extern");
        this.SC = this.S("c");
        this.SH = this.S("h");
        this.SPro = this.S("pro");
        this.STxt = this.S("txt");
        this.SModule = this.S("Module");
        this.SImport = this.S("Import");
        this.SExe = this.S("Exe");
        this.SMain = this.S("Main");
        return true;
    }

    protected virtual ClassInitGen CreateClassInitGen()
    {
        ClassInitGen a;
        a = new ClassInitGen();
        a.Init();
        return a;
    }

    protected virtual ClassBaseGen CreateClassBaseGen()
    {
        ClassBaseGen a;
        a = new ClassBaseGen();
        a.Init();
        return a;
    }

    protected virtual ClassCompGen CreateClassCompGen()
    {
        ClassCompGen a;
        a = new ClassCompGen();
        a.Init();
        return a;
    }

    protected virtual ClassGen CreateClassGen()
    {
        ClassGen a;
        a = new ClassGen();
        a.Init();
        return a;
    }

    protected virtual StringTravel CreateStringTravel()
    {
        StringTravel a;
        a = new StringTravel();
        a.Init();
        return a;
    }

    protected virtual ImportArgGen CreateImportArgGen()
    {
        ImportArgGen a;
        a = new ImportArgGen();
        a.Init();
        return a;
    }

    protected virtual ProjectGen CreateProjectGen()
    {
        ProjectGen a;
        a = new ProjectGen();
        a.Init();
        return a;
    }

    protected virtual ModuleRefStringGen CreateModuleRefStringGen()
    {
        ModuleRefStringGen a;
        a = new ModuleRefStringGen();
        a.Init();
        return a;
    }

    protected virtual ModuleRef CreateModuleRef()
    {
        return this.ClassInfra.ModuleRefCreate(null, 0);
    }

    public virtual ClassModule Module { get; set; }
    public virtual String ModuleRefString { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual SystemClass SystemClass { get; set; }
    public virtual String ClassPath { get; set; }
    public virtual long Status { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual ClassInitGen ClassInitGen { get; set; }
    protected virtual ClassBaseGen ClassBaseGen { get; set; }
    protected virtual ClassCompGen ClassCompGen { get; set; }
    protected virtual ClassGen ClassGen { get; set; }
    protected virtual StringTravel StringTravel { get; set; }
    protected virtual ImportArgGen ImportArgGen { get; set; }
    protected virtual ProjectGen ProjectGen { get; set; }
    protected virtual ModuleRefStringGen ModuleRefStringGen { get; set; }
    protected virtual Array InitArray { get; set; }
    protected virtual Array BaseArray { get; set; }
    protected virtual Array CompArray { get; set; }
    protected virtual String ModuleProjectText { get; set; }
    protected virtual String ModuleExeText { get; set; }
    protected virtual String GenModuleFoldPath { get; set; }
    protected virtual String ImportArg { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual String ModuleExeString { get; set; }
    protected virtual String SSystemDotInfra { get; set; }
    protected virtual String SIntern { get; set; }
    protected virtual String SExtern { get; set; }
    protected virtual String SC { get; set; }
    protected virtual String SH { get; set; }
    protected virtual String SPro { get; set; }
    protected virtual String STxt { get; set; }
    protected virtual String SModule { get; set; }
    protected virtual String SImport { get; set; }
    protected virtual String SExe { get; set; }
    protected virtual String SMain { get; set; }

    public virtual bool Load()
    {
        // this.ModuleProjectText = this.StorageInfra.TextRead(this.S("Saber.Console.data/ModuleProject.txt"));

        // if (this.ModuleProjectText == null)
        // {
        //     return false;
        // }

        this.ModuleExeText = this.StorageInfra.TextRead(this.S("Saber.Console.data/ModuleExe.txt"));

        if (this.ModuleExeText == null)
        {
            return false;
        }

        return true;
    }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.InitArray = null;
        this.BaseArray = null;
        this.CompArray = null;
        this.ModuleExeString = null;
        this.GenModuleFoldPath = null;
        this.ImportArg = null;
        this.ModuleRef.Name = null;

        return b;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;

        String genFoldPath;
        genFoldPath = this.S("Saber.Console.data/Gen");

        String combine;
        combine = this.TextInfra.PathCombine;

        this.GenModuleFoldPath = this.AddClear().Add(genFoldPath).Add(combine).Add(this.ModuleRefString).AddResult();

        this.ExecuteInit();

        this.ExecuteBase();

        this.ExecuteComp();

        bool b;
        b = this.StorageComp.FoldCreate(this.GenModuleFoldPath);

        if (!b)
        {
            this.Status = 10;
            return false;
        }

        b = this.ExecuteClassSource();
        if (!b)
        {
            this.Status = 20;
            return false;
        }

        b = this.ExecuteImportArg();
        if (!b)
        {
            this.Status = 30;
            return false;
        }

        b = this.ExecuteMakeLib();
        if (!b)
        {
            this.Status = 40;
            return false;
        }

        if (!(this.Module.Entry == null))
        {
            b = this.ExecuteModuleRefString();
            if (!b)
            {
                this.Status = 50;
                return false;
            }

            b = this.ExecuteModuleExeSource();
            if (!b)
            {
                this.Status = 60;
                return false;
            }

            b = this.ExecuteMakeExe();
            if (!b)
            {
                this.Status = 70;
                return false;
            }
        }

        b = this.StorageComp.FoldDelete(this.GenModuleFoldPath);

        if (!b)
        {
            this.Status = 80;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteInit()
    {
        this.ClassInitGen.Module = this.Module;
        this.ClassInitGen.AnyClass = this.SystemClass.Any;

        this.ClassInitGen.Execute();

        this.InitArray = this.ClassInitGen.Result;

        this.ClassInitGen.Result = null;
        this.ClassInitGen.AnyClass = null;
        this.ClassInitGen.Module = null;
        return true;
    }

    protected virtual bool ExecuteBase()
    {
        long count;
        count = this.Module.Class.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        this.BaseArray = array;

        Iter iter;
        iter = this.Module.Class.IterCreate();

        this.Module.Class.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            this.ClassBaseGen.Class = varClass;

            this.ClassBaseGen.Execute();

            Array a;
            a = this.ClassBaseGen.Result;

            this.ClassBaseGen.Result = null;
            this.ClassBaseGen.Class = null;

            array.SetAt(i, a);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteComp()
    {
        long count;
        count = this.Module.Class.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        this.CompArray = array;

        Iter iter;
        iter = this.Module.Class.IterCreate();

        this.Module.Class.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = iter.Value as ClassClass;
        
            Array baseArray;
            baseArray = this.BaseArray.GetAt(i) as Array;

            this.ClassCompGen.Class = varClass;
            this.ClassCompGen.BaseArray = baseArray;

            this.ClassCompGen.Execute();

            ClassComp a;
            a = this.ClassCompGen.Result;

            this.ClassCompGen.Result = null;
            this.ClassCompGen.BaseArray = null;
            this.ClassCompGen.Class = null;

            array.SetAt(i, a);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteClassSource()
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

            systemInfraModule = this.ModuleTable.Get(this.ModuleRef) as ClassModule;
        }

        ClassClass internClass;
        ClassClass externClass;
        internClass = systemInfraModule.Class.Get(this.SIntern) as ClassClass;
        externClass = systemInfraModule.Class.Get(this.SExtern) as ClassClass;

        this.ClassGen.SystemInfraModule = b;
        this.ClassGen.InternClass = internClass;
        this.ClassGen.ExternClass = externClass;
        this.ClassGen.System = this.SystemClass;

        long count;
        count = this.BaseArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Array array;
            array = this.BaseArray.GetAt(i) as Array;

            if (0x100 < array.Count)
            {
                return false;
            }

            i = i + 1;
        }

        this.StringTravel.Module = this.Module;

        this.StringTravel.Execute();

        Array stringArray;
        stringArray = this.StringTravel.Result;

        this.StringTravel.Result = null;
        this.StringTravel.Module = null;

        this.ClassGen.Module = this.Module;
        this.ClassGen.ModuleCount = this.ModuleTable.Count;
        this.ClassGen.InitArray = this.InitArray;
        this.ClassGen.BaseArray = this.BaseArray;
        this.ClassGen.CompArray = this.CompArray;
        this.ClassGen.StringArray = stringArray;

        this.ClassGen.Execute();

        String k;
        k = this.ClassGen.Result;

        this.ClassGen.Result = null;
        this.ClassGen.StringArray = null;
        this.ClassGen.CompArray = null;
        this.ClassGen.BaseArray = null;
        this.ClassGen.InitArray = null;
        this.ClassGen.ModuleCount = 0;
        this.ClassGen.Module = null;

        String combine;
        combine = this.TextInfra.PathCombine;

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.TextDot).Add(this.SC).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(combine).Add(fileName).AddResult();

        bool bab;
        bab = this.StorageInfra.TextWrite(filePath, k);

        if (!bab)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteImportArg()
    {
        Array moduleRefStringArray;
        moduleRefStringArray = this.ModuleRefStringArray();

        this.ImportArgGen.Gen = this.ClassGen;
        this.ImportArgGen.ModuleRefString = moduleRefStringArray;

        this.ImportArgGen.Execute();

        String import;
        import = this.ImportArgGen.Result;

        this.ImportArgGen.Result = null;
        this.ImportArgGen.ModuleRefString = null;
        this.ImportArgGen.Gen = null;

        String fileName;
        fileName = this.AddClear().Add(this.SImport).Add(this.ClassInfra.TextDot).Add(this.STxt).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, import);

        if (!b)
        {
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
        k = this.TextCreate(this.ModuleProjectText);
        k = this.TextPlace(k, this.TA(this.S("#Name#")), this.TB(this.ModuleRefString));
        k = this.TextPlace(k, this.TA(this.S("#Import#")), this.TB(import));
        k = this.TextPlace(k, this.TA(this.S("#ClassPath#")), this.TB(this.ClassPath));

        String ka;
        ka = this.StringCreate(k);

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.TextDot).Add(this.SPro).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, ka);

        if (!b)
        {
            this.Status = 50;
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
            k = iter.Index as ModuleRef;

            String verString;
            verString = this.ClassInfra.VerString(k.Ver);

            String a;
            a = this.ClassInfra.ModuleRefString(k.Name, verString);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    protected virtual bool ExecuteMakeLib()
    {
        return this.ExecuteMake(false);
    }

    protected virtual bool ExecuteMakeExe()
    {
        return this.ExecuteMake(true);
    }

    protected virtual bool ExecuteMake(bool exe)
    {
        Program program;
        program = null;

        ulong ka;
        ka = Extern.Environ_System();

        long kb;
        kb = (long)ka;

        bool b;
        b = (2 < kb & kb < 5);

        if (b)
        {
            program = this.CreateMakeProgramWindows(exe);
        }

        if (!b)
        {
            program = this.CreateMakeProgramLinux(exe);
        }

        program.Execute();

        program.Wait();

        long k;
        k = program.Status;

        this.FinalMakeProgram(program);

        if (!(k == 0))
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteModuleRefString()
    {
        this.ModuleRefStringGen.Gen = this.ClassGen;
        this.ModuleRefStringGen.Module = this.Module;

        this.ModuleRefStringGen.Execute();

        this.ModuleExeString = this.ModuleRefStringGen.Result;

        this.ModuleRefStringGen.Result = null;
        this.ModuleRefStringGen.Module = null;
        this.ModuleRefStringGen.Gen = null;

        return true;
    }

    protected virtual bool ExecuteModuleExeSource()
    {
        Text ka;
        ka = this.TextCreate(this.ModuleExeText);
        ka = this.TextPlace(ka, this.TA(this.S("#ModuleString#")), this.TB(this.ModuleExeString));

        String k;
        k = this.StringCreate(ka);

        String fileName;
        fileName = this.AddClear().Add(this.SMain).Add(this.ClassInfra.TextDot).Add(this.SC).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, k);

        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual Program CreateMakeProgramLinux(bool exe)
    {
        String ka;
        ka = this.TextInfra.Zero;

        if (exe)
        {
            ka = this.SExe;
        }

        List list;
        list = new List();
        list.Init();
        list.Add(this.AddClear().AddS("./Make").Add(ka).AddS(".sh").AddResult());
        list.Add(this.ModuleRefString);

        Program program;
        program = new Program();
        program.Init();
        program.Name = this.S("bash");
        program.Argue = list;
        program.WorkFold = this.S("Saber.Console.data");
        program.Environ = null;

        return program;
    }

    protected virtual Program CreateMakeProgramWindows(bool exe)
    {
        List list;
        list = new List();
        list.Init();
        list.Add(this.S("-pipe"));
        list.Add(this.S("-fno-strict-aliasing"));
        list.Add(this.S("-O0"));
        list.Add(this.S("-std=gnu11"));
        list.Add(this.S("-Wall"));
        list.Add(this.S("-Wno-ignored-attributes"));
        list.Add(this.S("-Wno-bitwise-instead-of-logical"));
        list.Add(this.S("-Wno-unused-but-set-variable"));
        list.Add(this.S("-Wno-unused-variable"));
        list.Add(this.S("-I."));
        list.Add(this.S("-I../.."));

        if (!exe)
        {
            list.Add(this.S("-Wl,-s"));
            list.Add(this.S("-shared"));
            list.Add(this.S("-Wl,-subsystem,windows"));
        }

        Program program;
        program = new Program();
        program.Init();
        program.Name = this.S("clang.exe");
        program.Argue = list;
        program.WorkFold = this.GenModuleFoldPath;
        program.Environ = null;

        return program;
    }

    protected virtual Program CreateMakeProgramWindowsA(bool exe)
    {
        String ka;
        ka = this.TextInfra.Zero;

        if (exe)
        {
            ka = this.SExe;
        }

        List list;
        list = new List();
        list.Init();
        list.Add(this.S("/c"));
        list.Add(this.AddClear().AddS("MakeLib").Add(ka).AddS(".cmd ").Add(this.ModuleRefString).AddResult());

        Program program;
        program = new Program();
        program.Init();
        program.Name = this.S("cmd.exe");
        program.Argue = list;
        program.WorkFold = this.S("Saber.Console.data");
        program.Environ = null;

        return program;
    }

    protected virtual bool FinalMakeProgram(Program a)
    {
        a.Final();
        return true;
    }
}