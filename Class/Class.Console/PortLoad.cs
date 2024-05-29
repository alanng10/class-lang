namespace Class.Console;

public class PortLoad : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.TextA = this.CreateText();
        this.TextB = this.CreateText();

        this.StringDataA = new StringData();
        this.StringDataA.Init();
        this.StringDataB = new StringData();
        this.StringDataB.Init();

        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();
        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = charCompare;
        this.TextCompare.Init();

        this.SystemModuleSingle = "System";
        this.SystemModulePre = this.SystemModuleSingle + ".";
        this.ClassModuleSingle = "Class";
        this.ClassModulePre = this.ClassModuleSingle + ".";
        return true;
    }
    public virtual PortPort Port { get; set; }
    public virtual int Status { get; set; }
    public virtual ModuleLoad ModuleLoad { get; set; }
    public virtual BinaryRead BinaryRead { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual Text TextB { get; set; }
    protected virtual StringData StringDataA { get; set; }
    protected virtual StringData StringDataB { get; set; }
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual Array ImportModuleRefArray { get; set; }
    protected virtual string SystemModuleSingle { get; set; }
    protected virtual string SystemModulePre { get; set; }
    protected virtual string ClassModuleSingle { get; set; }
    protected virtual string ClassModulePre { get; set; }

    private Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new InfraRange();
        a.Range.Init();
        return a;
    }

    public virtual bool Execute()
    {
        PortPort port;
        port = this.Port;

        if (!this.CheckModuleRef(port.Module))
        {
            this.Status = 5;
            return false;
        }

        if (!this.CheckImportArrayModuleRef(port.Import))
        {
            return false;
        }

        bool b;
        b = this.SetImportModuleRef();
        if (!b)
        {
            return false;
        }

        b = this.ImportBinaryLoad();
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

        Table table;
        table = classInfra.TableCreateModuleRefCompare();

        Array import;
        import = this.Port.Import;

        Array array;
        array = listInfra.ArrayCreate(import.Count);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            PortImport o;
            o = (PortImport)import.Get(i);

            ModuleRef aa;
            aa = o.Module;

            string name;
            name = aa.Name;
            long version;
            version = aa.Version;
            if (version == -1)
            {
                version = 0;
            }

            ModuleRef a;
            a = classInfra.ModuleRefCreate(name, version);

            if (table.Contain(a))
            {
                this.Status = 30;
                return false;
            }

            listInfra.TableAdd(table, a, a);

            array.Set(i, a);

            i = i + 1;
        }

        this.ImportModuleRefArray = array;
        return true;
    }

    protected virtual bool CheckModuleRef(ModuleRef module)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;
        
        Text textA;
        Text textB;
        textA = this.TextA;
        textB = this.TextB;

        StringData dataA;
        StringData dataB;
        dataA = this.StringDataA;
        dataB = this.StringDataB;

        Compare compare;
        compare = this.TextCompare;

        string name;
        name = module.Name;
        long version;
        version = module.Version;

        this.TextStringGet(textA, dataA, name);

        if (!(classInfra.IsModuleName(this.NameCheck, textA)))
        {
            return false;
        }

        if (version == -1)
        {
            return false;
        }

        this.TextStringGet(textB, dataB, this.SystemModuleSingle);
        if (textInfra.Equal(textA, textB, compare))
        {
            return false;
        }

        this.TextStringGet(textB, dataB, this.SystemModulePre);
        if (textInfra.Start(textA, textB, compare))
        {
            return false;
        }

        this.TextStringGet(textB, dataB, this.ClassModuleSingle);
        if (textInfra.Equal(textA, textB, compare))
        {
            return false;
        }

        this.TextStringGet(textB, dataB, this.ClassModulePre);
        if (textInfra.Start(textA, textB, compare))
        {
            return false;
        }

        return true;
    }

    protected virtual bool CheckImportArrayModuleRef(Array array)
    {
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            PortImport a;
            a = (PortImport)array.Get(i);

            if (!this.CheckImportModuleRef(a.Module))
            {
                this.Status = 7;
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

        Text textA;
        Text textB;
        textA = this.TextA;
        textB = this.TextB;

        StringData dataA;
        StringData dataB;
        dataA = this.StringDataA;
        dataB = this.StringDataB;

        string name;
        name = moduleRef.Name;
        long version;
        version = moduleRef.Version;

        this.TextStringGet(textA, dataA, name);
        if (!(classInfra.IsModuleName(this.NameCheck, textA)))
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

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ModuleRef a;
            a = (ModuleRef)array.Get(i);

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
        if (this.BinaryTable.Contain(moduleRef))
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
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryImport import;
            import = (BinaryImport)array.Get(i);

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
        string moduleName;
        moduleName = moduleRef.Name;
        long version;
        version = moduleRef.Version;

        string versionString;
        versionString = this.ClassInfra.VersionString(version);
    
        string moduleRefString;
        moduleRefString = moduleName + "-" + versionString;

        string filePath;
        filePath = moduleRefString + ".ref";

        Data data;
        data = this.StorageInfra.DataRead(filePath);

        if (data == null)
        {
            this.Status = 50;
            return false;
        }

        int kk;
        kk = (int)data.Count;

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

    protected virtual bool IsBuiltinModuleRef(ModuleRef moduleRef)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Text textA;
        Text textB;
        textA = this.TextA;
        textB = this.TextB;

        StringData dataA;
        StringData dataB;
        dataA = this.StringDataA;
        dataB = this.StringDataB;

        Compare compare;
        compare = this.TextCompare;

        string name;
        name = moduleRef.Name;

        this.TextStringGet(textA, dataA, name);

        if (!(classInfra.IsModuleName(this.NameCheck, textA)))
        {
            return false;
        }

        bool b;
        b = false;

        if (!b)
        {
            this.TextStringGet(textB, dataB, this.SystemModuleSingle);
            if (textInfra.Equal(textA, textB, compare))
            {
                b = true;
            }
        }
        if (!b)
        {
            this.TextStringGet(textB, dataB, this.SystemModulePre);
            if (textInfra.Start(textA, textB, compare))
            {
                b = true;
            }
        }
        if (!b)
        {
            this.TextStringGet(textB, dataB, this.ClassModuleSingle);
            if (textInfra.Equal(textA, textB, compare))
            {
                b = true;
            }
        }
        if (!b)
        {
            this.TextStringGet(textB, dataB, this.ClassModulePre);
            if (textInfra.Start(textA, textB, compare))
            {
                b = true;
            }
        }

        return b;
    }

    protected virtual bool TextStringGet(Text text, StringData data, string o)
    {
        data.Value = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = o.Length;
        return true;
    }
}