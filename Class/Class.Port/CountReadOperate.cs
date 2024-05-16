namespace Class.Port;

public class CountReadOperate : ReadOperate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.String = "";
        this.Array = this.ListInfra.ArrayCreate(0);
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual string String { get; set; }
    protected virtual Array Array { get; set; }

    public override string ExecuteString(int row, Range range)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.StringIndex = arg.StringIndex + 1;
        return this.String;
    }

    public override Array ExecuteArray(int count)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ArrayIndex = arg.ArrayIndex + 1;
        return this.Array;
    }

    public override ModuleRef ExecuteModuleRef()
    {
        return null;
    }

    public override Import ExecuteImport()
    {
        return null;
    }

    public override ImportClass ExecuteImportClass()
    {
        return null;
    }

    public override Export ExecuteExport()
    {
        return null;
    }

    public override Storage ExecuteStorage()
    {
        return null;
    }
}