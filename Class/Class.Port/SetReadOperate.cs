namespace Class.Port;

public class SetReadOperate : ReadOperate
{
    public virtual Read Read { get; set; }

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
        int index;
        index = arg.ImportIndex;
        Import a;
        a = (Import)arg.ImportArray.Get(index);
        arg.ImportIndex = index + 1;
        return a;
    }

    public override ImportClass ExecuteImportClass()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.ImportClassIndex;
        ImportClass a;
        a = (ImportClass)arg.ImportClassArray.Get(index);
        arg.ImportClassIndex = index + 1;
        return a;
    }

    public override Export ExecuteExport()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.ExportIndex;
        Export a;
        a = (Export)arg.ExportArray.Get(index);
        arg.ExportIndex = index + 1;
        return a;
    }

    public override Storage ExecuteStorage()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.StorageIndex;
        Storage a;
        a = (Storage)arg.StorageArray.Get(index);
        arg.StorageIndex = index + 1;
        return a;
    }
}