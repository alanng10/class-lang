namespace Class.Refer;

public class StringReadOperate : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.String = "";
        this.Array = this.ListInfra.ArrayCreate(0);
        this.Field = new Field();
        this.Field.Init();
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual string String { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual Field Field { get; set; }

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

        TextInfra textInfra;
        textInfra = this.TextInfra;

        int index;
        index = read.Index;

        Data data;
        data = read.Data;
        Data stringData;
        stringData = read.StringData;

        int oo;
        oo = 0;
        byte ooa;
        ooa = 0;
        char oob;
        oob = (char)0;
        int oa;
        oa = read.StringDataIndex;
        int count;
        count = o;
        int i;
        i = 0;
        while (i < count)
        {
            oo = data.Get(index + i);
            ooa = (byte)oo;
            oob = (char)ooa;
            textInfra.DataCharSet(stringData, oa + i, oob);
            i = i + 1;
        }
        
        read.Index = index + count;
        read.StringIndex = read.StringIndex + 1;
        read.StringDataIndex = oa + count;
        return this.String;
    }

    public virtual Array ExecuteArray()
    {
        int o;
        o = this.Read.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        this.Read.ArrayIndex = this.Read.ArrayIndex + 1;
        return this.Array;
    }

    public virtual bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        return true;
    }

    public virtual Field ExecuteField()
    {
        this.Read.FieldIndex = this.Read.FieldIndex + 1;
        return this.Field;
    }
}