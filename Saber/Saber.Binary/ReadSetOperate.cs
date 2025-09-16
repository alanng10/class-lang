namespace Saber.Binary;

public class ReadSetOperate : ReadOperate
{
    public override Binary ExecuteBinary()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.BinaryIndex;
        Binary a;
        a = arg.BinaryArray.GetAt(index) as Binary;
        arg.BinaryIndex = index + 1;
        return a;
    }

    public override Class ExecuteClass()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ClassIndex;
        Class a;
        a = arg.ClassArray.GetAt(index) as Class;
        arg.ClassIndex = index + 1;
        return a;
    }

    public override Import ExecuteImport()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ImportIndex;
        Import a;
        a = arg.ImportArray.GetAt(index) as Import;
        arg.ImportIndex = index + 1;
        return a;
    }

    public override Part ExecutePart()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.PartIndex;
        Part a;
        a = arg.PartArray.GetAt(index) as Part;
        arg.PartIndex = index + 1;
        return a;
    }

    public override Field ExecuteField()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.FieldIndex;
        Field a;
        a = arg.FieldArray.GetAt(index) as Field;
        arg.FieldIndex = index + 1;
        return a;
    }

    public override Maide ExecuteMaide()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.MaideIndex;
        Maide a;
        a = arg.MaideArray.GetAt(index) as Maide;
        arg.MaideIndex = index + 1;
        return a;
    }

    public override Var ExecuteVar()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.VarIndex;
        Var a;
        a = arg.VarArray.GetAt(index) as Var;
        arg.VarIndex = index + 1;
        return a;
    }

    public override Entry ExecuteEntry()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.EntryIndex;
        Entry a;
        a = arg.EntryArray.GetAt(index) as Entry;
        arg.EntryIndex = index + 1;
        return a;
    }

    public override Value ExecuteClassIndex()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ClassIndexIndex;
        Value a;
        a = arg.ClassIndexArray.GetAt(index) as Value;
        arg.ClassIndexIndex = index + 1;
        return a;
    }

    public override ModuleRef ExecuteModuleRef()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.ModuleRefIndex;
        ModuleRef a;
        a = arg.ModuleRefArray.GetAt(index) as ModuleRef;
        arg.ModuleRefIndex = index + 1;
        return a;
    }

    public override String ExecuteString(long count)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        long index;
        index = arg.StringIndex;
        String a;
        a = arg.StringArray.GetAt(index) as String;

        arg.Index = arg.Index + count;
        arg.StringIndex = index + 1;
        arg.StringTextIndex = arg.StringTextIndex + count;
        return a;
    }

    public override Array ExecuteArray(long count)
    {
        ReadArg arg;
        arg = this.Read.Arg;
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
}