namespace Class.Binary;

public class SetReadOperate : ReadOperate
{
    public virtual Read Read { get; set; }

    public override Binary ExecuteBinary()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.BinaryIndex;
        Binary a;
        a = (Binary)arg.BinaryArray.Get(index);
        arg.BinaryIndex = index + 1;
        return a;
    }

    public override Class ExecuteClass()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.ClassIndex;
        Class a;
        a = (Class)arg.ClassArray.Get(index);
        arg.ClassIndex = index + 1;
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

    public override Part ExecutePart()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.PartIndex;
        Part a;
        a = (Part)arg.PartArray.Get(index);
        arg.PartIndex = index + 1;
        return a;
    }

    public override Field ExecuteField()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.FieldIndex;
        Field a;
        a = (Field)arg.FieldArray.Get(index);
        arg.FieldIndex = index + 1;
        return a;
    }

    public override Maide ExecuteMaide()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.MaideIndex;
        Maide a;
        a = (Maide)arg.FieldArray.Get(index);
        arg.MaideIndex = index + 1;
        return a;
    }

    public override Var ExecuteVar()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.VarIndex;
        Var a;
        a = (Var)arg.VarArray.Get(index);
        arg.VarIndex = index + 1;
        return a;
    }

    public override ClassIndex ExecuteClassIndex()
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int index;
        index = arg.ClassIndexIndex;
        ClassIndex a;
        a = (ClassIndex)arg.ClassIndexArray.Get(index);
        arg.ClassIndexIndex = index + 1;
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

    public override string ExecuteString(int count)
    {
        ReadArg arg;
        arg = this.Read.Arg;
        int oa;
        oa = arg.StringIndex;
        string a;
        a = (string)arg.StringArray.Get(oa);

        arg.Index = arg.Index + count;
        arg.StringIndex = oa + 1;
        arg.StringTextIndex = arg.StringTextIndex + count;
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

    public override bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        array.Set(index, value);
        return true;
    }
}