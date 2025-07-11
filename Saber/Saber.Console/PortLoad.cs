namespace Saber.Console;

public class PortLoad : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.StorageComp = StorageComp.This;

        this.ErrorKind = ErrorKindList.This;

        this.StoragePathValid = new StoragePathValid();
        this.StoragePathValid.Init();

        this.SystemModuleSingle = this.S("System");
        this.SystemModulePre = this.AddClear().Add(this.SystemModuleSingle).Add(this.ClassInfra.TextDot).AddResult();

        this.SDotRef = this.S(".ref");
        this.SModule = this.S("Module");
        return true;
    }
    public virtual PortPort Port { get; set; }
    public virtual bool SystemModule { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual long Status { get; set; }
    public virtual Array Error { get; set; }
    public virtual ModuleLoad ModuleLoad { get; set; }
    public virtual BinaryRead BinaryRead { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ImportClass { get; set; }
    public virtual NameValid NameValid { get; set; }
    public virtual String ClassPath { get; set; }
    public virtual String SourceFold { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual ErrorKindList ErrorKind { get; set; }
    protected virtual StoragePathValid StoragePathValid { get; set; }
    protected virtual Array ImportModuleRefArray { get; set; }
    protected virtual Table BinaryTable { get; set; }
    protected virtual Table ImportDependTable { get; set; }
    protected virtual Table BinaryDependTable { get; set; }
    protected virtual List ErrorList { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual String SystemModuleSingle { get; set; }
    protected virtual String SystemModulePre { get; set; }
    protected virtual String SDotRef { get; set; }
    protected virtual String SModule { get; set; }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.Error = this.ListInfra.ArrayCreateList(this.ErrorList);

        this.ImportModuleRefArray = null;
        this.ImportDependTable = null;
        this.BinaryDependTable = null;
        this.ModuleLoad.BinaryTable = null;
        this.ModuleLoad.ModuleTable = null;
        this.ErrorList = null;
        this.ModuleRef = null;

        this.ClearData();
        return b;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;

        PortPort port;
        port = this.Port;

        this.ErrorList = new List();
        this.ErrorList.Init();

        bool b;

        b = this.ValidModuleRef(port.Module);
        if (!b)
        {
            return false;
        }

        b = this.ValidImportArrayModuleRef(port.Import);
        if (!b)
        {
            return false;
        }

        b = this.SetModuleRef();
        if (!b)
        {
            return false;
        }

        b = this.SetImportModuleRef();
        if (!b)
        {
            return false;
        }

        b = this.CheckImportUnique();
        if (!b)
        {
            return false;
        }

        b = this.ImportBinaryLoad();
        if (!b)
        {
            return false;
        }

        b = this.ImportDepend();
        if (!b)
        {
            return false;
        }

        b = this.ImportModuleLoad();
        if (!b)
        {
            return false;
        }

        b = this.CreateModule();
        if (!b)
        {
            return false;
        }

        b = this.SetModuleImport();
        if (!b)
        {
            return false;
        }

        b = this.SetModuleExport();
        if (!b)
        {
            return false;
        }

        b = this.SetModuleStorage();
        if (!b)
        {
            return false;
        }

        b = this.SetModuleEntry();
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool SetModuleRef()
    {
        ModuleRef ka;
        ka = this.Port.Module;

        ModuleRef a;
        a = this.ClassInfra.ModuleRefCreate(ka.Name, ka.Ver);

        if (this.SystemModule)
        {
            a.Ver = 0;
        }

        this.ModuleRef = a;
        return true;
    }

    protected virtual bool SetImportModuleRef()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Array import;
        import = this.Port.Import;

        Array array;
        array = listInfra.ArrayCreate(import.Count);

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortImport o;
            o = import.GetAt(i) as PortImport;

            ModuleRef aa;
            aa = o.Module;

            String name;
            name = aa.Name;
            long version;
            version = aa.Ver;
            if (version == -1)
            {
                version = 0;
            }

            ModuleRef a;
            a = classInfra.ModuleRefCreate(name, version);

            array.SetAt(i, a);

            i = i + 1;
        }

        this.ImportModuleRefArray = array;
        return true;
    }

    protected virtual bool CheckImportUnique()
    {
        Table table;
        table = this.ClassInfra.TableCreateModuleRefLess();

        Array array;
        array = this.ImportModuleRefArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef a;
            a = array.GetAt(i) as ModuleRef;

            if (table.Valid(a))
            {
                this.Status = 30;
                return false;
            }

            this.ListInfra.TableAdd(table, a, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ValidModuleRef(ModuleRef module)
    {
        String name;
        name = module.Name;
        long ver;
        ver = module.Ver;

        if (!(this.NameValid.ModuleName(this.TA(name))))
        {
            this.Status = 1;
            return false;
        }

        if (!this.SystemModule)
        {
            if (ver == -1)
            {
                this.Status = 2;
                return false;
            }

            if (this.BuiltModuleRef(module))
            {
                this.Status = 3;
                return false;
            }
        }

        return true;
    }

    protected virtual bool ValidImportArrayModuleRef(Array array)
    {
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortImport a;
            a = array.GetAt(i) as PortImport;

            if (!this.ValidImportModuleRef(a.Module))
            {
                this.Status = 10;
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ValidImportModuleRef(ModuleRef moduleRef)
    {
        String name;
        name = moduleRef.Name;
        long ver;
        ver = moduleRef.Ver;

        if (!(this.NameValid.ModuleName(this.TA(name))))
        {
            return false;
        }

        bool built;
        built = this.BuiltModuleRef(moduleRef);

        bool b;
        b = (ver == -1);

        bool a;
        a = (built == b);
        return a;
    }

    protected virtual bool ImportBinaryLoad()
    {
        this.BinaryTable = this.ClassInfra.TableCreateModuleRefLess();

        Array array;
        array = this.ImportModuleRefArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef a;
            a = array.GetAt(i) as ModuleRef;

            bool b;
            b = this.BinaryLoadRecurse(a);
            if (!b)
            {
                String k;
                k = this.ModuleRefString(a);

                this.ErrorAdd(this.ErrorKind.ModuleUnvalid, k);

                this.Status = 50;
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool BinaryLoadRecurse(ModuleRef moduleRef)
    {
        if (this.BinaryTable.Valid(moduleRef))
        {
            return true;
        }

        BinaryBinary binary;
        binary = this.BinaryLoad(moduleRef);
        if (binary == null)
        {
            return false;
        }

        Array array;
        array = binary.Import;
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryImport import;
            import = array.GetAt(i) as BinaryImport;

            bool b;
            b = this.BinaryLoadRecurse(import.Module);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        this.ListInfra.TableAdd(this.BinaryTable, binary.Ref, binary);

        return true;
    }

    protected virtual BinaryBinary BinaryLoad(ModuleRef moduleRef)
    {
        String moduleRefString;
        moduleRefString = this.ModuleRefString(moduleRef);

        String filePath;
        filePath = this.AddClear().Add(this.ClassInfra.ClassModulePath(this.ClassPath))
            .Add(this.TextInfra.PathCombine).Add(moduleRefString).Add(this.SDotRef).AddResult();

        Data data;
        data = this.StorageInfra.DataRead(filePath);

        if (data == null)
        {
            return null;
        }

        BinaryRead read;
        read = this.BinaryRead;

        read.Data = data;

        read.Execute();

        BinaryBinary binary;
        binary = read.Result;

        read.Result = null;

        BinaryBinary a;
        a = binary;

        return a;
    }

    protected virtual bool ImportDepend()
    {
        ModuleRef ka;
        ka = this.ModuleRef;

        if (this.BinaryTable.Valid(ka))
        {
            String k;
            k = this.ModuleRefString(ka);

            this.ErrorAdd(this.ErrorKind.ModuleUndefine, k);

            this.Status = 60;
            return false;
        }

        return true;
    }

    protected virtual bool ImportModuleLoad()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ModuleLoad moduleLoad;
        moduleLoad = this.ModuleLoad;

        moduleLoad.BinaryTable = this.BinaryTable;
        moduleLoad.ModuleTable = this.ModuleTable;

        Table table;
        table = this.ModuleTable;

        Iter iter;
        iter = this.BinaryTable.IterCreate();
        this.BinaryTable.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef moduleRef;
            moduleRef = iter.Index as ModuleRef;

            moduleLoad.ModuleRef = moduleRef;

            bool b;
            b = moduleLoad.Execute();

            if (!b)
            {
                long o;
                o = moduleLoad.Status;

                String k;
                k = this.ModuleRefString(moduleRef);

                this.ErrorAdd(this.ErrorKind.ModuleUndefine, k);

                this.Status = 200 + o;
                return false;
            }

            ClassModule a;
            a = moduleLoad.Module;

            moduleLoad.Module = null;
            moduleLoad.ModuleRef = null;

            listInfra.TableAdd(table, a.Ref, a);
        }

        return true;
    }

    protected virtual bool CreateModule()
    {
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        ClassModule module;
        module = new ClassModule();
        module.Init();
        module.Ref = this.ModuleRef;
        module.Class = classInfra.TableCreateStringLess();
        module.Import = classInfra.TableCreateModuleRefLess();
        module.Export = classInfra.TableCreateStringLess();

        module.Storage = new Table();
        module.Storage.Less = this.StorageStringLessCreate();
        module.Storage.Init();

        this.Module = module;
        return true;
    }

    public virtual StringLess StorageStringLessCreate()
    {
        StringLess a;
        a = new StringLess();
        a.LiteForm = this.StorageInfra.NameForm;
        a.RiteForm = this.StorageInfra.NameForm;
        a.CharLess = this.ILess;
        a.Init();
        return a;
    }

    protected virtual bool SetModuleImport()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Table moduleTable;
        moduleTable = this.ModuleTable;

        NameValid nameCheck;
        nameCheck = this.NameValid;

        Array importModuleRef;
        importModuleRef = this.ImportModuleRefArray;

        Array array;
        array = this.Port.Import;

        bool b;
        b = false;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef kk;
            kk = importModuleRef.GetAt(i) as ModuleRef;

            ClassModule k;
            k = moduleTable.Get(kk) as ClassModule;

            Table a;
            a = classInfra.TableCreateRefLess();

            listInfra.TableAdd(this.Module.Import, kk, a);

            PortImport kkk;
            kkk = array.GetAt(i) as PortImport;

            Array importClassArray;
            importClassArray = kkk.Class;

            long countA;
            countA = importClassArray.Count;
            long iA;
            iA = 0;
            while (iA < countA)
            {
                PortImportClass importClass;
                importClass = (PortImportClass)importClassArray.GetAt(iA);

                String className;
                className = importClass.Class;

                ClassClass varClass;
                varClass = null;

                bool ba;
                ba = false;

                if (!ba)
                {
                    if (!nameCheck.Name(this.TA(className)))
                    {
                        ba = true;
                    }
                }

                if (!ba)
                {
                    varClass = (ClassClass)k.Class.Get(className);

                    if (varClass == null)
                    {
                        ba = true;
                    }
                }

                if (!ba)
                {
                    if (!k.Export.Valid(className))
                    {
                        ba = true;
                    }
                }

                if (ba)
                {
                    this.ErrorAdd(this.ErrorKind.ImportClassUndefine, className);
                    b = true;
                }

                if (!ba)
                {
                    listInfra.TableAdd(a, varClass, varClass);
                }

                String name;
                name = importClass.Name;

                bool bb;
                bb = false;

                if (!bb)
                {
                    if (!nameCheck.Name(this.TA(name)))
                    {
                        bb = true;
                    }
                }

                if (!bb)
                {
                    if (this.ImportClass.Valid(name))
                    {
                        bb = true;
                    }
                }

                if (bb)
                {
                    this.ErrorAdd(this.ErrorKind.ImportNameUnavail, name);
                    b = true;
                }

                if (!ba & !bb)
                {
                    listInfra.TableAdd(this.ImportClass, name, varClass);
                }

                iA = iA + 1;
            }

            i = i + 1;
        }

        if (b)
        {
            this.Status = 80;
            return false;
        }

        return true;
    }

    protected virtual bool SetModuleExport()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table exportTable;
        exportTable = this.Module.Export;

        NameValid nameCheck;
        nameCheck = this.NameValid;

        Array array;
        array = this.Port.Export;

        bool b;
        b = false;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortExport a;
            a = array.GetAt(i) as PortExport;

            String name;
            name = a.Class;

            bool ba;
            ba = false;

            if (!ba)
            {
                if (!nameCheck.Name(this.TA(name)))
                {
                    ba = true;
                }
            }

            if (!ba)
            {
                if (this.ImportClass.Valid(name))
                {
                    ba = true;
                }
            }

            if (!ba)
            {
                if (exportTable.Valid(name))
                {
                    ba = true;
                }
            }

            if (ba)
            {
                this.ErrorAdd(this.ErrorKind.ExportUnvalid, name);
                b = true;
            }

            if (!ba)
            {
                listInfra.TableAdd(exportTable, name, null);
            }

            i = i + 1;
        }

        if (b)
        {
            this.Status = 90;
            return false;
        }

        return true;
    }

    protected virtual bool SetModuleStorage()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        StoragePathValid pathValid;
        pathValid = this.StoragePathValid;

        Table table;
        table = this.Module.Storage;

        Array array;
        array = this.Port.Storage;

        bool b;
        b = false;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortStorage a;
            a = array.GetAt(i) as PortStorage;

            String sourcePathKa;
            String destPathKa;
            sourcePathKa = a.Source;
            destPathKa = a.Dest;

            Text sourcePathK;
            String sourcePath;
            sourcePathK = this.TextTrimEnd(this.TextTrimStart(this.TA(sourcePathKa)));
            sourcePath = this.StringCreate(sourcePathK);

            Text destPathK;
            String destPath;
            destPathK = this.TextTrimEnd(this.TextTrimStart(this.TA(destPathKa)));
            destPath = this.StringCreate(destPathK);

            String sourcePathA;
            sourcePathA = sourcePath;

            if (this.StorageInfra.PathRelate(this.TA(sourcePath), this.TLess))
            {
                sourcePathA = this.AddClear().Add(this.SourceFold).Add(this.TextInfra.PathCombine).Add(sourcePath).AddResult();
            }

            bool ba;
            ba = false;

            if (!ba)
            {
                if (!pathValid.ValidSourcePath(this.TA(sourcePathA)))
                {
                    this.ErrorAdd(this.ErrorKind.StorageSourceUnvalid, sourcePath);

                    ba = true;
                }
            }

            if (!ba)
            {
                if (!pathValid.ValidDestPath(this.TA(destPath)))
                {
                    this.ErrorAdd(this.ErrorKind.StorageDestUnvalid, destPath);

                    ba = true;
                }
            }

            if (!ba)
            {
                if (table.Valid(destPath))
                {
                    this.ErrorAdd(this.ErrorKind.StorageDestUnavail, destPath);

                    ba = true;
                }
            }

            if (!ba)
            {
                if (!this.StorageComp.Exist(sourcePathA))
                {
                    this.ErrorAdd(this.ErrorKind.StorageSourceUnachieve, sourcePath);

                    ba = true;
                }
            }

            if (ba)
            {
                b = true;
            }

            listInfra.TableAdd(table, destPath, sourcePathA);

            i = i + 1;
        }

        if (b)
        {
            this.Status = 100;
            return false;
        }

        return true;
    }

    protected virtual bool SetModuleEntry()
    {
        String entry;
        entry = this.Port.Entry;

        if (entry == null)
        {
            return true;
        }

        bool b;
        b = false;

        if (!this.NameValid.Name(this.TA(entry)))
        {
            b = true;
        }

        if (this.ImportClass.Valid(entry))
        {
            b = true;
        }

        if (b)
        {
            this.ErrorAdd(this.ErrorKind.EntryUnachieve, entry);

            this.Status = 110;
            return false;
        }

        this.Module.Entry = entry;
        return true;
    }

    protected virtual String ModuleRefString(ModuleRef k)
    {
        String verString;
        verString = this.ClassInfra.VerString(k.Ver);

        String a;
        a = this.ClassInfra.ModuleRefString(k.Name, verString);
        return a;
    }

    protected virtual bool ErrorAdd(ErrorKind kind, String name)
    {
        Error a;
        a = new Error();
        a.Init();
        a.Kind = kind;
        a.Name = name;
        a.Source = -1;

        this.ErrorList.Add(a);
        return true;
    }

    protected virtual bool BuiltModuleRef(ModuleRef moduleRef)
    {
        String name;
        name = moduleRef.Name;

        Text textName;
        textName = this.TA(name);

        bool b;
        b = false;

        if (!b)
        {
            if (this.TextSame(textName, this.TB(this.SystemModuleSingle)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextStart(textName, this.TB(this.SystemModulePre)))
            {
                b = true;
            }
        }

        return b;
    }
}