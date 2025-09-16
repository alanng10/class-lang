namespace Saber.Binary;

public class ReadStringOperate : ReadOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.Binary = this.CreateBinary();
        this.Class = this.CreateClass();
        this.Import = this.CreateImport();
        this.Part = this.CreatePart();
        this.Field = this.CreateField();
        this.Maide = this.CreateMaide();
        this.Var = this.CreateVar();
        this.Entry = this.CreateEntry();
        this.ClassIndex = this.CreateClassIndex();
        this.ModuleRef = this.CreateModuleRef();
        this.String = this.CreateString();
        this.Array = this.CreateArray();
        this.Data = this.CreateData();
        return true;
    }

    protected virtual Binary CreateBinary()
    {
        Binary a;
        a = new Binary();
        a.Init();
        return a;
    }

    protected virtual Class CreateClass()
    {
        Class a;
        a = new Class();
        a.Init();
        return a;
    }

    protected virtual Import CreateImport()
    {
        Import a;
        a = new Import();
        a.Init();
        return a;
    }

    protected virtual Part CreatePart()
    {
        Part a;
        a = new Part();
        a.Init();
        return a;
    }

    protected virtual Field CreateField()
    {
        Field a;
        a = new Field();
        a.Init();
        return a;
    }

    protected virtual Maide CreateMaide()
    {
        Maide a;
        a = new Maide();
        a.Init();
        return a;
    }

    protected virtual Var CreateVar()
    {
        Var a;
        a = new Var();
        a.Init();
        return a;
    }

    protected virtual Entry CreateEntry()
    {
        Entry a;
        a = new Entry();
        a.Init();
        return a;
    }

    protected virtual Value CreateClassIndex()
    {
        Value a;
        a = new Value();
        a.Init();
        return a;
    }

    protected virtual ModuleRef CreateModuleRef()
    {
        return this.ClassInfra.ModuleRefCreate(null, -1);
    }

    protected virtual String CreateString()
    {
        return this.TextInfra.Zero;
    }

    protected virtual Array CreateArray()
    {
        return this.ListInfra.ArrayCreate(0);
    }

    protected virtual Data CreateData()
    {
        Data a;
        a = new Data();
        a.Count = 0;
        a.Init();
        return a;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Binary Binary { get; set; }
    protected virtual Class Class { get; set; }
    protected virtual Import Import { get; set; }
    protected virtual Part Part { get; set; }
    protected virtual Field Field { get; set; }
    protected virtual Maide Maide { get; set; }
    protected virtual Var Var { get; set; }
    protected virtual Entry Entry { get; set; }
    protected virtual Value ClassIndex { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual String String { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual Data Data { get; set; }

    public override Binary ExecuteBinary()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.BinaryIndex = arg.BinaryIndex + 1;
        return this.Binary;
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

    public override Value ExecuteClassIndex()
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

    public override String ExecuteString(long count)
    {
        ReadArg arg;
        arg = this.Read.Arg;

        long kd;
        kd = arg.StringIndex;
        kd = kd * sizeof(long);
        this.InfraInfra.DataIntSet(arg.StringCountData, kd, count);

        long i;
        i = 0;
        while (i < count)
        {
            long ka;
            ka = this.Read.Data.Get(arg.Index + i);

            this.TextInfra.DataCharSet(arg.StringTextData, arg.StringTextIndex + i, ka);

            i = i + 1;
        }

        arg.Index = arg.Index + count;
        arg.StringIndex = arg.StringIndex + 1;
        arg.StringTextIndex = arg.StringTextIndex + count;
        return this.String;
    }

    public override Array ExecuteArray(long count)
    {
        ReadArg arg;
        arg = this.Read.Arg;

        long kd;
        kd = arg.ArrayIndex;
        kd = kd * sizeof(long);
        this.InfraInfra.DataIntSet(arg.ArrayCountData, kd, count);

        arg.ArrayIndex = arg.ArrayIndex + 1;
        return this.Array;
    }

    public override bool ExecuteArrayItemSet(Array array, long index, object value)
    {
        return true;
    }
}