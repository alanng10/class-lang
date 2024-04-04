namespace Class.Refer;

public class SetReadOperate : Any
{
    public virtual Read Read { get; set; }

    public virtual string ExecuteString()
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

    public virtual Array ExecuteArray()
    {
        int o;
        o = this.Read.ExecuteCount();
        if (o == -1)
        {
            return null;
        }

        int oa;
        oa = this.Read.ArrayIndex;
        Array a;
        a = (Array)this.Read.ArrayArray.Get(oa);
        this.Read.ArrayIndex = oa + 1;
        return a;
    }

    public virtual bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        array.Set(index, value);
        return true;
    }

    public virtual Field ExecuteField()
    {
        return null;
    }
}