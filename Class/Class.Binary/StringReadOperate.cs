namespace Class.Binary;

public class StringReadOperate : ReadOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.Binary = new Binary();
        this.Binary.Init();
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
        this.ClassIndex = new Value();
        this.ClassIndex.Init();
        this.ModuleRef = new ModuleRef();
        this.ModuleRef.Init();
        this.Range = new Range();
        this.Range.Init();
        this.String = this.TextInfra.Zero;
        this.Array = this.ListInfra.ArrayCreate(0);
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Binary Binary { get; set; }
    protected virtual Class Class { get; set; }
    protected virtual Import Import { get; set; }
    protected virtual Part Part { get; set; }
    protected virtual Field Field { get; set; }
    protected virtual Maide Maide { get; set; }
    protected virtual Var Var { get; set; }
    protected virtual Value ClassIndex { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual Range Range { get; set; }
    protected virtual String String { get; set; }
    protected virtual Array Array { get; set; }

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

    public override Range ExecuteRange()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        arg.RangeIndex = arg.RangeIndex + 1;
        return this.Range;
    }

    public override String ExecuteString(long count)
    {
        Read read;
        read = this.Read;
        ReadArg arg;
        arg = read.Arg;

        TextInfra textInfra;
        textInfra = this.TextInfra;

        long index;
        index = arg.Index;
        long stringIndex;
        stringIndex = arg.StringIndex;

        long nn;
        nn = stringIndex;
        nn = nn * sizeof(ulong);
        this.InfraInfra.DataIntSet(arg.StringCountData, nn, count);

        Data data;
        data = read.Data;
        Data stringTextData;
        stringTextData = arg.StringTextData;

        long oa;
        oa = arg.StringTextIndex;
        long i;
        i = 0;
        while (i < count)
        {
            long oo;
            oo = data.Get(index + i);
            byte ooa;
            ooa = (byte)oo;
            long oob;
            oob = ooa;
            textInfra.DataCharSet(stringTextData, oa + i, oob);
            i = i + 1;
        }
        
        arg.Index = index + count;
        arg.StringIndex = stringIndex + 1;
        arg.StringTextIndex = oa + count;
        return this.String;
    }

    public override Array ExecuteArray(long count)
    {
        Read read;
        read = this.Read;
        ReadArg arg;
        arg = read.Arg;

        long arrayIndex;
        arrayIndex = arg.ArrayIndex;

        long nn;
        nn = arrayIndex;
        nn = nn * sizeof(ulong);
        this.InfraInfra.DataIntSet(arg.ArrayCountData, nn, count);

        arg.ArrayIndex = arrayIndex + 1;
        return this.Array;
    }

    public override bool ExecuteArrayItemSet(Array array, long index, object value)
    {
        return true;
    }
}