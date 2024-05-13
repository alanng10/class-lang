namespace Z.Tool.DocReference;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.StorageArrange = StorageArrange.This;

        this.BinaryRead = this.CreateBinaryRead();
        this.ModuleLoad = this.CreateModuleLoad();


        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StorageArrange StorageArrange { get; set; }
    protected virtual Table ModuleTable { get; set; }
    protected virtual Table BinaryTable { get; set; }
    protected virtual BinaryRead BinaryRead { get; set; }
    protected virtual ModuleLoad ModuleLoad { get; set; }
    protected virtual string ReferenceFoldPath { get; set; }

    public virtual int Execute()
    {
        this.ReferenceFoldPath = "../../Doc/Reference";

        this.ModuleTable = this.ClassInfra.TableCreateModuleRefCompare();
        this.BinaryTable = this.ClassInfra.TableCreateModuleRefCompare();

        this.ModuleLoad.ModuleTable = this.ModuleTable;
        this.ModuleLoad.BinaryTable = this.BinaryTable;

        this.InitSystem();

        this.ExecuteAllModule();

        return 0;
    }

    protected virtual bool InitSystem()
    {
        this.InitBinary("System.Infra");
        this.InitBinary("System.List");
        this.InitBinary("System.Math");
        this.InitBinary("System.Text");
        this.InitBinary("System.Event");
        this.InitBinary("System.Comp");
        this.InitBinary("System.Thread");
        this.InitBinary("System.Stream");
        this.InitBinary("System.Type");
        this.InitBinary("System.Time");
        this.InitBinary("System.Video");
        this.InitBinary("System.Audio");
        this.InitBinary("System.Storage");
        this.InitBinary("System.Network");
        this.InitBinary("System.Console");
        this.InitBinary("System.Media");
        this.InitBinary("System.Draw");
        this.InitBinary("System.View");
        this.InitBinary("System.Main");
        this.InitBinary("System.Entry");
        this.InitBinary("Class.Infra");
        this.InitBinary("Class.Binary");
        this.InitBinary("Class.Doc");
        this.InitBinary("Class.Port");
        this.InitBinary("Class.Token");
        this.InitBinary("Class.Node");
        this.InitBinary("Class.Module");
        this.InitBinary("Class.Console");

        this.InitModuleList();

        return true;
    }

    protected virtual bool ExecuteAllModule()
    {
        Iter iter;
        iter = this.ModuleTable.IterCreate();
        this.ModuleTable.IterSet(iter);
        while (iter.Next())
        {
            ClassModule module;
            module = (ClassModule)iter.Value;
            this.ExecuteModule(module);
        }
        return true;
    }

    protected virtual bool ExecuteModule(ClassModule module)
    {
        string foldPath;
        foldPath = this.ReferenceFoldPath + "/" + module.Ref.Name;

        string ka;
        ka = foldPath + "/";


        return true;
    }

    protected virtual string Version(long o)
    {
        long revision;
        revision = o & 0xff;

        long minor;
        minor = (o >> 8) & 0xff;

        long ka;
        ka = this.InfraInfra.IntCapValue - 1;

        long major;
        major = (o >> 16) & ka;

        return null;
    }

    protected virtual bool InitBinary(string moduleName)
    {
        string filePath;
        filePath = moduleName + ".ref";

        Data data;
        data = this.StorageInfra.DataRead(filePath);

        if (data == null)
        {
            global::System.Console.Error.Write("DocReference:Gen.InitBinary data is null, module name: " + moduleName + "\n");
            global::System.Environment.Exit(1001);
        }

        BinaryRead read;
        read = this.BinaryRead;

        read.Data = data;

        read.Execute();

        BinaryBinary binary;
        binary = read.Binary;

        if (binary == null)
        {
            global::System.Console.Error.Write("DocReference:Gen.InitBinary binary is null, module name: " + moduleName + "\n");
            global::System.Environment.Exit(1000);
        }

        read.Binary = null;

        this.ListInfra.TableAdd(this.BinaryTable, binary.Ref, binary);
        return true;
    }

    protected virtual bool InitModuleList()
    {
        Iter iter;
        iter = this.BinaryTable.IterCreate();
        this.BinaryTable.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef moduleRef;
            moduleRef = (ModuleRef)iter.Index;

            this.ModuleLoad.ModuleRef = moduleRef;
            this.ModuleLoad.Execute();

            ClassModule a;
            a = this.ModuleLoad.Module;

            this.ModuleLoad.Module = null;

            this.ListInfra.TableAdd(this.ModuleTable, a.Ref, a);
        }
        return true;
    }

    protected virtual BinaryRead CreateBinaryRead()
    {
        BinaryRead a;
        a = new BinaryRead();
        a.Init();
        return a;
    }

    protected virtual ModuleLoad CreateModuleLoad()
    {
        ModuleLoad a;
        a = new ModuleLoad();
        a.Init();
        return a;
    }
}