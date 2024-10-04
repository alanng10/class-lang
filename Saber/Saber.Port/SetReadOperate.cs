namespace Saber.Port;

public class SetReadOperate : ReadOperate
{
    public virtual Read Read { get; set; }

    public override String ExecuteString(long row, Range range)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.StringIndex;
        String a;
        a = (String)arg.StringArray.GetAt(index);
        arg.StringIndex = index + 1;
        return a;
    }

    public override Array ExecuteArray(long count)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ArrayIndex;
        Array a;
        a = (Array)arg.ArrayArray.GetAt(index);
        arg.ArrayIndex = index + 1;
        return a;
    }

    public override bool ExecuteArrayItemSet(Array array, long index, object value)
    {
        array.SetAt(index, value);
        return true;
    }

    public override Port ExecutePort()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.PortIndex;
        Port a;
        a = (Port)arg.PortArray.GetAt(index);
        arg.PortIndex = index + 1;
        return a;
    }

    public override ModuleRef ExecuteModuleRef()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ModuleRefIndex;
        ModuleRef a;
        a = (ModuleRef)arg.ModuleRefArray.GetAt(index);
        arg.ModuleRefIndex = index + 1;
        return a;
    }

    public override Import ExecuteImport()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ImportIndex;
        Import a;
        a = (Import)arg.ImportArray.GetAt(index);
        arg.ImportIndex = index + 1;
        return a;
    }

    public override ImportClass ExecuteImportClass()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ImportClassIndex;
        ImportClass a;
        a = (ImportClass)arg.ImportClassArray.GetAt(index);
        arg.ImportClassIndex = index + 1;
        return a;
    }

    public override Export ExecuteExport()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ExportIndex;
        Export a;
        a = (Export)arg.ExportArray.GetAt(index);
        arg.ExportIndex = index + 1;
        return a;
    }

    public override Storage ExecuteStorage()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.StorageIndex;
        Storage a;
        a = (Storage)arg.StorageArray.GetAt(index);
        arg.StorageIndex = index + 1;
        return a;
    }
}