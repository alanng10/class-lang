namespace Saber.Port;

public class SetReadOperate : ReadOperate
{
    public override String ExecuteString(long row, Range range)
    {
        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.StringIndex;
        String a;
        a = arg.StringArray.GetAt(index) as String;
        arg.StringIndex = index + 1;
        return a;
    }

    public override Array ExecuteArray(long count)
    {
        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.ArrayIndex;
        Array a;
        a = arg.ArrayArray.GetAt(index) as Array;
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
        arg = this.Arg;
        long index;
        index = arg.PortIndex;
        Port a;
        a = arg.PortArray.GetAt(index) as Port;
        arg.PortIndex = index + 1;
        return a;
    }

    public override ModuleRef ExecuteModuleRef()
    {
        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.ModuleRefIndex;
        ModuleRef a;
        a = arg.ModuleRefArray.GetAt(index) as ModuleRef;
        arg.ModuleRefIndex = index + 1;
        return a;
    }

    public override Import ExecuteImport()
    {
        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.ImportIndex;
        Import a;
        a = arg.ImportArray.GetAt(index) as Import;
        arg.ImportIndex = index + 1;
        return a;
    }

    public override ImportClass ExecuteImportClass()
    {
        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.ImportClassIndex;
        ImportClass a;
        a = arg.ImportClassArray.GetAt(index) as ImportClass;
        arg.ImportClassIndex = index + 1;
        return a;
    }

    public override Export ExecuteExport()
    {
        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.ExportIndex;
        Export a;
        a = arg.ExportArray.GetAt(index) as Export;
        arg.ExportIndex = index + 1;
        return a;
    }

    public override Storage ExecuteStorage()
    {
        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.StorageIndex;
        Storage a;
        a = arg.StorageArray.GetAt(index) as Storage;
        arg.StorageIndex = index + 1;
        return a;
    }
}