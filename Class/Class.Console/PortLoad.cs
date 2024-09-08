namespace Class.Console;

public class PortLoad : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;

        this.StoragePathCheck = new StoragePathCheck();
        this.StoragePathCheck.Init();

        this.SystemModuleSingle = this.S("System");
        this.SystemModulePre = this.AddClear().Add(this.SystemModuleSingle).Add(this.ClassInfra.Dot).AddResult();
        this.ClassModuleSingle = this.S("Class");
        this.ClassModulePre = this.AddClear().Add(this.ClassModuleSingle).Add(this.ClassInfra.Dot).AddResult();

        this.SHyphen = this.S("-");
        this.SDotRef = this.S(".ref");
        return true;
    }
    public virtual PortPort Port { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual long Status { get; set; }
    public virtual ModuleLoad ModuleLoad { get; set; }
    public virtual BinaryRead BinaryRead { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }
    public virtual Table ClassTable { get; set; }
    public virtual Table ImportTable { get; set; }
    public virtual Table ExportTable { get; set; }
    public virtual NameCheck NameCheck { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual StoragePathCheck StoragePathCheck { get; set; }
    protected virtual Array ImportModuleRefArray { get; set; }
    protected virtual Table ImportDependTable { get; set; }
    protected virtual Table BinaryDependTable { get; set; }
    protected virtual String SystemModuleSingle { get; set; }
    protected virtual String SystemModulePre { get; set; }
    protected virtual String ClassModuleSingle { get; set; }
    protected virtual String ClassModulePre { get; set; }
    protected virtual String SHyphen { get; set; }
    protected virtual String SDotRef { get; set; }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.ImportModuleRefArray = null;
        this.ImportDependTable = null;
        this.BinaryDependTable = null;
        this.ModuleLoad.BinaryTable = null;
        this.ModuleLoad.ModuleTable = null;

        return b;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;
        
        PortPort port;
        port = this.Port;

        bool b;

        b = this.CheckModuleRef(port.Module);
        if (!b)
        {
            return false;
        }

        b = this.CheckImportArrayModuleRef(port.Import);
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
            o = (PortImport)import.GetAt(i);

            ModuleRef aa;
            aa = o.Module;

            String name;
            name = aa.Name;
            long version;
            version = aa.Version;
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
        ListInfra listInfra;
        listInfra = this.ListInfra;
        
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
            a = (ModuleRef)array.GetAt(i);

            if (table.Valid(a))
            {
                this.Status = 30;
                return false;
            }

            listInfra.TableAdd(table, a, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool CheckModuleRef(ModuleRef module)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        String name;
        name = module.Name;
        long version;
        version = module.Version;

        if (!(this.NameCheck.IsModuleName(this.TA(name))))
        {
            this.Status = 1;
            return false;
        }

        if (version == -1)
        {
            this.Status = 2;
            return false;
        }

        if (this.IsBuiltinModuleRef(module))
        {
            this.Status = 3;
            return false;
        }

        return true;
    }

    protected virtual bool CheckImportArrayModuleRef(Array array)
    {
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortImport a;
            a = (PortImport)array.GetAt(i);

            if (!this.CheckImportModuleRef(a.Module))
            {
                this.Status = 10;
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool CheckImportModuleRef(ModuleRef moduleRef)
    {
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        String name;
        name = moduleRef.Name;
        long version;
        version = moduleRef.Version;

        if (!(this.NameCheck.IsModuleName(this.TA(name))))
        {
            return false;
        }

        bool isBuiltin;
        isBuiltin = this.IsBuiltinModuleRef(moduleRef);

        bool b;
        b = (version == -1);

        bool a;
        a = (isBuiltin == b);
        return a;
    }

    protected virtual bool ImportBinaryLoad()
    {
        Array array;
        array = this.ImportModuleRefArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef a;
            a = (ModuleRef)array.GetAt(i);

            bool b;
            b = this.BinaryLoadRecursive(a);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool BinaryLoadRecursive(ModuleRef moduleRef)
    {
        if (this.BinaryTable.Valid(moduleRef))
        {
            return true;
        }

        bool b;
        b = this.BinaryLoad(moduleRef);
        if (!b)
        {
            return false;
        }

        BinaryBinary binary;
        binary = (BinaryBinary)this.BinaryTable.Get(moduleRef);

        Array array;
        array = binary.Import;
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryImport import;
            import = (BinaryImport)array.GetAt(i);

            bool ba;
            ba = this.BinaryLoadRecursive(import.Module);
            if (!ba)
            {
                return false;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual bool BinaryLoad(ModuleRef moduleRef)
    {
        String moduleName;
        moduleName = moduleRef.Name;
        long version;
        version = moduleRef.Version;

        String versionString;
        versionString = this.ClassInfra.VersionString(version);
    
        String moduleRefString;
        moduleRefString = this.AddClear().Add(moduleName).Add(this.SHyphen).Add(versionString).AddResult();

        String filePath;
        filePath = this.AddClear().Add(moduleRefString).Add(this.SDotRef).AddResult();

        Data data;
        data = this.StorageInfra.DataReadAny(filePath, true);

        if (data == null)
        {
            this.Status = 50;
            return false;
        }

        long kk;
        kk = data.Count;

        InfraRange range;
        range = new InfraRange();
        range.Init();
        range.Count = kk;

        BinaryRead read;
        read = this.BinaryRead;

        read.Data = data;
        read.Range = range;

        read.Execute();

        BinaryBinary binary;
        binary = read.Binary;

        if (binary == null)
        {
            this.Status = 51;
            return false;
        }

        read.Binary = null;

        this.ListInfra.TableAdd(this.BinaryTable, binary.Ref, binary);
        return true;
    }

    protected virtual bool ImportDepend()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        this.BinaryDependTable = classInfra.TableCreateModuleRefLess();

        Array array;
        array = this.ImportModuleRefArray;

        Table table;
        table = classInfra.TableCreateModuleRefLess();

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef o;
            o = (ModuleRef)array.GetAt(i);

            Table aa;
            aa = this.BinaryDepend(o);
            if (aa == null)
            {
                return false;
            }

            Iter iter;
            iter = aa.IterCreate();
            aa.IterSet(iter);

            while (iter.Next())
            {
                ModuleRef oo;
                oo = (ModuleRef)iter.Index;

                if (!table.Valid(oo))
                {
                    listInfra.TableAdd(table, oo, oo);
                }
            }

            i = i + 1;
        }

        ModuleRef oa;
        oa = this.Port.Module;

        if (table.Valid(oa))
        {
            this.Status = 61;
            return false;
        }

        this.ImportDependTable = table;
        return true;
    }

    protected virtual Table BinaryDepend(ModuleRef moduleRef)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table binaryDependTable;
        binaryDependTable = this.BinaryDependTable;

        Table table;
        if (binaryDependTable.Valid(moduleRef))
        {
            table = (Table)binaryDependTable.Get(moduleRef);
            return table;
        }

        table = this.ClassInfra.TableCreateModuleRefLess();

        if (this.IsBuiltinModuleRef(moduleRef))
        {
            listInfra.TableAdd(binaryDependTable, moduleRef, table);
            return table;
        }

        BinaryBinary binary;
        binary = (BinaryBinary)this.BinaryTable.Get(moduleRef);

        Array array;
        array = binary.Import;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryImport import;
            import = (BinaryImport)array.GetAt(i);

            ModuleRef e;
            e = import.Module;

            Table aa;
            aa = this.BinaryDepend(e);
            if (aa == null)
            {
                listInfra.TableAdd(binaryDependTable, moduleRef, null);
                return null;
            }

            Iter iter;
            iter = aa.IterCreate();
            aa.IterSet(iter);

            while (iter.Next())
            {
                ModuleRef oo;
                oo = (ModuleRef)iter.Index;

                if (!table.Valid(oo))
                {
                    listInfra.TableAdd(table, oo, oo);
                }
            }

            i = i + 1;
        }

        if (table.Valid(moduleRef))
        {
            this.Status = 60;
            listInfra.TableAdd(binaryDependTable, moduleRef, null);
            return null;
        }

        listInfra.TableAdd(binaryDependTable, moduleRef, table);
        return table;
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
        iter = this.ImportDependTable.IterCreate();
        this.ImportDependTable.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef moduleRef;
            moduleRef = (ModuleRef)iter.Index;

            moduleLoad.ModuleRef = moduleRef;
            moduleLoad.Execute();

            long o;
            o = moduleLoad.Status;
            if (!(o == 0))
            {
                this.Status = 100 + o;
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

        ModuleRef moduleRef;
        moduleRef = this.Port.Module;

        ClassModule module;
        module = new ClassModule();
        module.Init();
        module.Ref = classInfra.ModuleRefCreate(moduleRef.Name, moduleRef.Version);
        module.Class = classInfra.TableCreateStringLess();
        module.Storage = classInfra.TableCreateStringLess();

        this.Module = module;
        return true;
    }

    protected virtual bool SetModuleImport()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Table moduleTable;
        moduleTable = this.ModuleTable;

        Table classTable;
        classTable = this.ClassTable;

        Table importTable;
        importTable = this.ImportTable;

        NameCheck nameCheck;
        nameCheck = this.NameCheck;

        Array importModuleRef;
        importModuleRef = this.ImportModuleRefArray;

        Array array;
        array = this.Port.Import;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef kk;
            kk = (ModuleRef)importModuleRef.GetAt(i);

            ClassModule k;
            k = (ClassModule)moduleTable.Get(kk);

            Table a;
            a = classInfra.TableCreateRefLess();
            
            listInfra.TableAdd(importTable, kk, a);

            PortImport kkk;
            kkk = (PortImport)array.GetAt(i);

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

                if (!nameCheck.IsName(this.TA(className)))
                {
                    this.Status = 80;
                    return false;
                }

                ClassClass varClass;
                varClass = (ClassClass)k.Class.Get(className);

                if (varClass == null)
                {
                    this.Status = 81;
                    return false;
                }

                listInfra.TableAdd(a, varClass, varClass);

                String name;
                name = importClass.Name;
                
                if (!nameCheck.IsName(this.TA(name)))
                {
                    this.Status = 82;
                    return false;
                }
                
                if (classTable.Valid(name))
                {
                    this.Status = 83;
                    return false;
                }

                listInfra.TableAdd(classTable, name, varClass);

                iA = iA + 1;
            }
        }
        return true;
    }

    protected virtual bool SetModuleExport()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table classTable;
        classTable = this.ClassTable;

        Table exportTable;
        exportTable = this.ExportTable;

        NameCheck nameCheck;
        nameCheck = this.NameCheck;

        Array array;
        array = this.Port.Export;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortExport a;
            a = (PortExport)array.GetAt(i);

            String name;
            name = a.Class;

            if (!nameCheck.IsName(this.TA(name)))
            {
                this.Status = 85;
                return false;
            }

            if (classTable.Valid(name))
            {
                this.Status = 86;
                return false;
            }

            if (exportTable.Valid(name))
            {
                this.Status = 87;
                return false;
            }

            listInfra.TableAdd(exportTable, name, null);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetModuleStorage()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        StoragePathCheck pathCheck;
        pathCheck = this.StoragePathCheck;

        Table table;
        table = this.Module.Storage;

        Array array;
        array = this.Port.Storage;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ClassStorage a;
            a = (ClassStorage)array.GetAt(i);

            String sourcePath;
            String destPath;
            sourcePath = a.SourcePath;
            destPath = a.Path;

            if (!pathCheck.IsValidSourcePath(this.TA(sourcePath)))
            {
                this.Status = 90;
                return false;
            }

            if (!pathCheck.IsValidDestPath(this.TA(destPath)))
            {
                this.Status = 91;
                return false;
            }

            if (table.Valid(destPath))
            {
                this.Status = 92;
                return false;
            }

            ClassStorage m;
            m = new ClassStorage();
            m.Init();
            m.Path = destPath;
            m.SourcePath = sourcePath;

            listInfra.TableAdd(table, destPath, m);

            i = i + 1;
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

        if (!this.ExportTable.Valid(entry))
        {
            this.Status = 95;
            return false;
        }

        this.Module.Entry = entry;
        return true;
    }

    protected virtual bool IsBuiltinModuleRef(ModuleRef moduleRef)
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
        if (!b)
        {
            if (this.TextSame(textName, this.TB(this.ClassModuleSingle)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextStart(textName, this.TB(this.ClassModulePre)))
            {
                b = true;
            }
        }

        return b;
    }
}