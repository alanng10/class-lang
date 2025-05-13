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

        this.StringValueTravel = this.CreateStringValueTravel();

        this.ModuleGen = this.CreateModuleGen();

        this.ModuleHeaderGen = this.CreateModuleHeaderGen();

        this.ImportArgGen = this.CreateImportArgGen();

        this.ProjectGen = this.CreateProjectGen();

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

    public virtual ClassModule Module { get; set; }
    public virtual String ModuleRefString { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ImportClass { get; set; }
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
    protected virtual StringValueTravel StringValueTravel { get; set; }
    protected virtual ModuleGen ModuleGen { get; set; }
    protected virtual ModuleHeaderGen ModuleHeaderGen { get; set; }
    protected virtual ImportArgGen ImportArgGen { get; set; }
    protected virtual ProjectGen ProjectGen { get; set; }
    protected virtual Array ClassInitArray { get; set; }
    protected virtual Array ClassBaseArray { get; set; }
    protected virtual Array ClassCompArray { get; set; }
    protected virtual String ModuleProjectText { get; set; }
    protected virtual String ModuleExeText { get; set; }
    protected virtual String GenModuleFoldPath { get; set; }
    protected virtual String GenModuleExeFoldPath { get; set; }
    protected virtual String ImportArg { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
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

    protected virtual StringValueTravel CreateStringValueTravel()
    {
        StringValueTravel a;
        a = new StringValueTravel();
        a.Init();
        return a;
    }

    protected virtual ModuleGen CreateModuleGen()
    {
        ModuleGen a;
        a = new ModuleGen();
        a.Init();
        return a;
    }

    protected virtual ModuleHeaderGen CreateModuleHeaderGen()
    {
        ModuleHeaderGen a;
        a = new ModuleHeaderGen();
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

    protected virtual ModuleRef CreateModuleRef()
    {
        return this.ClassInfra.ModuleRefCreate(null, 0);
    }

    public virtual bool Load()
    {
        this.ModuleProjectText = this.StorageInfra.TextRead(this.S("Saber.Console.data/ModuleProject.txt"));

        if (this.ModuleProjectText == null)
        {
            return false;
        }

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

        this.ClassInitArray = null;
        this.ClassBaseArray = null;
        this.ClassCompArray = null;
        this.GenModuleExeFoldPath = null;
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

        this.ExecuteClassComp();

        bool b;
        b = this.StorageComp.FoldCreate(this.GenModuleFoldPath);

        if (!b)
        {
            this.Status = 10;
            return false;
        }

        b = this.ExecuteGenClassSource();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteGenModuleSource();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteGenModuleHeaderSource();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteGenImportArg();
        if (!b)
        {
            return false;
        }

        // bool bd;
        // bd = this.ExecuteGenProject();
        // if (!bd)
        // {
        //     return false;
        // }

        b = this.ExecuteGenMakeLib();
        if (!b)
        {
            return false;
        }

        b = this.StorageComp.FoldDelete(this.GenModuleFoldPath);

        if (!b)
        {
            this.Status = 70;
            return false;
        }

        if (!(this.Module.Entry == null))
        {
            this.GenModuleExeFoldPath = this.AddClear().Add(genFoldPath).Add(combine).Add(this.SExe).Add(this.ClassInfra.TextHyphen).Add(this.ModuleRefString).AddResult();

            b = this.StorageComp.FoldCreate(this.GenModuleExeFoldPath);

            if (!b)
            {
                this.Status = 80;
                return false;
            }

            b = this.ExecuteModuleExeSource();
            if (!b)
            {
                return false;
            }

            b = this.ExecuteGenMakeExe();
            if (!b)
            {
                return false;
            }
        }

        return true;
    }

    protected virtual bool ExecuteInit()
    {
        this.ClassInitGen.Module = this.Module;
        this.ClassInitGen.AnyClass = this.SystemClass.Any;

        this.ClassInitGen.Execute();

        this.ClassInitArray = this.ClassInitGen.Result;

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

        this.ClassBaseArray = array;

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

    protected virtual bool ExecuteClassComp()
    {
        long count;
        count = this.Module.Class.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        this.ClassCompArray = array;

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
            baseArray = this.ClassBaseArray.GetAt(i) as Array;

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

            systemInfraModule = this.ModuleTable.Get(this.ModuleRef) as ClassModule;
        }

        ClassClass internClass;
        ClassClass externClass;
        internClass = systemInfraModule.Class.Get(this.SIntern) as ClassClass;
        externClass = systemInfraModule.Class.Get(this.SExtern) as ClassClass;

        this.ClassGen.InternClass = internClass;
        this.ClassGen.ExternClass = externClass;
        this.ClassGen.System = this.SystemClass;
        this.ClassGen.ImportClass = this.ImportClass;

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
            varClass = iter.Value as ClassClass;

            NodeClass nodeClass;
            nodeClass = varClass.Any as NodeClass;

            this.StringValueTravel.Class = nodeClass;

            this.StringValueTravel.Execute();

            Array stringValueArray;
            stringValueArray = this.StringValueTravel.Array;

            this.StringValueTravel.Array = null;
            this.StringValueTravel.Class = null;

            Array baseArray;
            baseArray = this.ClassBaseArray.GetAt(i) as Array;

            if (0x100 < baseArray.Count)
            {
                this.Status = 15;
                return false;
            }

            ClassComp classComp;
            classComp = this.ClassCompArray.GetAt(i) as ClassComp;

            this.ClassGen.Class = varClass;
            this.ClassGen.BaseArray = baseArray;
            this.ClassGen.ClassComp = classComp;
            this.ClassGen.StringValue = stringValueArray;

            this.ClassGen.Execute();

            String k;
            k = this.ClassGen.Result;

            this.ClassGen.Result = null;
            this.ClassGen.StringValue = null;
            this.ClassGen.ClassComp = null;
            this.ClassGen.BaseArray = null;
            this.ClassGen.Class = null;

            String ka;
            ka = this.StringIntHex(i);

            String combine;
            combine = this.TextInfra.PathCombine;

            String fileName;
            fileName = this.AddClear().AddChar('C').Add(ka).Add(this.ClassInfra.TextDot).Add(this.SC).AddResult();

            String filePath;
            filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(combine).Add(fileName).AddResult();

            bool bab;
            bab = this.StorageInfra.TextWrite(filePath, k);

            if (!bab)
            {
                this.Status = 20;
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
        this.ModuleGen.ModuleTableCount = this.ModuleTable.Count;
        this.ModuleGen.ClassInit = this.ClassInitArray;

        this.ModuleGen.Execute();
        String k;
        k = this.ModuleGen.Result;

        this.ModuleGen.Result = null;
        this.ModuleGen.ClassInit = null;
        this.ModuleGen.ModuleTableCount = 0;
        this.ModuleGen.Module = null;
        this.ModuleGen.Gen = null;

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.TextDot).Add(this.SC).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, k);

        if (!b)
        {
            this.Status = 30;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteGenModuleHeaderSource()
    {
        this.ModuleHeaderGen.Gen = this.ClassGen;
        this.ModuleHeaderGen.Module = this.Module;
        this.ModuleHeaderGen.ImportClass = this.ImportClass;
        this.ModuleHeaderGen.ClassCompArray = this.ClassCompArray;

        this.ModuleHeaderGen.Execute();
        String k;
        k = this.ModuleHeaderGen.Result;

        this.ModuleHeaderGen.Result = null;
        this.ModuleHeaderGen.ClassCompArray = null;
        this.ModuleHeaderGen.ImportClass = null;
        this.ModuleHeaderGen.Module = null;
        this.ModuleHeaderGen.Gen = null;

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.TextDot).Add(this.SH).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, k);

        if (!b)
        {
            this.Status = 40;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteGenImportArg()
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
            this.Status = 50;
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

    protected virtual bool ExecuteGenMakeLib()
    {
        return this.ExecuteMake(false, 60);
    }

    protected virtual bool ExecuteGenMakeExe()
    {
        return this.ExecuteMake(true, 100);
    }

    protected virtual bool ExecuteMake(bool exe, long status)
    {
        Program program;
        program = null;

        ulong ka;
        ka = Extern.Environ_BinarySystem();

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
            this.Status = status;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteModuleExeSource()
    {
        Text ka;
        ka = this.TextCreate(this.ModuleExeText);
        ka = this.TextPlace(ka, this.TA(this.S("#Module#")), this.TB(this.ModuleRefString));

        String k;
        k = this.StringCreate(ka);

        String fileName;
        fileName = this.AddClear().Add(this.SMain).Add(this.ClassInfra.TextDot).Add(this.SC).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleExeFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, k);

        if (!b)
        {
            this.Status = 90;
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
        list.Add(this.AddClear().AddS("./Make").Add(ka).AddS(".sh"));
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
        list.Add(this.AddClear().AddS("Make").Add(ka).AddS(".cmd ").Add(this.ModuleRefString).AddResult());

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