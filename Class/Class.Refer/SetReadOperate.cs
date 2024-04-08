namespace Class.Refer;

public class SetReadOperate : ReadOperate
{
    public virtual Read Read { get; set; }

    public override string ExecuteString(int count)
    {
        Read read;
        read = this.Read;
        int o;
        o = read.ExecuteCount();
        if (o == -1)
        {
            return null;
        }

        int oa;
        oa = read.StringIndex;
        string a;
        a = (string)read.StringArray.Get(oa);

        read.Index = read.Index + o;
        read.StringIndex = oa + 1;
        read.StringDataIndex = read.StringDataIndex + o;
        return a;
    }

    public override Array ExecuteArray(int count)
    {
        int oa;
        oa = this.Read.ArrayIndex;
        Array a;
        a = (Array)this.Read.ArrayArray.Get(oa);
        this.Read.ArrayIndex = oa + 1;
        return a;
    }

    public override bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        array.Set(index, value);
        return true;
    }

    public override Field ExecuteField()
    {
        return null;
    }
}