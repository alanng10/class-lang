namespace Saber.Port;

public class CountReadOperate : ReadOperate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.String = this.CreateString();
        this.Array = this.CreateArray();
        this.Port = this.CreatePort();
        this.ModuleRef = this.CreateModuleRef();
        this.Import = this.CreateImport();
        this.ImportClass = this.CreateImportClass();
        this.Export = this.CreateExport();
        this.Storage = this.CreateStorage();
        return true;
    }

    protected virtual String CreateString()
    {
        return this.TextInfra.Zero;
    }

    protected virtual Array CreateArray()
    {
        return this.ListInfra.ArrayCreate(0);
    }

    protected virtual Port CreatePort()
    {
        Port a;
        a = new Port();
        a.Init();
        return a;
    }

    protected virtual ModuleRef CreateModuleRef()
    {
        return this.ClassInfra.ModuleRefCreate(null, 0);
    }

    protected virtual Import CreateImport()
    {
        Import a;
        a = new Import();
        a.Init();
        return a;
    }

    protected virtual ImportClass CreateImportClass()
    {
        ImportClass a;
        a = new ImportClass();
        a.Init();
        return a;
    }

    protected virtual Export CreateExport()
    {
        Export a;
        a = new Export();
        a.Init();
        return a;
    }

    protected virtual Storage CreateStorage()
    {
        Storage a;
        a = new Storage();
        a.Init();
        return a;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual String String { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual Port Port { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual Import Import { get; set; }
    protected virtual ImportClass ImportClass { get; set; }
    protected virtual Export Export { get; set; }
    protected virtual Storage Storage { get; set; }

    public override String ExecuteString(long row, Range range)
    {
        ReadArg arg;
        arg = this.Arg;
        arg.StringIndex = arg.StringIndex + 1;
        return this.String;
    }

    public override Array ExecuteArray(long count)
    {
        ReadArg arg;
        arg = this.Arg;
        arg.ArrayIndex = arg.ArrayIndex + 1;
        return this.Array;
    }

    public override Port ExecutePort()
    {
        ReadArg arg;
        arg = this.Arg;
        arg.PortIndex = arg.PortIndex + 1;
        return this.Port;
    }

    public override ModuleRef ExecuteModuleRef()
    {
        ReadArg arg;
        arg = this.Arg;
        arg.ModuleRefIndex = arg.ModuleRefIndex + 1;
        return this.ModuleRef;
    }

    public override Import ExecuteImport()
    {
        ReadArg arg;
        arg = this.Arg;
        arg.ImportIndex = arg.ImportIndex + 1;
        return this.Import;
    }

    public override ImportClass ExecuteImportClass()
    {
        ReadArg arg;
        arg = this.Arg;
        arg.ImportClassIndex = arg.ImportClassIndex + 1;
        return this.ImportClass;
    }

    public override Export ExecuteExport()
    {
        ReadArg arg;
        arg = this.Arg;
        arg.ExportIndex = arg.ExportIndex + 1;
        return this.Export;
    }

    public override Storage ExecuteStorage()
    {
        ReadArg arg;
        arg = this.Arg;
        arg.StorageIndex = arg.StorageIndex + 1;
        return this.Storage;
    }
}