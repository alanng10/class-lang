namespace Class.Port;

public class SetReadOperate : ReadOperate
{
    public virtual Read Read { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }

    public override string ExecuteString(int row, Range range)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.StringIndex;
        string a;
        a = (string)arg.StringArray.Get(index);
        arg.StringIndex = index + 1;
        return a;
    }

    public override Array ExecuteArray(int count)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.ArrayIndex;
        Array a;
        a = (Array)arg.ArrayArray.Get(index);
        arg.ArrayIndex = index + 1;
        return a;
    }

    public override Port ExecutePort()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.PortIndex;
        Port a;
        a = (Port)arg.PortArray.Get(index);
        arg.PortIndex = index + 1;
        return a;
    }

    public override ModuleRef ExecuteModuleRef()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.ModuleRefIndex;
        ModuleRef a;
        a = (ModuleRef)arg.ModuleRefArray.Get(index);
        arg.ModuleRefIndex = index + 1;
        return a;
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