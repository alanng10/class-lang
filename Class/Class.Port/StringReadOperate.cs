namespace Class.Port;

public class StringReadOperate : ReadOperate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.String = "";
        this.Array = this.ListInfra.ArrayCreate(0);
        this.Port = new Port();
        this.Port.Init();
        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);
        this.Import = new Import();
        this.Import.Init();
        this.ImportClass = new ImportClass();
        this.ImportClass.Init();
        this.Export = new Export();
        this.Export.Init();
        this.Storage = new Storage();
        this.Storage.Init();
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual string String { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual Port Port { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual Import Import { get; set; }
    protected virtual ImportClass ImportClass { get; set; }
    protected virtual Export Export { get; set; }
    protected virtual Storage Storage { get; set; }

    public override string ExecuteString(int row, Range range)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.StringIndex;

        Data data;
        data = arg.StringTextData;
        long nn;
        nn = index;
        nn = nn * sizeof(uint) * 3;

        uint u;
        u = (uint)row;
        infraInfra.DataMidSet(data, nn, u);
        u = (uint)range.Index;
        infraInfra.DataMidSet(data, nn + 1, u);
        u = (uint)range.Count;
        infraInfra.DataMidSet(data, nn + 2, u);

        arg.StringIndex = index + 1;
        return this.String;
    }

    public override Array ExecuteArray(int count)
    {
        ReadArg arg;
        arg = this.Read.Arg;

        int arrayIndex;
        arrayIndex = arg.ArrayIndex;

        long nn;
        nn = arrayIndex;
        nn = nn * sizeof(uint);
        uint u;
        u = (uint)count;
        this.InfraInfra.DataMidSet(arg.ArrayCountData, nn, u);

        arg.ArrayIndex = arrayIndex + 1;
        return this.Array;
    }

    public override Port ExecutePort()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.PortIndex = arg.PortIndex + 1;
        return this.Port;
    }

    public override ModuleRef ExecuteModuleRef()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ModuleRefIndex = arg.ModuleRefIndex + 1;
        return this.ModuleRef;
    }

    public override Import ExecuteImport()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ImportIndex = arg.ImportIndex + 1;
        return this.Import;
    }

    public override ImportClass ExecuteImportClass()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ImportClassIndex = arg.ImportClassIndex + 1;
        return this.ImportClass;
    }

    public override Export ExecuteExport()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ExportIndex = arg.ExportIndex + 1;
        return this.Export;
    }

    public override Storage ExecuteStorage()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.StorageIndex = arg.StorageIndex + 1;
        return this.Storage;
    }
}