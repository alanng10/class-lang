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
        this.Maide = new Maide();
        this.Maide.Init();
        this.Var = new Var();
        this.Var.Init();
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual string String { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual Field Field { get; set; }
    protected virtual Maide Maide { get; set; }
    protected virtual Var Var { get; set; }

    public override Field ExecuteField()
    {
        this.Read.FieldIndex = this.Read.FieldIndex + 1;
        return this.Field;
    }

    public override Maide ExecuteMaide()
    {
        this.Read.MaideIndex = this.Read.MaideIndex + 1;
        return this.Maide;
    }

    public override Var ExecuteVar()
    {
        this.Read.VarIndex = this.Read.VarIndex + 1;
        return this.Var;
    }

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
}