namespace Class.Refer;

public class StringReadOperate : ReadOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.String = "";
        this.Array = this.ListInfra.ArrayCreate(0);
        this.Field = new Field();
        this.Field.Init();
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual string String { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual Field Field { get; set; }

    public override Field ExecuteField()
    {
        this.Read.FieldIndex = this.Read.FieldIndex + 1;
        return this.Field;
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

        TextInfra textInfra;
        textInfra = this.TextInfra;

        int index;
        index = read.Index;
        int stringIndex;
        stringIndex = read.StringIndex;

        long oe;
        oe = stringIndex * sizeof(int);
        this.InfraInfra.DataMidSet(read.StringCountData, oe, count);

        Data data;
        data = read.Data;
        Data stringTextData;
        stringTextData = read.StringTextData;

        int oo;
        oo = 0;
        byte ooa;
        ooa = 0;
        char oob;
        oob = (char)0;
        int oa;
        oa = read.StringTextIndex;
        int i;
        i = 0;
        while (i < count)
        {
            oo = data.Get(index + i);
            ooa = (byte)oo;
            oob = (char)ooa;
            textInfra.DataCharSet(stringTextData, oa + i, oob);
            i = i + 1;
        }
        
        read.Index = index + count;
        read.StringIndex = stringIndex + 1;
        read.StringTextIndex = oa + count;
        return this.String;
    }

    public override Array ExecuteArray(int count)
    {
        Read read;
        read = this.Read;

        int arrayIndex;
        arrayIndex = read.ArrayIndex;

        long oe;
        oe = arrayIndex * sizeof(int);
        this.InfraInfra.DataMidSet(read.ArrayCountData, oe, count);

        this.Read.ArrayIndex = arrayIndex + 1;
        return this.Array;
    }

    public override bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        return true;
    }
}