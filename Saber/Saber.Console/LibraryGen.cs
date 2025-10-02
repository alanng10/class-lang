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
        this.ClassStringGen = this.CreateClassStringGen();
        this.ClassGen = this.CreateClassGen();
        this.ModuleRefStringGen = this.CreateModuleRefStringGen();
        this.TModuleRef = this.CreateModuleRef();

        this.SSystemDotInfra = this.S("System.Infra");
        this.SC = this.S("c");
        this.SModule = this.S("Module");
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

    protected virtual ClassStringGen CreateClassStringGen()
    {
        ClassStringGen a;
        a = new ClassStringGen();
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

    public virtual ModuleRef ModuleRef { get; set; }
    public virtual ModulePort ModulePort { get; set; }
    public virtual BinaryRead BinaryRead { get; set; }
    public virtual String ClassPath { get; set; }
    public virtual long Status { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual ClassInitGen ClassInitGen { get; set; }
    protected virtual ClassBaseGen ClassBaseGen { get; set; }
    protected virtual ClassCompGen ClassCompGen { get; set; }
    protected virtual ClassStringGen ClassStringGen { get; set; }
    protected virtual ClassGen ClassGen { get; set; }
    protected virtual ModuleRefStringGen ModuleRefStringGen { get; set; }
    protected virtual ClassModule SystemInfraModule { get; set; }
    protected virtual SystemClass System { get; set; }
    protected virtual String ModuleRefString { get; set; }
    protected virtual BinaryBinary Binary { get; set; }
    protected virtual ClassModule Module { get; set; }
    protected virtual Table BinaryTable { get; set; }
    protected virtual Table ModuleTable { get; set; }
    protected virtual Array InitArray { get; set; }
    protected virtual Array BaseArray { get; set; }
    protected virtual Array CompArray { get; set; }
    protected virtual Array StringArray { get; set; }
    protected virtual String ModuleExeText { get; set; }
    protected virtual String GenModuleFoldPath { get; set; }
    protected virtual ModuleRef TModuleRef { get; set; }
    protected virtual String ModuleExeString { get; set; }
    protected virtual long Stage { get; set; }
    protected virtual String SSystemDotInfra { get; set; }
    protected virtual String SC { get; set; }
    protected virtual String SModule { get; set; }
    protected virtual String SExe { get; set; }
    protected virtual String SMain { get; set; }

    public virtual bool Load()
    {
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

        this.TModuleRef.Name = null;
        this.SystemInfraModule = null;
        this.System = null;
        this.Binary = null;
        this.Module = null;
        this.BinaryTable = null;
        this.ModuleTable = null;
        this.InitArray = null;
        this.BaseArray = null;
        this.CompArray = null;
        this.StringArray = null;
        this.GenModuleFoldPath = null;
        this.ModuleExeString = null;

        return b;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;
        this.Stage = 0;

        bool b;

        b = this.ExecuteModuleLoad();

        if (!b)
        {
            return this.Error();
        }

        this.SystemInfraModuleGet();
        this.SystemSet();

        this.ExecuteInit();

        this.ExecuteBase();

        this.ExecuteComp();

        this.ExecuteString();

        String verString;
        verString = this.ClassInfra.VerString(this.ModuleRef.Ver);

        this.ModuleRefString = this.ClassInfra.ModuleRefString(this.ModuleRef.Name, verString);

        String genFoldPath;
        genFoldPath = this.S("Saber.Console.data/Gen");

        String combine;
        combine = this.TextInfra.PathCombine;

        this.GenModuleFoldPath = this.AddClear().Add(genFoldPath).Add(combine).Add(this.ModuleRefString).AddResult();

        b = this.StorageComp.FoldCreate(this.GenModuleFoldPath);

        if (!b)
        {
            return this.Error();
        }

        b = this.ExecuteClean();
        if (!b)
        {
            return this.Error();
        }

        b = this.ExecuteClassSource();
        if (!b)
        {
            return this.Error();
        }

        b = this.ExecuteMakeLib();
        if (!b)
        {
            return this.Error();
        }

        if (!(this.Module.Entry == null))
        {
            b = this.ExecuteModuleRefString();
            if (!b)
            {
                return this.Error();
            }

            b = this.ExecuteModuleExeSource();
            if (!b)
            {
                return this.Error();
            }

            b = this.ExecuteMakeExe();
            if (!b)
            {
                return this.Error();
            }
        }

        b = this.StorageComp.FoldDelete(this.GenModuleFoldPath);

        if (!b)
        {
            return this.Error();
        }

        return true;
    }

    protected virtual bool SystemInfraModuleGet()
    {
        this.TModuleRef.Name = this.SSystemDotInfra;
        this.TModuleRef.Ver = 0;

        this.SystemInfraModule = this.ModuleTable.Get(this.TModuleRef) as ClassModule;
        return true;
    }

    protected virtual bool SystemSet()
    {
        this.System = new SystemClass();
        this.System.Init();
        this.System.Any = this.SystemInfraModule.Class.Get(this.S("Any")) as ClassClass;
        this.System.Bool = this.SystemInfraModule.Class.Get(this.S("Bool")) as ClassClass;
        this.System.Int = this.SystemInfraModule.Class.Get(this.S("Int")) as ClassClass;
        this.System.String = this.SystemInfraModule.Class.Get(this.S("String")) as ClassClass;
        return true;
    }

    protected virtual bool ExecuteModuleLoad()
    {
        return true;
    }

    protected virtual bool ExecuteInit()
    {
        this.ClassInitGen.Module = this.Module;
        this.ClassInitGen.AnyClass = this.System.Any;

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

    protected virtual bool ExecuteString()
    {
        this.ClassStringGen.State = this.Binary.State;

        this.ClassStringGen.Execute();

        this.StringArray = this.ClassStringGen.Result;

        this.ClassStringGen.Result = null;
        this.ClassStringGen.State = null;

        return true;
    }

    protected virtual bool ExecuteClean()
    {
        String libFilePath;
        libFilePath = this.AddClear().Add(this.ClassPath).Add(this.TextInfra.PathCombine).Add(this.ModuleRefString).AddS(".dll").AddResult();

        this.StorageComp.FileDelete(libFilePath);

        String exeFilePath;
        exeFilePath = this.AddClear().Add(this.ClassPath).Add(this.TextInfra.PathCombine).Add(this.ModuleRefString).AddS(".exe").AddResult();

        this.StorageComp.FileDelete(exeFilePath);

        return true;
    }

    protected virtual bool ExecuteClassSource()
    {
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

        this.ClassGen.Module = this.Module;
        this.ClassGen.Binary = this.Binary;
        this.ClassGen.ModuleCount = this.ModuleTable.Count;
        this.ClassGen.SystemInfraModule = this.SystemInfraModule;
        this.ClassGen.System = this.System;
        this.ClassGen.InitArray = this.InitArray;
        this.ClassGen.BaseArray = this.BaseArray;
        this.ClassGen.CompArray = this.CompArray;
        this.ClassGen.StringArray = this.StringArray;

        this.ClassGen.Execute();

        String k;
        k = this.ClassGen.Result;

        this.ClassGen.Result = null;
        this.ClassGen.StringArray = null;
        this.ClassGen.CompArray = null;
        this.ClassGen.BaseArray = null;
        this.ClassGen.InitArray = null;
        this.ClassGen.System = null;
        this.ClassGen.SystemInfraModule = null;
        this.ClassGen.ModuleCount = 0;
        this.ClassGen.Binary = null;
        this.ClassGen.Module = null;

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.TextDot).Add(this.SC).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool bab;
        bab = this.StorageInfra.TextWrite(filePath, k);

        if (!bab)
        {
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

        if (exe)
        {
            list.Add(this.S("-Wl,-s"));
            list.Add(this.S("-Wl,-subsystem,console"));
        }

        list.Add(this.AddClear().AddS("-L../../../").Add(this.ClassPath).AddResult());
        list.Add(this.S("-lInfra"));
        list.Add(this.S("-lInfraIntern"));

        if (!exe)
        {
            Array moduleRefStringArray;
            moduleRefStringArray = this.ModuleRefStringArray();

            long count;
            count = moduleRefStringArray.Count;

            long i;
            i = 0;
            while (i < count)
            {
                String ka;
                ka = moduleRefStringArray.GetAt(i) as String;

                list.Add(this.AddClear().AddS("-l").Add(ka).AddResult());

                i = i + 1;
            }
        }

        if (exe)
        {
            list.Add(this.AddClear().AddS("-l").Add(this.ModuleRefString).AddResult());
        }

        list.Add(this.S("-o"));

        if (!exe)
        {
            list.Add(this.AddClear().AddS("../../../").Add(this.ClassPath).Add(this.TextInfra.PathCombine).Add(this.ModuleRefString).AddS(".dll").AddResult());
            list.Add(this.S("Module.c"));
        }

        if (exe)
        {
            list.Add(this.AddClear().AddS("../../../").Add(this.ClassPath).Add(this.TextInfra.PathCombine).Add(this.ModuleRefString).AddS(".exe").AddResult());
            list.Add(this.S("Main.c"));
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

    protected virtual bool FinalMakeProgram(Program a)
    {
        a.Final();
        return true;
    }

    protected virtual bool Error()
    {
        long k;
        k = this.Stage + 1;
        k = k * 10;

        this.Status = k;

        this.Stage = this.Stage + 1;

        return false;
    }
}