namespace Class.Refer;

public class CountReadOperate : ReadOperate
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.String = "";
        this.Array = this.ListInfra.ArrayCreate(0);
        this.Field = new Field();
        this.Field.Init();
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual string String { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual Field Field { get; set; }

    public override string ExecuteString(int count)
    {        
        Read read;
        read = this.Read;
        read.Index = read.Index + count;
        read.StringIndex = read.StringIndex + 1;
        read.StringTextIndex = read.StringTextIndex + count;
        return this.String;
    }

    public override Array ExecuteArray(int count)
    {
        this.Read.ArrayIndex = this.Read.ArrayIndex + 1;
        return this.Array;
    }

    public override bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        return true;
    }

    public override Field ExecuteField()
    {
        this.Read.FieldIndex = this.Read.FieldIndex + 1;
        return this.Field;
    }
}