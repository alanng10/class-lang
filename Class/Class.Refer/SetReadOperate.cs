namespace Class.Refer;

public class SetReadOperate : ReadOperate
{
    public virtual Read Read { get; set; }

    public override Field ExecuteField()
    {
        Read read;
        read = this.Read;
        int index;
        index = read.FieldIndex;
        Field a;
        a = (Field)read.FieldArray.Get(index);
        read.FieldIndex = index + 1;
        return a;
    }

    public override Maide ExecuteMaide()
    {
        return null;
    }

    public override Var ExecuteVar()
    {
        return null;
    }
    
    public override string ExecuteString(int count)
    {
        Read read;
        read = this.Read;
        int oa;
        oa = read.StringIndex;
        string a;
        a = (string)read.StringArray.Get(oa);

        read.Index = read.Index + count;
        read.StringIndex = oa + 1;
        read.StringTextIndex = read.StringTextIndex + count;
        return a;
    }

    public override Array ExecuteArray(int count)
    {
        Read read;
        read = this.Read;
        int index;
        index = read.ArrayIndex;
        Array a;
        a = (Array)read.ArrayArray.Get(index);
        read.ArrayIndex = index + 1;
        return a;
    }

    public override bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        array.Set(index, value);
        return true;
    }
}