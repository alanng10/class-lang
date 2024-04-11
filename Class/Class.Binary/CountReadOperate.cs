namespace Class.Binary;

public class CountReadOperate : ReadOperate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.Refer = new Binary();
        this.Refer.Init();
        this.Class = new Class();
        this.Class.Init();
        this.Import = new Import();
        this.Import.Init();
        this.Part = new Part();
        this.Part.Init();
        this.Field = new Field();
        this.Field.Init();
        this.Maide = new Maide();
        this.Maide.Init();
        this.Var = new Var();
        this.Var.Init();
        this.ClassIndex = new ClassIndex();
        this.ClassIndex.Init();
        this.ModuleRef = new ModuleRef();
        this.ModuleRef.Init();
        this.String = "";
        this.Array = this.ListInfra.ArrayCreate(0);
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual Binary Refer { get; set; }
    protected virtual Class Class { get; set; }
    protected virtual Import Import { get; set; }
    protected virtual Part Part { get; set; }
    protected virtual Field Field { get; set; }
    protected virtual Maide Maide { get; set; }
    protected virtual Var Var { get; set; }
    protected virtual ClassIndex ClassIndex { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual string String { get; set; }
    protected virtual Array Array { get; set; }

    public override Binary ExecuteRefer()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ReferIndex = arg.ReferIndex + 1;
        return this.Refer;
    }

    public override Class ExecuteClass()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ClassIndex = arg.ClassIndex + 1;
        return this.Class;
    }

    public override Import ExecuteImport()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ImportIndex = arg.ImportIndex + 1;
        return this.Import;
    }

    public override Part ExecutePart()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.PartIndex = arg.PartIndex + 1;
        return this.Part;
    }

    public override Field ExecuteField()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.FieldIndex = arg.FieldIndex + 1;
        return this.Field;
    }

    public override Maide ExecuteMaide()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.MaideIndex = arg.MaideIndex + 1;
        return this.Maide;
    }

    public override Var ExecuteVar()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.VarIndex = arg.VarIndex + 1;
        return this.Var;
    }

    public override ClassIndex ExecuteClassIndex()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ClassIndexIndex = arg.ClassIndexIndex + 1;
        return this.ClassIndex;
    }

    public override ModuleRef ExecuteModuleRef()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ModuleRefIndex = arg.ModuleRefIndex + 1;
        return this.ModuleRef;
    }

    public override string ExecuteString(int count)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.Index = arg.Index + count;
        arg.StringIndex = arg.StringIndex + 1;
        arg.StringTextIndex = arg.StringTextIndex + count;
        return this.String;
    }

    public override Array ExecuteArray(int count)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.ArrayIndex = arg.ArrayIndex + 1;
        return this.Array;
    }

    public override bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        return true;
    }
}